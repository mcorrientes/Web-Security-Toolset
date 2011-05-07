// CustManageApp.h : Declaration of the CCustManageApp

#pragma once
#include "resource.h"       // main symbols

#include "ComUtilities.h"
#include "_ICustManageAppEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CCustManageApp

class ATL_NO_VTABLE CCustManageApp :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCustManageApp, &CLSID_CustManageApp>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CCustManageApp>,
	public CProxy_ICustManageAppEvents<CCustManageApp>,
	public IDispatchImpl<ICustManageApp, &IID_ICustManageApp, &LIBID_ComUtilitiesLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IInternetProtocol,
	public IInternetProtocolInfo
{
public:
	CCustManageApp() : m_hwndIEServer(0), 
		m_pUtilMan(0),	m_pvData(0), m_dwPos(0), m_dwDataLength(0)
	{
		m_spOriUrl = L"";
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CUSTMANAGEAPP)


BEGIN_COM_MAP(CCustManageApp)
	COM_INTERFACE_ENTRY(ICustManageApp)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IInternetProtocol)
	COM_INTERFACE_ENTRY(IInternetProtocolRoot)
	COM_INTERFACE_ENTRY(IInternetProtocolInfo)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CCustManageApp)
	CONNECTION_POINT_ENTRY(__uuidof(_ICustManageAppEvents))
END_CONNECTION_POINT_MAP()
// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid);


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:
	STDMETHOD (DownloadCompleteCustomApp)(/*[in]*/ BSTR sUrl, /*[in]*/ BSTR sMime, /*[in]*/ VARIANT *data, /*[in]*/ long dataLength);
	STDMETHOD (DownloadAbortCustomApp)(/*[in]*/ long InetErrorCode);

public:

	// IInternetProtocolRoot
	STDMETHODIMP Start(
		/* [in] */ LPCWSTR szUrl,
		/* [in] */ IInternetProtocolSink *pOIProtSink,
		/* [in] */ IInternetBindInfo *pOIBindInfo,
		/* [in] */ DWORD grfPI,
		/* [in] */ HANDLE_PTR dwReserved);

	STDMETHODIMP Continue(
		/* [in] */ PROTOCOLDATA *pProtocolData)
	{
		return S_OK;
	}

	STDMETHODIMP Abort(
		/* [in] */ HRESULT hrReason,
		/* [in] */ DWORD dwOptions)
	{
		return S_OK;
	}

	STDMETHODIMP Terminate(
		/* [in] */ DWORD dwOptions)
	{
		return S_OK;
	}

	STDMETHODIMP Suspend()
	{
		return E_NOTIMPL;
	}

	STDMETHODIMP Resume()
	{
		return E_NOTIMPL;
	}

	// IInternetProtocol
	STDMETHODIMP Read(
		/* [in, out] */ void *pv,
		/* [in] */ ULONG cb,
		/* [out] */ ULONG *pcbRead);

	STDMETHODIMP Seek(
		/* [in] */ LARGE_INTEGER dlibMove,
		/* [in] */ DWORD dwOrigin,
		/* [out] */ ULARGE_INTEGER *plibNewPosition)
	{
		return E_NOTIMPL;
	}

	STDMETHODIMP LockRequest(
		/* [in] */ DWORD dwOptions)
	{
		return S_OK;
	}

	STDMETHODIMP UnlockRequest()
	{
		return S_OK;
	}

	// IInternetProtocolInfo
	STDMETHODIMP ParseUrl(
		/* [in] */ LPCWSTR pwzUrl,
		/* [in] */ PARSEACTION ParseAction,
		/* [in] */ DWORD dwParseFlags,
		/* [out] */ LPWSTR pwzResult,
		/* [in] */ DWORD cchResult,
		/* [out] */ DWORD *pcchResult,
		/* [in] */ DWORD dwReserved)
	{
		return INET_E_DEFAULT_ACTION;
	}

	STDMETHODIMP CombineUrl(
		/* [in] */ LPCWSTR pwzBaseUrl,
		/* [in] */ LPCWSTR pwzRelativeUrl,
		/* [in] */ DWORD dwCombineFlags,
		/* [out] */ LPWSTR pwzResult,
		/* [in] */ DWORD cchResult,
		/* [out] */ DWORD *pcchResult,
		/* [in] */ DWORD dwReserved)
	{
		return INET_E_DEFAULT_ACTION;
	}

	STDMETHODIMP CompareUrl(
		/* [in] */ LPCWSTR pwzUrl1,
		/* [in] */ LPCWSTR pwzUrl2,
		/* [in] */ DWORD dwCompareFlags)
	{
		// Ignoring dwCompareFlags
		if (0 == wcscmp(pwzUrl1, pwzUrl2))
			return S_OK;
		else
			return S_FALSE;
	}

	STDMETHODIMP QueryInfo(
		/* [in] */ LPCWSTR pwzUrl,
		/* [in] */ QUERYOPTION QueryOption,
		/* [in] */ DWORD dwQueryFlags,
		/* [in, out] */ LPVOID pBuffer,
		/* [in] */ DWORD cbBuffer,
		/* [in, out] */ DWORD *pcbBuf,
		/* [in] */ DWORD dwReserved)
	{
		return INET_E_DEFAULT_ACTION;
	}

private:
	long							m_hwndIEServer;
	CComPtr<IInternetProtocolSink>	m_spProtocolSink;
	CComPtr<IInternetBindInfo>		m_spBindInfo;
	CComBSTR						m_spOriUrl;
	DWORD							m_dwPos;
	BYTE*							m_pvData;
	DWORD							m_dwDataLength;
	void							*m_pUtilMan;

	//Utility
	HRESULT IUnknown_QueryService(IUnknown* punk, REFGUID rsid, REFIID riid, void ** ppvObj)
	{
		HRESULT hr = E_NOINTERFACE;

		*ppvObj = 0;

		if (punk)
		{
			CComPtr<IServiceProvider> spClientProvider;
			hr = punk->QueryInterface(IID_IServiceProvider, (void **) &spClientProvider);
			if( (SUCCEEDED(hr)) && (spClientProvider) )
			{
				hr = spClientProvider->QueryService(rsid,riid, ppvObj);
			}
		}
		return hr;
	}

};

OBJECT_ENTRY_AUTO(__uuidof(CustManageApp), CCustManageApp)
