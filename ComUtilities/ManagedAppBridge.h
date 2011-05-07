// ManagedAppBridge.h : Declaration of the CManagedAppBridge

#pragma once
#include "resource.h"       // main symbols

#include "ComUtilities.h"
#include "_IManagedAppBridgeEvents_CP.h"
#include <urlmon.h>
#include "PassthroughObject.h"
#include "strsafe.h"
#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

class CManagedAppBridgeSink;

// CManagedAppBridge

class ATL_NO_VTABLE CManagedAppBridge :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CManagedAppBridge, &CLSID_ManagedAppBridge>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CManagedAppBridge>,
	public CProxy_IManagedAppBridgeEvents<CManagedAppBridge>,
	public IDispatchImpl<IManagedAppBridge, &IID_IManagedAppBridge, &LIBID_ComUtilitiesLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IPassthroughObject,
	//public IInternetProtocol,
	public IInternetProtocolEx, //IE7
	public IInternetProtocolInfo,
	public IInternetPriority,
	public IInternetThreadSwitch,
	public IWinInetHttpInfo
{
public:
	CManagedAppBridge() : m_hwndIEServer(0), 
		m_pUtilMan(0),	m_pvData(0), m_dwPos(0), m_dwDataLength(0), m_lpOriUrl(0), m_bindf(0)
	{
		m_ClientHandled = VARIANT_FALSE;
		m_NeedFileName = VARIANT_FALSE;
		m_isAsynch = VARIANT_FALSE;
		m_spMimeType = L"";
		m_spRequestHeaders = L"";
		m_spPostData = L"";
		// Assume "application/x-www-form-urlencoded".
		m_spPostDataMimeType = L"application/x-www-form-urlencoded";
		m_CacheFileName = L"";
		m_aborted = false;
	}

	~CManagedAppBridge()
	{
		if(m_pvData)
			delete [] m_pvData;
		if(m_lpOriUrl)
			free(m_lpOriUrl);
	}

DECLARE_REGISTRY_RESOURCEID(IDR_MANAGEDAPPBRIDGE)

BEGIN_COM_MAP(CManagedAppBridge)
	COM_INTERFACE_ENTRY(IManagedAppBridge)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IPassthroughObject)
	COM_INTERFACE_ENTRY(IInternetProtocolRoot)
	COM_INTERFACE_ENTRY(IInternetProtocol)
	COM_INTERFACE_ENTRY(IInternetProtocolEx)
	COM_INTERFACE_ENTRY(IInternetProtocolInfo)
	COM_INTERFACE_ENTRY(IWinInetInfo)
	COM_INTERFACE_ENTRY(IWinInetHttpInfo)
END_COM_MAP()


BEGIN_CONNECTION_POINT_MAP(CManagedAppBridge)
	CONNECTION_POINT_ENTRY(__uuidof(_IManagedAppBridgeEvents))
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
	STDMETHOD (DownloadCompleteManaged)(/*[in]*/ BSTR sUrl, /*[in]*/ BSTR sMime, /*[in]*/ VARIANT *data, /*[in]*/ long dataLength);
	STDMETHOD (DownloadAbortManaged)(/*[in]*/ long InetErrorCode);
	STDMETHOD (get_IEServerHwnd)(LONG* pVal);
	STDMETHOD (get_URL)(BSTR* pVal);
	STDMETHOD (put_URL)(BSTR newVal);
	STDMETHOD (get_RequestHeaders)(BSTR* pVal);
	STDMETHOD (get_PostData)(BSTR* pVal);
	STDMETHOD (get_PostDataMimeType)(BSTR* pVal);
	STDMETHOD (put_DownloadData)(VARIANT newVal);
	STDMETHOD (get_DataMimeType)(BSTR* pVal);
	STDMETHOD (put_DataMimeType)(BSTR newVal);
	STDMETHOD (get_DownloadCacheFileName)(BSTR* pVal);
	STDMETHOD (put_DownloadCacheFileName)(BSTR newVal);
	STDMETHOD (DownloadCompleteManagedCache)(BSTR sUrl, BSTR sMime, BSTR sCacheFileName);

