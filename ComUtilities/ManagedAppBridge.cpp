// ManagedAppBridge.cpp : Implementation of CManagedAppBridge

#include "stdafx.h"
#include "ManagedAppBridge.h"
#include "ProtocolCF.h"
#include "UtilMan.h"
#include <atlfile.h>

//#define ONRESPONSE_FIRED 512
//#define DATA_DOWNLOAD_STATUS 513
//#define DATA_FULLY_AVAILABLE 514
//#define OPERATION_FAILED 515

// CManagedAppBridge

STDMETHODIMP CManagedAppBridge::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_IManagedAppBridge
	};

	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}

STDMETHODIMP CManagedAppBridge::DownloadCompleteManaged(BSTR sUrl, BSTR sMime, VARIANT *data, long dataLength)
{
	USES_CONVERSION;
	ATLTRACE(_T("CManagedAppBridge-Entering DownloadCompleteManaged-URL=%s\n"), OLE2T(sUrl));

	if(dataLength == 0)
	{
		//m_spInternetProtocol->Abort(INET_E_RESOURCE_NOT_FOUND , 0);
		m_spInternetProtocolSink->ReportResult(E_FAIL, INET_E_RESOURCE_NOT_FOUND, 0);
		return AtlReportError(CLSID_ManagedAppBridge , _T("dataLength must be bigger than 0."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}

	if( data->vt != (VT_ARRAY|VT_UI1) ) //Array of BYTEs
	{
		//Abort - Something is wrong
		//m_spInternetProtocol->Abort(INET_E_RESOURCE_NOT_FOUND , 0);
		m_spInternetProtocolSink->ReportResult(E_FAIL, INET_E_CANNOT_LOAD_DATA, 0);
		return AtlReportError(CLSID_ManagedAppBridge , _T("Data must be in byte array format."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}

	//Copy data locally
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-Attempting to copy data to local buffer....\n"));
	HRESULT hr;
	SAFEARRAY * psa = data->parray;
	BYTE HUGEP *pdata;
	hr = SafeArrayAccessData(psa, (void **)&pdata);
	if(FAILED(hr))
	{
		//Abort, as we can not access data
		//m_spInternetProtocol->Abort(INET_E_CANNOT_LOAD_DATA , 0);
		m_spInternetProtocolSink->ReportResult(E_FAIL, INET_E_CANNOT_LOAD_DATA, 0);
		return AtlReportError(CLSID_ManagedAppBridge , _T("Unable to access data."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}
	m_dwDataLength = (ULONG)dataLength;
	m_pvData = new BYTE[m_dwDataLength];
	if(!m_pvData)
	{
		//Out of memory? Abort
		//m_spInternetProtocol->Abort(INET_E_CANNOT_LOAD_DATA , 0);
		m_spInternetProtocolSink->ReportResult(E_FAIL, INET_E_CANNOT_LOAD_DATA, 0);
		return AtlReportError(CLSID_ManagedAppBridge , _T("Unable to allocate memory to copy data locally."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}

	memcpy_s(m_pvData, m_dwDataLength, pdata, m_dwDataLength);
	SafeArrayUnaccessData(psa);
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-Done copying data to local buffer....\n"));

	//Report redirected
	if(::wcscmp(T2W(m_lpOriUrl), sUrl) != 0)
	{
		ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-ReportProgress-BINDSTATUS_REDIRECTING\n"));
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_REDIRECTING, sUrl);
	}

	//Report MIME available
	m_spMimeType = sMime;
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-ReportProgress-BINDSTATUS_MIMETYPEAVAILABLE=%s\n"), OLE2T(m_spMimeType));
	m_spInternetProtocolSink->ReportProgress(BINDSTATUS_MIMETYPEAVAILABLE, m_spMimeType);

	//Report filename if a filename was requested in the start method
	if( (m_NeedFileName == VARIANT_TRUE) && (m_CacheFileName.Length() > 0) )
	{
		ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-ReportProgress-BINDSTATUS_CACHEFILENAMEAVAILABLE=%s\n"), OLE2T(m_CacheFileName));
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_CACHEFILENAMEAVAILABLE, m_CacheFileName);
	}

	//Report data fully available
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManaged-ReportData-BSCF_DATAFULLYAVAILABLE=%8d\n"), m_dwDataLength);
	m_spInternetProtocolSink->ReportData( BSCF_FIRSTDATANOTIFICATION | BSCF_LASTDATANOTIFICATION | 
			BSCF_DATAFULLYAVAILABLE, m_dwDataLength, m_dwDataLength); 

//IInternetProtocol::Read gets called several times 
//before ReportData returns - be prepared for reentrancy.

	//HTTP_STATUS_OK
	ATLTRACE(_T("CManagedAppBridge-Leaving DownloadCompleteManaged-ReportResult 200-URL=%s\n"), OLE2T(sUrl));
	m_spInternetProtocolSink->ReportResult(S_OK, 200, 0);
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::DownloadCompleteManagedCache(BSTR sUrl, BSTR sMime, BSTR sCacheFileName)
{
	//Report redirected
	if(::wcscmp(T2W(m_lpOriUrl), sUrl) != 0)
	{
		ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-ReportProgress-BINDSTATUS_REDIRECTING\n"));
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_REDIRECTING, sUrl);
	}

	m_spMimeType = sMime;
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-ReportProgress-BINDSTATUS_MIMETYPEAVAILABLE=%s\n"), OLE2T(m_spMimeType));
	m_spInternetProtocolSink->ReportProgress(BINDSTATUS_MIMETYPEAVAILABLE, m_spMimeType);

	//Report filename if a filename was requested in the start method
	m_CacheFileName.Empty();
	m_CacheFileName = sCacheFileName;
	if( (m_NeedFileName == VARIANT_TRUE) && (m_CacheFileName.Length() > 0) )
	{
		//For Silverlight, we need to actually load data here and pass it to the engine
		//during Read calls?
		USES_CONVERSION;
		CAtlFile cachefile;
		ULONGLONG cachesize = 0;
		ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Attempting to open cache file=%s\n"), OLE2T(m_CacheFileName));
		HRESULT hcache = cachefile.Create(OLE2T(sCacheFileName),
			FILE_READ_ATTRIBUTES | FILE_READ_DATA, FILE_SHARE_READ, OPEN_EXISTING);
		//if(hcache != S_OK)
		//{
		//	CComBSTR excepinfo = L"Unable to open ";
		//	excepinfo.Append(sCacheFileName);
		//	excepinfo.Append(L" for reading.");
		//	return AtlReportError(CLSID_ManagedAppBridge , excepinfo, IID_IManagedAppBridge ,DISP_E_EXCEPTION);
		//}
		if(hcache == S_OK)
		{
			hcache = cachefile.GetSize(cachesize);
			if(hcache == S_OK)
			{
				ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Retreived cache file size=%s\n"), OLE2T(m_CacheFileName));
				m_dwDataLength = (DWORD)cachesize;
				m_pvData = new BYTE[m_dwDataLength];
				hcache = cachefile.Read((LPVOID)m_pvData, m_dwDataLength);
				if(hcache == S_OK)
				{
					ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Read cache file into local buffer=%s\n"), OLE2T(m_CacheFileName));
				}
				else
				{
					ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Failed to read cache file=%s\n"), OLE2T(m_CacheFileName));
					delete [] m_pvData;
					m_pvData = 0;
					m_dwDataLength = 0;
				}
			}
			else
				ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Unable to retreive cache file size=%s\n"), OLE2T(m_CacheFileName));
		}
		else
			ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-Failed to open cache file=%s\n"), OLE2T(m_CacheFileName));

		ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-ReportProgress-BINDSTATUS_CACHEFILENAMEAVAILABLE=%s\n"), OLE2T(m_CacheFileName));
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_CACHEFILENAMEAVAILABLE, m_CacheFileName);
	}
	
	//Report data fully available
	ATLTRACE(_T("CManagedAppBridge-DownloadCompleteManagedCache-ReportData-BSCF_DATAFULLYAVAILABLE=%8d\n"), m_dwDataLength);
	m_spInternetProtocolSink->ReportData( BSCF_FIRSTDATANOTIFICATION | BSCF_LASTDATANOTIFICATION | 
			BSCF_DATAFULLYAVAILABLE, m_dwDataLength, m_dwDataLength);

	//HTTP_STATUS_OK
	ATLTRACE(_T("CManagedAppBridge-Leaving DownloadCompleteManagedCache-ReportResult 200-URL=%s\n"), OLE2T(sUrl));
	m_spInternetProtocolSink->ReportResult(S_OK, 200, 0);
	return S_OK;
}


STDMETHODIMP CManagedAppBridge::DownloadAbortManaged(long InetErrorCode)
{
	ATLTRACE(_T("CManagedAppBridge-DownloadAbortManaged-Url=%s\n"), m_lpOriUrl);
	if(m_spInternetProtocolSink)
	{
		HRESULT hr = (HRESULT)InetErrorCode;
		m_spInternetProtocolSink->ReportResult(E_FAIL, InetErrorCode, 0);
		//m_spInternetProtocol->Abort(hr, 0);
	}
	else
		return AtlReportError(CLSID_ManagedAppBridge , _T("Unable to abort the request. m_spInternetProtocol pointer is NULL?."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	ATLTRACE(_T("CManagedAppBridge-Leaving DownloadAbortManaged-Url=%s\n"), m_lpOriUrl);
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::SetTargetUnknown(IUnknown* punkTarget)
{
	ATLASSERT(punkTarget != 0);
	if (!punkTarget)
	{
		return E_POINTER;
	}

	// This method should only be called once, and be the only source
	// of target interface pointers.
	ATLASSERT(m_spInternetProtocolUnk == 0);
	ATLASSERT(m_spInternetProtocol == 0);
	if (m_spInternetProtocolUnk || m_spInternetProtocol)
	{
		return E_UNEXPECTED;
	}

	// We expect the target unknown to implement at least IInternetProtocol
	// Otherwise we reject it
	HRESULT hr = punkTarget->QueryInterface(&m_spInternetProtocol);
	ATLASSERT(FAILED(hr) || m_spInternetProtocol != 0);
	if (FAILED(hr))
	{
		return hr;
	}

	m_spInternetProtocolUnk = punkTarget;

	// QI for IInternetProtocolEx, IE7 and up
	ATLASSERT(m_spInternetProtocolEx == 0);
	hr = punkTarget->QueryInterface(&m_spInternetProtocolEx);

	// QI for IInternetProtocolInfo instance
	ATLASSERT(m_spInternetProtocolInfo == 0);
	hr = punkTarget->QueryInterface(&m_spInternetProtocolInfo);

	ATLASSERT(m_spInternetPriority == 0);
	hr = punkTarget->QueryInterface(&m_spInternetPriority);

	ATLASSERT(m_spInternetThreadSwitch == 0);
	hr = punkTarget->QueryInterface(&m_spInternetThreadSwitch);

	// QI for IWinInetInfo
	ATLASSERT(m_spWinInetInfo == 0);
	hr = punkTarget->QueryInterface(&m_spWinInetInfo);

	// QI for IWinInetHttpInfo
	ATLASSERT(m_spWinInetHttpInfo == 0);
	hr = punkTarget->QueryInterface(&m_spWinInetHttpInfo);

	return S_OK;
}


STDMETHODIMP CManagedAppBridge::get_IEServerHwnd(LONG* pVal)
{
	*pVal = m_hwndIEServer;
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_URL(BSTR* pVal)
{
	if(m_lpOriUrl)
	{
		ClearBSTRPtr(*pVal);
		USES_CONVERSION;
		*pVal =	T2BSTR(m_lpOriUrl);
		return S_OK;
	}
	else
		return AtlReportError(CLSID_ManagedAppBridge , _T("Url is empty!"), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
}

STDMETHODIMP CManagedAppBridge::put_URL(BSTR newVal)
{
	USES_CONVERSION;
	if(m_lpOriUrl)
	{
		free(m_lpOriUrl);
		m_lpOriUrl = 0;
	}
	int len = ::SysStringLen(newVal);
	m_lpOriUrl = (LPTSTR) malloc((len+1) * sizeof(TCHAR));
	if(m_lpOriUrl)
	{
		m_lpOriUrl[len] = _T('\0');
		memcpy(m_lpOriUrl, OLE2T(newVal), len * sizeof(TCHAR));
	}
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_RequestHeaders(BSTR* pVal)
{
	ClearBSTRPtr(*pVal);
	*pVal = m_spRequestHeaders.Copy();
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_PostData(BSTR* pVal)
{
	ClearBSTRPtr(*pVal);
	*pVal = m_spPostData.Copy();
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_PostDataMimeType(BSTR* pVal)
{
	ClearBSTRPtr(*pVal);
	*pVal = m_spPostDataMimeType.Copy();
	return S_OK;
}
STDMETHODIMP CManagedAppBridge::put_DownloadData(VARIANT newVal)
{
	HRESULT hr;
	long lBound = 0;
	long uBound = 0;
	SAFEARRAY * psa = newVal.parray;
	BYTE HUGEP *pdata;
	hr = SafeArrayAccessData(psa, (void **)&pdata);
	if(FAILED(hr))
	{
		return AtlReportError(CLSID_ManagedAppBridge , _T("Unable to access data."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}
	hr = SafeArrayGetLBound(psa, 1, &lBound);
	hr = SafeArrayGetUBound(psa, 1, &uBound);
	//Number of Elements
	m_dwDataLength = (ULONG)((uBound - lBound) + 1);
	m_pvData = new BYTE[m_dwDataLength];
	if(!m_pvData)
	{
		//Out of memory?
		return AtlReportError(CLSID_ManagedAppBridge , _T("Unable to allocate memory to copy data locally."), IID_IManagedAppBridge ,DISP_E_EXCEPTION);
	}

	memcpy_s(m_pvData, m_dwDataLength, pdata, m_dwDataLength);
	SafeArrayUnaccessData(psa);
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_DataMimeType(BSTR* pVal)
{
	ClearBSTRPtr(*pVal);
	*pVal = m_spMimeType.Copy();
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::put_DataMimeType(BSTR newVal)
{
	if(m_spMimeType.Length() > 0)
		m_spMimeType.Empty();
	m_spMimeType = newVal;
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::get_DownloadCacheFileName(BSTR* pVal)
{
	ClearBSTRPtr(*pVal);
	*pVal = m_CacheFileName.Copy();
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::put_DownloadCacheFileName(BSTR newVal)
{
	if(m_CacheFileName.Length() > 0)
		m_CacheFileName.Empty();
	m_CacheFileName = newVal;
	return S_OK;
}


//IInternetProtocolEx
STDMETHODIMP CManagedAppBridge::StartEx(
    /* [in] */ IUri *pUri,
    /* [in] */ IInternetProtocolSink *pOIProtSink,
    /* [in] */ IInternetBindInfo *pOIBindInfo,
    /* [in] */ DWORD grfPI,
    /* [in] */ HANDLE_PTR dwReserved)
{
	//ATLTRACE(_T("CManagedAppBridge-=====>StartEx\n"));
	USES_CONVERSION;
	m_OriUri = pUri;
	CComBSTR url; //= 0;
	HRESULT hr = pUri->GetAbsoluteUri(&url);
	if( (SUCCEEDED(hr)) && (url) )
	{
		ATLTRACE(_T("CManagedAppBridge-=====>StartEx_NORMAL\n"));
		hr = Start(OLE2W(url), pOIProtSink, pOIBindInfo, grfPI, dwReserved);
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-=====>StartEx_FAILED\n"));
		hr = m_spInternetProtocolEx->StartEx(pUri, pOIProtSink, pOIBindInfo, grfPI, dwReserved);
	}
	//if(url)
	//	::SysFreeString(url);
	//m_OriUri = 0;
	return hr;
}
// IInternetProtocolRoot
STDMETHODIMP CManagedAppBridge::Start(
	/* [in] */ LPCWSTR szUrl,
	/* [in] */ IInternetProtocolSink *pOIProtSink,
	/* [in] */ IInternetBindInfo *pOIBindInfo,
	/* [in] */ DWORD grfPI,
	/* [in] */ HANDLE_PTR dwReserved)
{

USES_CONVERSION;
ATLTRACE(_T("CManagedAppBridge-Start - url=%s - grfPI=%x=\n"),OLE2T((LPWSTR)szUrl), grfPI);

	//We parse and download
	if ((grfPI & PI_PARSE_URL) != 0) 
		return S_OK;

	//Checks
	ATLASSERT(pOIProtSink != 0);
	ATLASSERT(pOIBindInfo != 0);
	if (!pOIProtSink) 
		return E_POINTER;

	//Reset everything, just in case this is being reused
	//Should never happen but better be safe
	ResetAll();

	//Cache local copy of protocolsink, and original URL
	m_spInternetProtocolSink = pOIProtSink;

	if(m_lpOriUrl)
	{
		free(m_lpOriUrl);
		m_lpOriUrl = 0;
	}
	int len = ::lstrlenW(szUrl);
	m_lpOriUrl = (LPTSTR) malloc((len+1) * sizeof(TCHAR));
	if(m_lpOriUrl)
	{
		m_lpOriUrl[len] = _T('\0');
		memcpy(m_lpOriUrl, W2T((LPWSTR)szUrl), len * sizeof(TCHAR));
	}

	//Find the instance of WB IEServer HWND
	HWND hwndIEServer = RetreiveIEServerHwnd(pOIProtSink);

	CUtilMan *spEvents = NULL;	
	if( (hwndIEServer) && (::IsWindow(hwndIEServer)) )
	{
		ATLTRACE(_T("CManagedAppBridge-Start-Attempting to find instance of CUtilMan-url=%s\n"),m_lpOriUrl);
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

		if(spEvents)
		{
			ATLTRACE(_T("CManagedAppBridge-Start-Got Events Pointer-url=%s\n"),m_lpOriUrl);
			if(spEvents->m_IEServerHwnd != hwndIEServer) //This is not ours (IE)
			{
				ATLTRACE(_T("CManagedAppBridge-Start-NOT Our IE HWND-url=%s\n"),m_lpOriUrl);
				//Take note of IE's hwnd to pass it to client
				hwndIEServer = spEvents->m_IEServerHwnd;
			}
		}
		else if(gMainCtrlInstance)
		{
			ATLTRACE(_T("CManagedAppBridge-Start-Using MainCtrlInstance-url=%s\n"),m_lpOriUrl);
			//Use the global one
			m_pUtilMan = gMainCtrlInstance;
			spEvents = reinterpret_cast<CUtilMan*>(m_pUtilMan);
			hwndIEServer = spEvents->m_IEServerHwnd;
		}
		else
		{
			ATLTRACE(_T("CManagedAppBridge-Start-No Events PointerA-url=%s\n"),m_lpOriUrl);
			m_pUtilMan = NULL;
			spEvents = NULL;
			hwndIEServer = NULL;
		}
	}
	else if(gMainCtrlInstance)
	{
		ATLTRACE(_T("CManagedAppBridge-Start-Using MainCtrlInstance-url=%s\n"),m_lpOriUrl);
		//Use the global one
		m_pUtilMan = gMainCtrlInstance;
		spEvents = reinterpret_cast<CUtilMan*>(m_pUtilMan);
		hwndIEServer = spEvents->m_IEServerHwnd;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-Start-No Events PointerB-url=%s\n"),m_lpOriUrl);
		m_pUtilMan = NULL;
		spEvents = NULL;
		hwndIEServer = NULL;
	}

	//CComPtr<IBindStatusCallback> spBSCB;
	//HRESULT hrBSCB = IUnknown_QueryService(pOIProtSink, 
	//			IID_IBindStatusCallback, IID_IBindStatusCallback, (void**)&spBSCB);
	//if( (SUCCEEDED(hrBSCB)) && (spBSCB) )
	//	ATLTRACE(_T("================>IBindStatusCallback==============>YES\n"));
	//else
	//	ATLTRACE(_T("================>IBindStatusCallback==============>NO\n"));

	if(spEvents) //&& (spEvents->m_IEServerHwnd == hwndIEServer) )
	{
		m_hwndIEServer = PtrToLong(hwndIEServer);

		ATLTRACE(_T("CManagedAppBridge-Start-Got IEServerHwnd-Attempting to retreive headers and Post data-url=%s\n"),m_lpOriUrl);

		//Attempt to grab the request headers
		RetreiveRequestHeaders(pOIProtSink, szUrl);
		//See if we have any post data
		RetreivePostData(pOIBindInfo);

		//Do we need a filename (local)?
		m_NeedFileName = ((m_bindf & BINDF_NEEDFILE) != 0) ? VARIANT_TRUE : VARIANT_FALSE;

		//Is this an Asynch or Synch download?
		m_isAsynch = ((m_bindf & BINDF_ASYNCHRONOUS) != 0) ? VARIANT_TRUE : VARIANT_FALSE;
		VARIANT_BOOL canceldl = VARIANT_FALSE;

		//Notify the client we have a request. This is the client that initiated the navigation
		ATLTRACE(_T("CManagedAppBridge-Start-Fire_OnStartManagedAPP - url=%s\n"),OLE2T((LPWSTR)szUrl));
		//Default - we assume the client wants to handle the request
		m_ClientHandled = VARIANT_TRUE;
		spEvents->Fire_OnStartManagedAPP(T2BSTR(m_lpOriUrl), m_spRequestHeaders, m_spPostData, m_spPostDataMimeType, (IDispatch*)this, m_NeedFileName, &m_CacheFileName, &m_ClientHandled, m_isAsynch, &canceldl);
		
		//Does client want to cancel here?
		if(canceldl == VARIANT_TRUE)
			return S_FALSE;

		if(m_ClientHandled == VARIANT_TRUE)
		{
			PerformClientHandled(szUrl);
		}
	}

	//Allow default implementation to handle this request
	if(m_ClientHandled == VARIANT_FALSE)
	{
		//We can return INET_E_USE_DEFAULT_PROTOCOLHANDLER
		//but then we will not be able to intercept the flow of execution!
		//Can be used as a passthru as well if IInternetProotcolSink is implemented
		//in a class to relay sink calls
		ATLTRACE(_T("CManagedAppBridge-Start-Default implementation handling-url=%s\n"),m_lpOriUrl);

		//Pass ourselves as sink + bindinfo
		ATLASSERT(m_spInternetProtocol != 0);

		CComObject<CManagedAppBridgeSink>* m_ManagedSink;
		HRESULT defaulthr = CComObject<CManagedAppBridgeSink>::CreateInstance(&m_ManagedSink);
		ATLASSERT((SUCCEEDED(defaulthr)) && m_ManagedSink != 0);
		
		m_ManagedSink->SetTargetInterfaces(
				m_lpOriUrl, pOIProtSink, pOIBindInfo, 
				m_spInternetProtocol, m_pUtilMan, hwndIEServer);

		CComPtr<IInternetProtocolSink> spSink;
		CComPtr<IInternetBindInfo> spBindInfo;
		defaulthr = m_ManagedSink->QueryInterface(
			IID_IInternetProtocolSink, reinterpret_cast<void**>(&spSink));
		ATLASSERT(SUCCEEDED(defaulthr) && spSink != 0);
		defaulthr = m_ManagedSink->QueryInterface(
			IID_IInternetBindInfo, reinterpret_cast<void**>(&spBindInfo));
		ATLASSERT(SUCCEEDED(defaulthr) && spBindInfo != 0);

		//Use m_spInternetProtocolEx for IE7
		defaulthr = E_UNEXPECTED;
		if(m_spInternetProtocolEx)
		{
			defaulthr = m_spInternetProtocolEx->StartEx(
				m_OriUri, spSink, spBindInfo, grfPI, dwReserved);
		}
		else
		{
			defaulthr = m_spInternetProtocol->Start(
				szUrl, spSink , spBindInfo, grfPI, dwReserved);
		}
		ATLTRACE(_T("CManagedAppBridge-Start-Leaving-Default implementation handling-url=%s\n"),m_lpOriUrl);
		return defaulthr;
	}

	ATLTRACE(_T("CManagedAppBridge-Start-Leaving-url=%s\n"),m_lpOriUrl);
	return S_OK;
}

STDMETHODIMP CManagedAppBridge::Continue(
	/* [in] */ PROTOCOLDATA *pProtocolData)
{
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-Continue-ClientHandled-Url=%s\n"),m_lpOriUrl);
		return S_OK;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-Continue-Url=%s\n"),m_lpOriUrl);
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Continue(pProtocolData) :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::Abort(
	/* [in] */ HRESULT hrReason,
	/* [in] */ DWORD dwOptions)
{
	m_aborted = true;
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-Abort-ClientHandled-Url=%s - reason=%x\n"), m_lpOriUrl, hrReason);
		return S_OK;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-Abort-Url=%s - reason=%x\n"), m_lpOriUrl, hrReason);
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Abort(hrReason, dwOptions) :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::Terminate(
	/* [in] */ DWORD dwOptions)
{
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-Terminate-ClientHandled-Url=%s\n"),m_lpOriUrl);
		return S_OK;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-Terminate-Url=%s\nOptions=%x\n"),m_lpOriUrl, dwOptions);
		ATLASSERT(m_spInternetProtocol != 0);
		HRESULT hr = m_spInternetProtocol ?
			m_spInternetProtocol->Terminate(dwOptions) :
			E_UNEXPECTED;
		
		//Don't bother if operation has been aborted
		if( (m_aborted == false) && (m_pUtilMan) ) //&& (m_hwndIEServer) && (::IsWindow((HWND)LongToPtr(m_hwndIEServer))) )
		{
			USES_CONVERSION;
			CUtilMan *spEvents = reinterpret_cast<CUtilMan*>(m_pUtilMan);
			spEvents->Fire_ManagedAppDataFullyRead(T2BSTR(m_lpOriUrl));
		}

		return hr;
		//return m_spInternetProtocol ?
		//	m_spInternetProtocol->Terminate(dwOptions) :
		//	E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::Suspend()
{
	//ATLTRACENOTIMPL("Suspend\n");
	if(m_ClientHandled == VARIANT_TRUE)
		return E_NOTIMPL;
	else
	{
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Suspend() :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::Resume()
{
	//ATLTRACENOTIMPL("Resume\n");
	if(m_ClientHandled == VARIANT_TRUE)
		return E_NOTIMPL;
	{
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Resume() :
			E_UNEXPECTED;
	}
}

// IInternetProtocol
STDMETHODIMP CManagedAppBridge::Read(
	/* [in, out] */ void *pv,
	/* [in] */ ULONG cb,
	/* [out] */ ULONG *pcbRead)
{
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-Read-ClientHandled-Url=%s - requested=%8d Bytes\n"),m_lpOriUrl, cb);

		//cb value (normally the first call) 2048 bytes
		//and increases as Read calls continues
		HRESULT hr = S_OK;

		if (pcbRead != NULL)
			*pcbRead = 0;

		if( (m_dwDataLength == 0) || (m_pvData == NULL) || (m_dwPos >= m_dwDataLength) )
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
	else
	{
		ATLTRACE(_T("CManagedAppBridge-Read-Url=%s - requested=%8d Bytes\n"),m_lpOriUrl, cb);
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Read(pv, cb, pcbRead) :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::Seek(
	/* [in] */ LARGE_INTEGER dlibMove,
	/* [in] */ DWORD dwOrigin,
	/* [out] */ ULARGE_INTEGER *plibNewPosition)
{
	//ATLTRACENOTIMPL("Seek\n");
	if(m_ClientHandled == VARIANT_TRUE)
		return E_NOTIMPL;
	else
	{
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->Seek(dlibMove, dwOrigin, plibNewPosition) :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::LockRequest(
	/* [in] */ DWORD dwOptions)
{
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-LockRequest-ClientHandled-Url=%s - Options=%x\n"),m_lpOriUrl, dwOptions);
		return S_OK;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-LockRequest-Url=%s - Options=%x\n"),m_lpOriUrl, dwOptions);
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->LockRequest(dwOptions) :
			E_UNEXPECTED;
	}
}

STDMETHODIMP CManagedAppBridge::UnlockRequest()
{
	if(m_ClientHandled == VARIANT_TRUE)
	{
		ATLTRACE(_T("CManagedAppBridge-UnlockRequest-ClientHandled-Url=%s\n"),m_lpOriUrl);
		return S_OK;
	}
	else
	{
		ATLTRACE(_T("CManagedAppBridge-UnlockRequest-Url=%s\n"),m_lpOriUrl);
		ATLASSERT(m_spInternetProtocol != 0);
		return m_spInternetProtocol ?
			m_spInternetProtocol->UnlockRequest() :
			E_UNEXPECTED;
	}
}

// IInternetProtocolInfo
STDMETHODIMP CManagedAppBridge::ParseUrl(
	/* [in] */ LPCWSTR pwzUrl,
	/* [in] */ PARSEACTION ParseAction,
	/* [in] */ DWORD dwParseFlags,
	/* [out] */ LPWSTR pwzResult,
	/* [in] */ DWORD cchResult,
	/* [out] */ DWORD *pcchResult,
	/* [in] */ DWORD dwReserved)
{
	//ATLTRACE(_T("CManagedAppBridge-ParseUrl\n"));
	ATLASSERT(m_spInternetProtocolInfo != 0);
	return m_spInternetProtocolInfo ?
		m_spInternetProtocolInfo->ParseUrl(pwzUrl, ParseAction, dwParseFlags,
			pwzResult, cchResult, pcchResult, dwReserved) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridge::CombineUrl(
	/* [in] */ LPCWSTR pwzBaseUrl,
	/* [in] */ LPCWSTR pwzRelativeUrl,
	/* [in] */ DWORD dwCombineFlags,
	/* [out] */ LPWSTR pwzResult,
	/* [in] */ DWORD cchResult,
	/* [out] */ DWORD *pcchResult,
	/* [in] */ DWORD dwReserved)
{
	//ATLTRACE(_T("CManagedAppBridge-CombineUrl\n"));
	ATLASSERT(m_spInternetProtocolInfo != 0);
	return m_spInternetProtocolInfo ?
		m_spInternetProtocolInfo->CombineUrl(pwzBaseUrl, pwzRelativeUrl,
			dwCombineFlags, pwzResult, cchResult, pcchResult, dwReserved) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridge::CompareUrl(
	/* [in] */ LPCWSTR pwzUrl1,
	/* [in] */ LPCWSTR pwzUrl2,
	/* [in] */ DWORD dwCompareFlags)
{
	//ATLTRACE(_T("CManagedAppBridge-CompareUrl\n"));
	ATLASSERT(m_spInternetProtocolInfo != 0);
	return m_spInternetProtocolInfo ?
		m_spInternetProtocolInfo->CompareUrl(pwzUrl1,pwzUrl2, dwCompareFlags) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridge::QueryInfo(
	/* [in] */ LPCWSTR pwzUrl,
	/* [in] */ QUERYOPTION QueryOption,
	/* [in] */ DWORD dwQueryFlags,
	/* [in, out] */ LPVOID pBuffer,
	/* [in] */ DWORD cbBuffer,
	/* [in, out] */ DWORD *pcbBuf,
	/* [in] */ DWORD dwReserved)
{
	//ATLTRACE(_T("CManagedAppBridge-QueryInfo\n"));
	ATLASSERT(m_spInternetProtocolInfo != 0);
	return m_spInternetProtocolInfo ?
		m_spInternetProtocolInfo->QueryInfo(pwzUrl, QueryOption, dwQueryFlags,
			pBuffer, cbBuffer, pcbBuf, dwReserved) :
		E_UNEXPECTED;
}

// IInternetPriority
STDMETHODIMP CManagedAppBridge::SetPriority(
	/* [in] */ LONG nPriority)
{
	//ATLTRACE(_T("CManagedAppBridge-IInternetPriority::SetPriority\n"));
	ATLASSERT(m_spInternetPriority != 0);
	return m_spInternetPriority ?
		m_spInternetPriority->SetPriority(nPriority) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridge::GetPriority(
	/* [out] */ LONG *pnPriority)
{
	//ATLTRACE(_T("CManagedAppBridge-IInternetPriority::GetPriority\n"));
	ATLASSERT(m_spInternetPriority != 0);
	return m_spInternetPriority ?
		m_spInternetPriority->GetPriority(pnPriority) :
	E_UNEXPECTED;
}

// IInternetThreadSwitch
STDMETHODIMP CManagedAppBridge::Prepare()
{
	//ATLTRACE(_T("CManagedAppBridge-IInternetThreadSwitch::Prepare\n"));
	ATLASSERT(m_spInternetThreadSwitch != 0);
	return m_spInternetThreadSwitch ?
		m_spInternetThreadSwitch->Prepare() :
	E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridge::Continue()
{
	//ATLTRACE(_T("CManagedAppBridge-IInternetThreadSwitch::Continue\n"));
	ATLASSERT(m_spInternetThreadSwitch != 0);
	return m_spInternetThreadSwitch ?
		m_spInternetThreadSwitch->Continue() :
	E_UNEXPECTED;
}

// IWinInetInfo
STDMETHODIMP CManagedAppBridge::QueryOption(
	/* [in] */ DWORD dwOption,
	/* [in, out] */ LPVOID pBuffer,
	/* [in, out] */ DWORD *pcbBuf)
{
	//ATLTRACE(_T("CManagedAppBridge-IWinInetInfo::QueryOption\n"));
	ATLASSERT(m_spWinInetInfo != 0);
	return m_spWinInetInfo ?
		m_spWinInetInfo->QueryOption(dwOption, pBuffer, pcbBuf) :
		E_UNEXPECTED;
}

// IWinInetHttpInfo
STDMETHODIMP CManagedAppBridge::QueryInfo(
	/* [in] */ DWORD dwOption,
	/* [in, out] */ LPVOID pBuffer,
	/* [in, out] */ DWORD *pcbBuf,
	/* [in, out] */ DWORD *pdwFlags,
	/* [in, out] */ DWORD *pdwReserved)
{
	//ATLTRACE(_T("CManagedAppBridge-IWinInetHttpInfo::QueryInfo\n"));
	ATLASSERT(m_spWinInetHttpInfo  != 0);
	return m_spWinInetHttpInfo ?
		m_spWinInetHttpInfo->QueryInfo(dwOption, pBuffer, pcbBuf, pdwFlags,
			pdwReserved) :
		E_UNEXPECTED;
}

/*
* CManagedAppBridgeSink
* 
* 
* 
*/
HRESULT CManagedAppBridgeSink::SetTargetInterfaces(LPTSTR szUrl, IInternetProtocolSink *pOIProtSink, 
	IInternetBindInfo *pOIBindInfo, IInternetProtocol* pTargetProtocol, void *pEvent, HWND hwndIE)
{
	m_lpOriUrl = szUrl;
	m_spTargetProtocol = pTargetProtocol;
	m_spInternetProtocolSink = pOIProtSink;
	m_spInternetBindInfo = pOIBindInfo;
	pOIProtSink->QueryInterface(IID_IServiceProvider, (void **)&m_spServiceProvider);
	m_pEvents = pEvent;
	m_hwndIEServer = hwndIE;
	//m_bDataFullyAvailable = false;

	USES_CONVERSION;
	m_strUrl.Empty();
	m_strUrl = T2BSTR(m_lpOriUrl);
	m_strRedirUrl.Empty();
	m_strRedirHeaders.Empty();

	return S_OK;
}

// IInternetProtocolSink
STDMETHODIMP CManagedAppBridgeSink::Switch(
	/* [in] */ PROTOCOLDATA *pProtocolData)
{
	ATLTRACE(_T("CManagedAppBridgeSink-Switch-url=%s\n"),m_lpOriUrl);
	ATLASSERT(m_spInternetProtocolSink != 0);

	////if( (pProtocolData->grfFlags & PD_FORCE_SWITCH) != PD_FORCE_SWITCH)
	//if( (pProtocolData->grfFlags & PD_FORCE_SWITCH) == 0)
	//	pProtocolData->grfFlags |= PD_FORCE_SWITCH;

	return m_spInternetProtocolSink ?
		m_spInternetProtocolSink->Switch(pProtocolData) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridgeSink::ReportProgress(
	/* [in] */ ULONG ulStatusCode,
	/* [in] */ LPCWSTR szStatusText)
{
	ATLTRACE(_T("CManagedAppBridgeSink-ReportProgress-url=%s - StatusCode=%8d\n"),m_lpOriUrl,ulStatusCode );
	ATLASSERT(m_spInternetProtocolSink != 0);
	HRESULT hr = m_spInternetProtocolSink ?
		m_spInternetProtocolSink->ReportProgress(ulStatusCode, szStatusText) :
		E_UNEXPECTED;

	if(ulStatusCode == BINDSTATUS_REDIRECTING)
	{
		USES_CONVERSION;

		//Get redirected URL
		m_strRedirUrl.Empty();
		if(szStatusText)
			m_strRedirUrl.AppendBSTR(W2BSTR(szStatusText));
		else
			m_strRedirUrl = L"";
		
		//To get redirect headers during a redirect
		//No OnResponse is fired for a redirect
		m_strRedirHeaders.Empty();
		//Get raw request headers and send them to client
/*
Client applications can call QueryInterface on the IBinding 
interface to get a pointer to the IWinInetHttpInfo interface 
after your implementation of the IBindStatusCallback::OnProgress 
method has been called.
*/
		CComPtr<IWinInetHttpInfo> spWinInetHttpInfo;
		HRESULT hrTemp = m_spTargetProtocol->QueryInterface(IID_IWinInetHttpInfo,
			reinterpret_cast<void**>(&spWinInetHttpInfo));
		if(SUCCEEDED(hrTemp))
		{
			DWORD size = 0;
			DWORD flags = 0;
			hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
				0, &size, &flags, 0);
			if(SUCCEEDED(hrTemp))
			{
				LPSTR pbuf = new char[size+1];
				if(pbuf)
				{
					pbuf[size] = '\0';
					hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
						pbuf, &size, &flags, 0);
					if(SUCCEEDED(hrTemp))
					{
						//\r\n\r\n\0 Get rid of extra
						if( (size > 5) &&
							(pbuf[size-1] == '\n') && (pbuf[size-2] == '\r') &&
							(pbuf[size-3] == '\n') && (pbuf[size-4] == '\r') )
						{
							pbuf[size-1] = '\0';
							pbuf[size-2] = '\0';
						}
						//pbuf should contain all request headers
						m_strRedirHeaders.Append(pbuf);
					}
					else
						m_strRedirHeaders = L"";
					delete[] pbuf;
				}
				else
					m_strRedirHeaders = L"";
			}
			else
				m_strRedirHeaders = L"";
		}
		else
			m_strRedirHeaders = L"";
	}

	return hr;

}

STDMETHODIMP CManagedAppBridgeSink::ReportData(
	/* [in] */ DWORD grfBSCF,
	/* [in] */ ULONG ulProgress,
	/* [in] */ ULONG ulProgressMax)
{
	ATLTRACE(_T("CManagedAppBridgeSink-ReportData-url=%s\nBSCF=%8d - Progress=%8d - ProgressMax=%8d\n"),m_lpOriUrl, grfBSCF, ulProgress, ulProgressMax);
	ATLASSERT(m_spInternetProtocolSink != 0);
	return m_spInternetProtocolSink ?
		m_spInternetProtocolSink->ReportData(grfBSCF, ulProgress,
			ulProgressMax) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridgeSink::ReportResult(
	/* [in] */ HRESULT hrResult,
	/* [in] */ DWORD dwError,
	/* [in] */ LPCWSTR szResult)
{
	ATLTRACE(_T("CManagedAppBridgeSink-ReportResult-url=%s - Result=%x\n"),m_lpOriUrl, hrResult);
	ATLASSERT(m_spInternetProtocolSink != 0);

	HRESULT hr = m_spInternetProtocolSink ?
		m_spInternetProtocolSink->ReportResult(hrResult, dwError, szResult) :
		E_UNEXPECTED;

	//Downloaded successfully
	if(hrResult == S_OK) //0
	{
		if( (m_pEvents) && (m_hwndIEServer) && (::IsWindow(m_hwndIEServer)) )
		{
			CUtilMan *spEvents = reinterpret_cast<CUtilMan*>(m_pEvents);
			spEvents->Fire_ManagedAppDataFullyAvailable(m_strUrl);				
		}
	}
	else if(hrResult == E_ABORT) //E_ABORT, 80004004, Operation aborted error
	{
		if( (m_pEvents) && (m_hwndIEServer) && (::IsWindow(m_hwndIEServer)) )
		{
			CUtilMan *spEvents = reinterpret_cast<CUtilMan*>(m_pEvents);
			spEvents->Fire_ManagedAppOperationFailed(m_strUrl);
		}
	}

	return hr;
	//return m_spInternetProtocolSink ?
	//	m_spInternetProtocolSink->ReportResult(hrResult, dwError, szResult) :
	//	E_UNEXPECTED;
}

// IInternetBindInfo
STDMETHODIMP CManagedAppBridgeSink::GetBindInfo(
	/* [out] */ DWORD *grfBINDF,
	/* [in, out] */ BINDINFO *pbindinfo)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-GetBindInfo-url=%s\n"),m_lpOriUrl);
	ATLASSERT(m_spInternetBindInfo != 0);
	return m_spInternetBindInfo ?
		m_spInternetBindInfo->GetBindInfo(grfBINDF, pbindinfo) :
		E_UNEXPECTED;
}

STDMETHODIMP CManagedAppBridgeSink::GetBindString(
	/* [in] */ ULONG ulStringType,
	/* [in, out] */ LPOLESTR *ppwzStr,
	/* [in] */ ULONG cEl,
	/* [in, out] */ ULONG *pcElFetched)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-GetBindString-url=%s\n"),m_lpOriUrl);
	ATLASSERT(m_spInternetBindInfo != 0);
	return m_spInternetBindInfo ?
		m_spInternetBindInfo->GetBindString(ulStringType, ppwzStr, cEl,
			pcElFetched) :
		E_UNEXPECTED;
}

//IServiceProvider
STDMETHODIMP CManagedAppBridgeSink::QueryService(REFGUID guidService, REFIID riid, void** ppv)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-QueryService\n"));
	HRESULT hr = _InternalQueryService(guidService, riid, ppv);
	if (FAILED(hr) && m_spServiceProvider)
	{
		hr = m_spServiceProvider->QueryService(guidService, riid, ppv);
	}
	return hr;
}

HRESULT CManagedAppBridgeSink::_InternalQueryService(REFGUID guidService, REFIID riid, void** ppvObject)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-_InternalQueryService\n"));

	ATLASSERT(ppvObject != NULL);
	if (ppvObject == NULL)
		return E_POINTER;
	*ppvObject = NULL;
	if( (InlineIsEqualGUID(guidService, IID_IHttpNegotiate)) ||
		(InlineIsEqualGUID(riid, IID_IHttpNegotiate)) )
		return _InternalQueryInterface(riid, ppvObject);

	return E_NOINTERFACE;
}

// IHttpNegotiate
STDMETHODIMP CManagedAppBridgeSink::BeginningTransaction(
	/* [in] */ LPCWSTR szURL,
	/* [in] */ LPCWSTR szHeaders,
	/* [in] */ DWORD dwReserved,
	/* [out] */ LPWSTR *pszAdditionalHeaders)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-BeginningTransaction\n"));
	if (pszAdditionalHeaders)
	{
		*pszAdditionalHeaders = 0;
	}

	CComPtr<IHttpNegotiate> spHttpNegotiate;
	QueryServiceFromClient(&spHttpNegotiate);
	HRESULT hr = spHttpNegotiate ?
		spHttpNegotiate->BeginningTransaction(szURL, szHeaders,
			dwReserved, pszAdditionalHeaders) : S_OK;

	USES_CONVERSION;
	if(szURL)
	{
		m_strUrl.Empty();
		m_strUrl.AppendBSTR(W2BSTR(szURL));
	}
	m_strRedirUrl = L"";

	CComBSTR strRequestHeaders;
	//Get raw request headers and send them to client
	CComPtr<IWinInetHttpInfo> spWinInetHttpInfo;
	HRESULT hrTemp = m_spTargetProtocol->QueryInterface(IID_IWinInetHttpInfo,
		reinterpret_cast<void**>(&spWinInetHttpInfo));
	if(SUCCEEDED(hrTemp))
	{
		DWORD size = 0;
		DWORD flags = 0;
		hrTemp = spWinInetHttpInfo->QueryInfo(
			HTTP_QUERY_RAW_HEADERS_CRLF | HTTP_QUERY_FLAG_REQUEST_HEADERS,
			0, &size, &flags, 0);
		if(SUCCEEDED(hrTemp))
		{
			LPSTR pbuf = new char[size+1];
			if(pbuf)
			{
				pbuf[size] = '\0';
				hrTemp = spWinInetHttpInfo->QueryInfo(
					HTTP_QUERY_RAW_HEADERS_CRLF | HTTP_QUERY_FLAG_REQUEST_HEADERS,
					pbuf, &size, &flags, 0);
				if(SUCCEEDED(hrTemp))
				{
					//\r\n\r\n\0 Get rid of extra
					if( (size > 5) &&
						(pbuf[size-1] == '\n') && (pbuf[size-2] == '\r') &&
						(pbuf[size-3] == '\n') && (pbuf[size-4] == '\r') )
					{
						pbuf[size-1] = '\0';
						pbuf[size-2] = '\0';
					}
					//pbuf should contain all request headers
					strRequestHeaders.Append(pbuf);
				}
				else
					strRequestHeaders = L"";
				delete[] pbuf;
			}
			else
				strRequestHeaders = L"";
		}
		else
			strRequestHeaders = L"";
	}
	else
		strRequestHeaders = L"";

	//Additional Client headers
	CComBSTR strAddHttpHeaders;

	if(szHeaders)
	{
		//Accept-Encoding: gzip, deflate
		strRequestHeaders += W2BSTR(szHeaders);
		strRequestHeaders.Append(_T("\r\n"));
	}
	if( pszAdditionalHeaders && *pszAdditionalHeaders)
	{
		//Referer: http://www.google.ca/
		//Accept-Language: en-ca
		strAddHttpHeaders = W2BSTR(*pszAdditionalHeaders);
		strRequestHeaders += strAddHttpHeaders;
	}
	//Fire event
	if( (m_pEvents) && (m_hwndIEServer) && (::IsWindow(m_hwndIEServer)) )
	{
		CUtilMan *spEvents = reinterpret_cast<CUtilMan*>(m_pEvents);
		VARIANT_BOOL bcancel = VARIANT_FALSE;
		CComBSTR strTempHeaders(L"");
		spEvents->Fire_ManagedAppBeginningTransaction(m_strUrl, strRequestHeaders, 
											&strTempHeaders, &bcancel);
		if(bcancel == VARIANT_TRUE)
			return E_ABORT;
		
		//Did client add any of their headers
		if(strTempHeaders.Length() > 0)
		{
			strTempHeaders += strAddHttpHeaders;
			if(strTempHeaders.Length() > 0)
			{
				LPWSTR wszAdditionalHeaders = (LPWSTR)CoTaskMemAlloc((strTempHeaders.Length()+1) *sizeof(WCHAR));
				if(wszAdditionalHeaders)
				{
					//Free what we had
					CoTaskMemFree(*pszAdditionalHeaders);
					wcscpy(wszAdditionalHeaders, OLE2W(strTempHeaders));
					
					wszAdditionalHeaders[strTempHeaders.Length()] = (WCHAR)NULL;
					*pszAdditionalHeaders = wszAdditionalHeaders;
				}
			}
		}
	}

	return hr;
}

STDMETHODIMP CManagedAppBridgeSink::OnResponse(
	/* [in] */ DWORD dwResponseCode,
	/* [in] */ LPCWSTR szResponseHeaders,
	/* [in] */ LPCWSTR szRequestHeaders,
	/* [out] */ LPWSTR *pszAdditionalRequestHeaders)
{
	//ATLTRACE(_T("CManagedAppBridgeSink-OnResponse\n"));
	if (pszAdditionalRequestHeaders)
	{
		*pszAdditionalRequestHeaders = 0;
	}
	CComPtr<IHttpNegotiate> spHttpNegotiate;
	QueryServiceFromClient(&spHttpNegotiate);
	HRESULT hr = spHttpNegotiate ?
		spHttpNegotiate->OnResponse(dwResponseCode, szResponseHeaders,
			szRequestHeaders, pszAdditionalRequestHeaders) : S_OK;


	USES_CONVERSION;
	CTmpBuffer buff(MAX_PATH*2);
	buff = W2CT(szResponseHeaders);
	if (szRequestHeaders)
	{
		//buff += _T("(Repeat request)\r\n");
		buff += W2CT(szRequestHeaders);
		if (SUCCEEDED(hr) && pszAdditionalRequestHeaders &&
			*pszAdditionalRequestHeaders)
		{
			buff += W2CT(*pszAdditionalRequestHeaders);
		}
	}

	if( (m_pEvents) && (m_hwndIEServer) && (::IsWindow(m_hwndIEServer)) )
	{
		CUtilMan *spEvents = reinterpret_cast<CUtilMan*>(m_pEvents);
		VARIANT_BOOL bcancel = VARIANT_FALSE;

		//Fire event
		spEvents->Fire_ManagedAppOnResponse(m_strUrl, 
											T2BSTR(buff), m_strRedirUrl, 
											m_strRedirHeaders, &bcancel);

		if(bcancel == VARIANT_TRUE)
			return m_spTargetProtocol->Abort(E_ABORT,0);

		if(m_strRedirUrl.Length() > 0)
		{
			m_strUrl.Empty();
			m_strUrl = m_strRedirUrl;
		}
	}

	return hr;
}
