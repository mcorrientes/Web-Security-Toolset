// CustManageApp.cpp : Implementation of CCustManageApp

#include "stdafx.h"
#include "CustManageApp.h"
#include "UtilMan.h"

// CCustManageApp

STDMETHODIMP CCustManageApp::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_ICustManageApp
	};

	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}

STDMETHODIMP CCustManageApp::DownloadCompleteCustomApp(BSTR sUrl, BSTR sMime, VARIANT *data, long dataLength)
{
	if( data->vt != (VT_ARRAY|VT_UI1) ) //Array of BYTEs
	{
		//Abort - Something is wrong
		m_spProtocolSink->ReportResult(E_FAIL, INET_E_RESOURCE_NOT_FOUND, 0);
		return AtlReportError(CLSID_CustManageApp , _T("Data must be in byte array format."), IID_ICustManageApp  ,DISP_E_EXCEPTION);
	}

	//Copy data locally
	HRESULT hr;
	SAFEARRAY * psa = data->parray;
	BYTE HUGEP *pdata;
	hr = SafeArrayAccessData(psa, (void **)&pdata);
	if(FAILED(hr))
	{
		//Abort, as we can not access data
		m_spProtocolSink->ReportResult(E_FAIL, INET_E_CANNOT_LOAD_DATA, 0);
		return AtlReportError(CLSID_CustManageApp , _T("Unable to access data."), IID_ICustManageApp ,DISP_E_EXCEPTION);
	}
	m_dwDataLength = (ULONG)dataLength;
	m_pvData = new BYTE[m_dwDataLength];
	if(!m_pvData)
	{
		//Out of memory? Abort
		m_spProtocolSink->ReportResult(E_FAIL, INET_E_CANNOT_LOAD_DATA, 0);
		return AtlReportError(CLSID_CustManageApp , _T("Unable to allocate memory to copy data locally."), IID_ICustManageApp ,DISP_E_EXCEPTION);
	}

	memcpy_s(m_pvData, m_dwDataLength, pdata, m_dwDataLength);
	SafeArrayUnaccessData(psa);

	//Report redirected
	if(m_spOriUrl != sUrl)
		m_spProtocolSink->ReportProgress(BINDSTATUS_REDIRECTING, sUrl);

	//Report MIME available
	m_spProtocolSink->ReportProgress(BINDSTATUS_MIMETYPEAVAILABLE, sMime);

	//Report data fully available
	m_spProtocolSink->ReportData( BSCF_FIRSTDATANOTIFICATION | BSCF_LASTDATANOTIFICATION | 
			BSCF_DATAFULLYAVAILABLE, m_dwDataLength, m_dwDataLength); 

	//HTTP_STATUS_OK
	m_spProtocolSink->ReportResult(S_OK, 200, 0);
	return S_OK;
}

STDMETHODIMP CCustManageApp::DownloadAbortCustomApp(long InetErrorCode)
{
	if(m_spProtocolSink)
	{
		DWORD hr = (DWORD)InetErrorCode;
		m_spProtocolSink->ReportResult(E_FAIL, InetErrorCode, 0);
	}
	else
		return AtlReportError(CLSID_CustManageApp , _T("Unable to abort the request. m_spInternetProtocol pointer is NULL?."), IID_ICustManageApp ,DISP_E_EXCEPTION);
	return S_OK;
}

STDMETHODIMP CCustManageApp::Start(LPCWSTR szUrl, IInternetProtocolSink *pOIProtSink, IInternetBindInfo *pOIBindInfo, DWORD grfPI, HANDLE_PTR dwReserved)
{
	//We parse and download
	if ((grfPI & PI_PARSE_URL) != 0) 
		return S_OK;

	ATLASSERT(pOIProtSink != 0);
	ATLASSERT(pOIBindInfo != 0);
	if (!pOIProtSink) 
		return E_POINTER;

	//Cache pointers
	m_spProtocolSink = pOIProtSink;
	m_spBindInfo = pOIBindInfo;

	m_spOriUrl.Empty();
	m_spOriUrl = szUrl;

	HRESULT hret = S_OK;
	//Find the instance of WB
	CComPtr<IWindowForBindingUI> objWindowForBindingUI;
	HRESULT hr = IUnknown_QueryService(pOIProtSink, 
		IID_IWindowForBindingUI, IID_IWindowForBindingUI, (void**)&objWindowForBindingUI);

	if( (SUCCEEDED(hr)) && (objWindowForBindingUI) )
	{
		HWND hwndIEServer = NULL;
		//Should return InternetExplorerServer HWND
		objWindowForBindingUI->GetWindow(IID_IHttpSecurity, &hwndIEServer);
		//From here we can find the ATL window hosting this instance of our control
		//and have it fire an event for the form/dlg hosting this instance of our control
		if( (hwndIEServer) && (::IsWindow(hwndIEServer)) )
		{
			CUtilMan *spEvents;
			int i = 0;
			int isize = gCtrlInstances.GetSize();
			for(i = 0; i < isize; i++)
			{
				//Cache a local copy of CUtilMan pointer for future use
				m_pUtilMan = gCtrlInstances[i];
				spEvents = reinterpret_cast<CUtilMan*>(m_pUtilMan);
				if( (spEvents) && (spEvents->m_IEServerHwnd == hwndIEServer) )
					break;
			}

			if( (spEvents) && (spEvents->m_IEServerHwnd == hwndIEServer) )
			{
				m_hwndIEServer = PtrToLong(hwndIEServer);
				//Notify client
				spEvents->Fire_OnStartCustManagedApp(m_spOriUrl, (IDispatch*)this);
			}
			else
			{
				m_pUtilMan = 0;
				hret = S_FALSE; //Cancel it???
			}
		}
	}
	return hret;
}

STDMETHODIMP CCustManageApp::Read(void *pv, ULONG cb, ULONG *pcbRead)
{
	//cb value (normally the first call) 2048 bytes
	//and increases as Read calls continues
	HRESULT hr = S_OK;

	if (pcbRead != NULL)
		*pcbRead = 0;

	if (m_dwPos >= m_dwDataLength)
		return S_FALSE; //Done

	BYTE* pbData = m_pvData + m_dwPos;
	DWORD cbAvail = m_dwDataLength - m_dwPos;

	if (cbAvail > cb)
	{
		memcpy((LPVOID)pv, (LPVOID)pbData, cb * sizeof(BYTE));
		m_dwPos += cb;
		*pcbRead = cb;
	}
	else
	{
		memcpy((LPVOID)pv, (LPVOID)pbData, cbAvail * sizeof(BYTE));
		m_dwPos += cbAvail;
		*pcbRead = cbAvail;
	}

	return hr;
}