public:
	// IPassthroughObject
	STDMETHODIMP SetTargetUnknown(IUnknown* punkTarget);

	// IInternetProtocolRoot
	STDMETHODIMP Start(
		/* [in] */ LPCWSTR szUrl,
		/* [in] */ IInternetProtocolSink *pOIProtSink,
		/* [in] */ IInternetBindInfo *pOIBindInfo,
		/* [in] */ DWORD grfPI,
		/* [in] */ HANDLE_PTR dwReserved);

	STDMETHODIMP Continue(
		/* [in] */ PROTOCOLDATA *pProtocolData);

	STDMETHODIMP Abort(
		/* [in] */ HRESULT hrReason,
		/* [in] */ DWORD dwOptions);

	STDMETHODIMP Terminate(
		/* [in] */ DWORD dwOptions);

	STDMETHODIMP Suspend();

	STDMETHODIMP Resume();

	// IInternetProtocol
	STDMETHODIMP Read(
		/* [in, out] */ void *pv,
		/* [in] */ ULONG cb,
		/* [out] */ ULONG *pcbRead);

	STDMETHODIMP Seek(
		/* [in] */ LARGE_INTEGER dlibMove,
		/* [in] */ DWORD dwOrigin,
		/* [out] */ ULARGE_INTEGER *plibNewPosition);

	STDMETHODIMP LockRequest(
		/* [in] */ DWORD dwOptions);

	STDMETHODIMP UnlockRequest();

	//IInternetProtocolEx
    STDMETHODIMP StartEx(
        /* [in] */ IUri *pUri,
        /* [in] */ IInternetProtocolSink *pOIProtSink,
        /* [in] */ IInternetBindInfo *pOIBindInfo,
        /* [in] */ DWORD grfPI,
        /* [in] */ HANDLE_PTR dwReserved);

	// IInternetProtocolInfo
	STDMETHODIMP ParseUrl(
		/* [in] */ LPCWSTR pwzUrl,
		/* [in] */ PARSEACTION ParseAction,
		/* [in] */ DWORD dwParseFlags,
		/* [out] */ LPWSTR pwzResult,
		/* [in] */ DWORD cchResult,
		/* [out] */ DWORD *pcchResult,
		/* [in] */ DWORD dwReserved);

	STDMETHODIMP CombineUrl(
		/* [in] */ LPCWSTR pwzBaseUrl,
		/* [in] */ LPCWSTR pwzRelativeUrl,
		/* [in] */ DWORD dwCombineFlags,
		/* [out] */ LPWSTR pwzResult,
		/* [in] */ DWORD cchResult,
		/* [out] */ DWORD *pcchResult,
		/* [in] */ DWORD dwReserved);

	STDMETHODIMP CompareUrl(
		/* [in] */ LPCWSTR pwzUrl1,
		/* [in] */ LPCWSTR pwzUrl2,
		/* [in] */ DWORD dwCompareFlags);

	STDMETHODIMP QueryInfo(
		/* [in] */ LPCWSTR pwzUrl,
		/* [in] */ QUERYOPTION QueryOption,
		/* [in] */ DWORD dwQueryFlags,
		/* [in, out] */ LPVOID pBuffer,
		/* [in] */ DWORD cbBuffer,
		/* [in, out] */ DWORD *pcbBuf,
		/* [in] */ DWORD dwReserved);

	// IInternetPriority
	STDMETHODIMP SetPriority(
		/* [in] */ LONG nPriority);

	STDMETHODIMP GetPriority(
		/* [out] */ LONG *pnPriority);

	// IInternetThreadSwitch
	STDMETHODIMP Prepare();

	STDMETHODIMP Continue();

	// IWinInetInfo
	STDMETHODIMP QueryOption(
		/* [in] */ DWORD dwOption,
		/* [in, out] */ LPVOID pBuffer,
		/* [in, out] */ DWORD *pcbBuf);

	// IWinInetHttpInfo
	STDMETHODIMP QueryInfo(
		/* [in] */ DWORD dwOption,
		/* [in, out] */ LPVOID pBuffer,
		/* [in, out] */ DWORD *pcbBuf,
		/* [in, out] */ DWORD *pdwFlags,
		/* [in, out] */ DWORD *pdwReserved);

public:
	CComPtr<IUnknown>				m_spInternetProtocolUnk;
	CComPtr<IInternetProtocol>		m_spInternetProtocol; //Original protocol handler
	CComPtr<IInternetProtocolEx>	m_spInternetProtocolEx;
	CComPtr<IInternetProtocolInfo>	m_spInternetProtocolInfo;
	CComPtr<IInternetPriority>		m_spInternetPriority;
	CComPtr<IInternetThreadSwitch>	m_spInternetThreadSwitch;
	CComPtr<IWinInetInfo>			m_spWinInetInfo;
	CComPtr<IWinInetHttpInfo>		m_spWinInetHttpInfo;
	CComPtr<IInternetProtocolSink>	m_spInternetProtocolSink;
	//CComPtr<IInternetBindInfo>	m_spInternetBindInfo;
	//CComPtr<IServiceProvider>		m_spServiceProvider;

private:
	////////////
	//Utilities
	////////////

	HWND RetreiveIEServerHwnd(IInternetProtocolSink *pOIProtSink)
	{
		HWND hwnd = NULL;
		CComPtr<IWindowForBindingUI> objWindowForBindingUI;
		HRESULT hr = IUnknown_QueryService(pOIProtSink, 
			IID_IWindowForBindingUI, IID_IWindowForBindingUI, (void**)&objWindowForBindingUI);
		if( (SUCCEEDED(hr)) && (objWindowForBindingUI) )
		{
			//Should return InternetExplorerServer HWND
			objWindowForBindingUI->GetWindow(IID_IHttpSecurity, &hwnd);
		}
		return hwnd;
	}

	void PerformClientHandled(LPCWSTR szUrl)
	{
		//Report 1 finding resource
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_FINDINGRESOURCE, szUrl);
		//Report 2 Connecting
		m_spInternetProtocolSink->ReportProgress(BINDSTATUS_CONNECTING, szUrl);

		//Synch download? mainly for binary data types, pdb, dll, swf,...
		if(m_isAsynch == VARIANT_FALSE)
		{
			USES_CONVERSION;
			//Report MIME available
			ATLTRACE(_T("CManagedAppBridge-Start-ReportProgress-BINDSTATUS_MIMETYPEAVAILABLE=%s\n"), OLE2T(m_spMimeType));
			m_spInternetProtocolSink->ReportProgress(
				BINDSTATUS_MIMETYPEAVAILABLE, m_spMimeType); //L"application/x-msdownload");

			//Report filename if a filename was requested
			if((m_NeedFileName == VARIANT_TRUE) && (m_CacheFileName.Length() > 0) )
			{
				ATLTRACE(_T("CManagedAppBridge-Start-ReportProgress-BINDSTATUS_CACHEFILENAMEAVAILABLE=%s\n"), OLE2T(m_CacheFileName));
				m_spInternetProtocolSink->ReportProgress(
					BINDSTATUS_CACHEFILENAMEAVAILABLE, m_CacheFileName);
			}

			//Report data fully available
			ATLTRACE(_T("CManagedAppBridge-Start-ReportData-BSCF_DATAFULLYAVAILABLE-Size=%8d\n"), m_dwDataLength);
			m_spInternetProtocolSink->ReportData(
				BSCF_DATAFULLYAVAILABLE, m_dwDataLength, m_dwDataLength);

			//HTTP_STATUS_OK
			ATLTRACE(_T("CManagedAppBridge-Start-ReportResult-S_OK\n"));
			m_spInternetProtocolSink->ReportResult(S_OK, 200, 0);
		}
	}

	void RetreiveRequestHeaders(IInternetProtocolSink *pOIProtSink, LPCWSTR szUrl)
	{
		//Attempt to grab the request headers
		CComPtr<IHttpNegotiate> pHttpNeg;
		HRESULT hr = IUnknown_QueryService(pOIProtSink, 
				IID_IHttpNegotiate, IID_IHttpNegotiate, (void**)&pHttpNeg);
		if( (SUCCEEDED(hr)) && (pHttpNeg) )
		{
			LPWSTR pwzAddHeaders = NULL;
			hr = pHttpNeg->BeginningTransaction(szUrl, NULL, NULL, &pwzAddHeaders);
			// pwzAddHeaders now contains headers.
			// The headers have the same form as they
			// would in an HTTP request. That is, of the form: 
			// "Header-Name: Header-Value\r\n2nd-Header-Name: 2nd-Header-Value\r\n"
			// and so on.
			if( (SUCCEEDED(hr)) && (pwzAddHeaders) )
			{
				m_spRequestHeaders.Empty();
				m_spRequestHeaders = pwzAddHeaders;
				CoTaskMemFree((LPVOID)pwzAddHeaders);
			}
		}
	}

	static const int kReadAheadAmount = 16 * 1024;
	void RetreivePostData(IInternetBindInfo *pOIBindInfo)
	{
		//Attempt to get post data if this is a post
		BINDINFO m_bindinfo;
		void *pData = 0;
		UINT cPostData = 0;	// Post data size.

		m_bindinfo.cbSize = sizeof(BINDINFO);
		HRESULT hr = pOIBindInfo->GetBindInfo(&m_bindf, &m_bindinfo);
		
		ATLTRACE(_T("CManagedAppBridge-RetreivePostData-Checking for post flag-url=%s\n"),m_lpOriUrl);
		switch (m_bindinfo.dwBindVerb)
		{
/*
m_stPostData = new WBStream();
m_stPostData->InitWBStreamData(iID, pHost, this, URL, m_lpBuffer, m_ulDataSize);
	// Fill the STGMEDIUM with the data to post:
	//IE uses TYMED_ISTREAM when submitting a form with <input type="file"> control
	pbindinfo->stgmedData.tymed = TYMED_ISTREAM;
	pbindinfo->stgmedData.pstm = m_stPostData;
	pbindinfo->stgmedData.pUnkForRelease = (LPUNKNOWN)(LPBINDSTATUSCALLBACK)this; //  maintain control over the data.
	pbindinfo->cbstgmedData = // this must be exact! 
		m_ulDataSize;		  // Do not rely on GlobalSize()
*/
		case BINDVERB_POST:

			//Ajax uses stream??
//if(m_bindinfo.stgmedData.tymed == TYMED_ISTREAM)
//	ATLTRACE(_T("CManagedAppBridge-Start-m_bindinfo.stgmedData.tymed == TYMED_ISTREAM-url=%s\n"),m_lpOriUrl);
			if(m_bindinfo.stgmedData.tymed == TYMED_ISTREAM){  
				/*m_spPostData.Empty();
				CComBSTR bstrStr;				
				HRESULT hr2 = bstrStr.ReadFromStream(m_bindinfo.stgmedData.pstm);
                if(FAILED(hr2)) {
					

                }
				else
					m_spPostData.AppendBSTR(bstrStr);*/

				//::ReleaseStgMedium(&m_bindinfo.stgmedData);
				////memcpy(m_spPostData, bstrStr.data, sizeof(hr));

				/*char data[16384];
				m_bindinfo.stgmedData.pstm->Read(&(*data),
											16384, 0);*/


				char data[16384];
				m_bindinfo.stgmedData.pstm->Read(&(*data),
					m_bindinfo.cbSize, 0);

				//char *data = new char[1024];
				//ULONG amount_readed_ = 0;
				//do {

				//	// Ensure our data buffer is large enough			
				//	char *save = new char[amount_readed_ + 1024];
				//	// Copy the data
				//	for ( int i = 0; i < amount_readed_; i++ )
				//	  save[i] = data[i];
				//	// Destroy the old array
				//	delete [] data;
				//	// Reset to the new array
				//	data = save;

				//	// Read into our data buffer
				//	hr = m_bindinfo.stgmedData.pstm->Read(&(*data),
				//							1024, &amount_readed_);
				//	
				//	// Change the size to match
				//	amount_readed_ = amount_readed_ + 1024;

			 // } while (!(hr == E_PENDING || hr == S_FALSE) && SUCCEEDED(hr));

				m_spPostData.Empty();
				m_spPostData.AppendBSTR(A2BSTR(data));
			}

			if (m_bindinfo.stgmedData.tymed != TYMED_HGLOBAL)
				break;
			
			cPostData = m_bindinfo.cbstgmedData;
			if (!cPostData)
				break;
			
			pData = GlobalLock(m_bindinfo.stgmedData.hGlobal);
			if (pData)
			{
				// Allocate space to store the POST data.
				//BYTE *m_postData = new BYTE[cPostData];
				//memcpy(m_postData, pData, cPostData * sizeof(BYTE));
				LPSTR str = new char[cPostData + 1];
				if(str)
				{
					memset(str, 0, cPostData+1);
					//str[cPostData] = '\0';
					memcpy((LPVOID)str, pData, cPostData * sizeof(BYTE));

					m_spPostData.Empty();
					m_spPostData.AppendBSTR(A2BSTR(str));
					delete[] str;
				}

				//unlock buffer.
				GlobalUnlock(m_bindinfo.stgmedData.hGlobal);
				
				// Retrieve MIME type of the post data.
				LPOLESTR pszMIMEType = 0;	
				ULONG dwSize = 0;
				hr = pOIBindInfo->GetBindString(
					BINDSTRING_POST_DATA_MIME, &pszMIMEType, 1, &dwSize);
				
				if(hr == S_OK)
				{
					// pszMIMEType now contains the MIME type of the post data.
					// This would typically be "application/x-www-form-urlencoded" 
					// for a POST. In general, it could be any (standard or 
					// otherwise) MIME type. Many of the standard MIME type strings 
					// are #defined in <URLMon.h>. For instance, CFSTR_MIME_TEXT 
					// is L"text/plain".
					
					// Store the MIME type.
					// Finally, free pszMIMEType via CoTaskMemFree.
					if (pszMIMEType)
					{
						m_spPostDataMimeType.Empty();
						m_spPostDataMimeType = pszMIMEType;
						CoTaskMemFree(pszMIMEType);
						pszMIMEType = NULL;
					}
				}
				//else
				//{
				//	// Assume "application/x-www-form-urlencoded".
				//	m_spPostDataMimeType.Empty();
				//	m_spPostDataMimeType = L"application/x-www-form-urlencoded";
				//}
			}
			break;
		default:
			// It's a GET.
			break;
		}
	}

	void ResetAll()
	{
		if(m_spMimeType.Length() > 0)
		{
			m_spMimeType.Empty();
			m_spMimeType = L"";
		}
		if(m_spRequestHeaders.Length() > 0)
		{
			m_spRequestHeaders.Empty();
			m_spRequestHeaders = L"";
		}
		if(m_spPostData.Length() > 0)
		{
			m_spPostData.Empty();
			m_spPostData = L"";
		}
		if(m_spPostDataMimeType.Length() > 0)
		{
			m_spPostDataMimeType.Empty();
			m_spPostDataMimeType = L"application/x-www-form-urlencoded";
		}
		//This must be a full path, not just a display name.
		if(m_CacheFileName.Length() > 0)
		{
			m_CacheFileName.Empty();
			m_CacheFileName = L"";
		}
		m_hwndIEServer = 0;
		m_pUtilMan = 0;
		if(m_pvData)
		{
			delete [] m_pvData;
			m_pvData = 0;
		}
		m_dwPos = 0;
		m_dwDataLength = 0;
		m_ClientHandled = VARIANT_FALSE;
		m_NeedFileName = VARIANT_FALSE;
		m_isAsynch = VARIANT_FALSE;
		m_bindf = 0;
		m_aborted = false;
	}
	//Generic QueryService
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

	//To clear BSTR pointer passed from client
	//before assignning a new value to them
	//Call ClearBSTRPtr(*pURL);
	void ClearBSTRPtr(BSTR& bstrText)
	{
		if (bstrText != NULL)
		{
			::SysFreeString(bstrText);
			bstrText = NULL;
		}
	}

private:
	long							m_hwndIEServer;
	LPTSTR							m_lpOriUrl;
	CComBSTR						m_spRequestHeaders;
	CComBSTR						m_spPostData;
	CComBSTR						m_spPostDataMimeType;
	CComBSTR						m_spMimeType;
	DWORD							m_dwPos;
	BYTE*							m_pvData;
	DWORD							m_dwDataLength;
	void							*m_pUtilMan;
	VARIANT_BOOL					m_ClientHandled;
	VARIANT_BOOL					m_NeedFileName;
	CComBSTR						m_CacheFileName;
	VARIANT_BOOL					m_isAsynch;
	IUri							*m_OriUri;
	DWORD							m_bindf;
	bool							m_aborted;
};

class CManagedAppBridgeSink :
	public CComObjectRootEx<CComSingleThreadModel>,
	public IInternetProtocolSink, //QI
	public IInternetBindInfo, //QI
	public IServiceProvider,
	public IHttpNegotiate
{
public:

	CManagedAppBridgeSink() { }
	~CManagedAppBridgeSink() { }

	BEGIN_COM_MAP(CManagedAppBridgeSink)
		COM_INTERFACE_ENTRY(IInternetProtocolSink)
		COM_INTERFACE_ENTRY(IInternetBindInfo)
		COM_INTERFACE_ENTRY(IServiceProvider)
		COM_INTERFACE_ENTRY(IHttpNegotiate)
	END_COM_MAP()

	HRESULT QueryServiceFromClient(REFGUID guidService, REFIID riid, void** ppvObject)
	{
		HRESULT hr = S_OK;
		CComPtr<IServiceProvider> spClientProvider = m_spServiceProvider;
		if (!spClientProvider)
		{
			hr = m_spInternetProtocolSink->QueryInterface(&spClientProvider);
			ATLASSERT(SUCCEEDED(hr) && spClientProvider != 0);
		}
		if (SUCCEEDED(hr))
		{
			hr = spClientProvider->QueryService(guidService, riid, ppvObject);
		}
		return hr;
	}

	template <class Q>
	HRESULT QueryServiceFromClient(REFGUID guidService, Q** pp)
	{
		return QueryServiceFromClient(guidService, _ATL_IIDOF(Q),
			reinterpret_cast<void**>(pp));
	}
	template <class Q>
	HRESULT QueryServiceFromClient(Q** pp)
	{
		return QueryServiceFromClient(_ATL_IIDOF(Q), _ATL_IIDOF(Q),
			reinterpret_cast<void**>(pp));
	}

public:
	HRESULT SetTargetInterfaces(LPTSTR szUrl, IInternetProtocolSink *pOIProtSink, 
		IInternetBindInfo *pOIBindInfo, IInternetProtocol* pTargetProtocol, void *pEvent, HWND hwndIE);

	// IInternetProtocolSink
	STDMETHODIMP Switch(
		/* [in] */ PROTOCOLDATA *pProtocolData);

	STDMETHODIMP ReportProgress(
		/* [in] */ ULONG ulStatusCode,
		/* [in] */ LPCWSTR szStatusText);

	STDMETHODIMP ReportData(
		/* [in] */ DWORD grfBSCF,
		/* [in] */ ULONG ulProgress,
		/* [in] */ ULONG ulProgressMax);

	STDMETHODIMP ReportResult(
		/* [in] */ HRESULT hrResult,
		/* [in] */ DWORD dwError,
		/* [in] */ LPCWSTR szResult);

	// IInternetBindInfo
	STDMETHODIMP GetBindInfo(
		/* [out] */ DWORD *grfBINDF,
		/* [in, out] */ BINDINFO *pbindinfo);

	STDMETHODIMP GetBindString(
		/* [in] */ ULONG ulStringType,
		/* [in, out] */ LPOLESTR *ppwzStr,
		/* [in] */ ULONG cEl,
		/* [in, out] */ ULONG *pcElFetched);

	//IServiceProvider
	STDMETHODIMP QueryService(REFGUID guidService, REFIID riid, void** ppv);

	HRESULT _InternalQueryService(REFGUID guidService, REFIID riid, void** ppvObject);

	// IHttpNegotiate
	STDMETHODIMP BeginningTransaction(
		/* [in] */ LPCWSTR szURL,
		/* [in] */ LPCWSTR szHeaders,
		/* [in] */ DWORD dwReserved,
		/* [out] */ LPWSTR *pszAdditionalHeaders);

	STDMETHODIMP OnResponse(
		/* [in] */ DWORD dwResponseCode,
		/* [in] */ LPCWSTR szResponseHeaders,
		/* [in] */ LPCWSTR szRequestHeaders,
		/* [out] */ LPWSTR *pszAdditionalRequestHeaders);
public:
	CComPtr<IInternetProtocolSink>	m_spInternetProtocolSink;
	CComPtr<IInternetBindInfo>		m_spInternetBindInfo;
	CComPtr<IServiceProvider>		m_spServiceProvider;

	CComPtr<IInternetProtocol>		m_spTargetProtocol;
private:
	LPTSTR							m_lpOriUrl;
	CComBSTR						m_strUrl;
	CComBSTR						m_strRedirUrl;
	CComBSTR						m_strRedirHeaders;
	void							*m_pEvents;
	HWND							m_hwndIEServer;
};


OBJECT_ENTRY_AUTO(__uuidof(ManagedAppBridge), CManagedAppBridge)
