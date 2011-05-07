// UtilMan.h : Declaration of the CUtilMan

#pragma once
#include "resource.h"       // main symbols

#include "ComUtilities.h"
#include "_IUtilManEvents_CP.h"

#include <WinUser.h>
#include "TmpBuffer.h"
#include "UrlParts.h" //Requires wininet.lib
#include <urlmon.h> //Requires Urlmon.lib

//To use std string instead of CTmpBuffer, uncomment
//#include <string>
//typedef std::basic_string<TCHAR> tstring;

class WBBSCBFileDL;

#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

// CUtilMan

class ATL_NO_VTABLE CUtilMan :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CUtilMan, &CLSID_UtilMan>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CUtilMan>,
	public CProxy_IUtilManEvents<CUtilMan>,
	public IDispatchImpl<IUtilMan, &IID_IUtilMan, &LIBID_ComUtilitiesLib, /*wMajor =*/ 1, /*wMinor =*/ 0>,
	public IDownloadManager,
	public IDispatchImpl<_IUtilManEvents, &__uuidof(_IUtilManEvents), &LIBID_ComUtilitiesLib, /* wMajor = */ 1, /* wMinor = */ 0>
{
public:
	CUtilMan();
	~CUtilMan();

	DECLARE_REGISTRY_RESOURCEID(IDR_UTILMAN)


	BEGIN_COM_MAP(CUtilMan)
		COM_INTERFACE_ENTRY(IUtilMan)
		COM_INTERFACE_ENTRY(ISupportErrorInfo)
		COM_INTERFACE_ENTRY(IConnectionPointContainer)
		COM_INTERFACE_ENTRY(IDownloadManager) //Added
		COM_INTERFACE_ENTRY(_IUtilManEvents)
	END_COM_MAP()

	BEGIN_CONNECTION_POINT_MAP(CUtilMan)
		CONNECTION_POINT_ENTRY(__uuidof(_IUtilManEvents))
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

	STDMETHOD(Download)(IMoniker *pmk,IBindCtx *pbc,DWORD dwBindVerb,
		LONG grfBINDF,
		BINDINFO *pBindInfo,
		LPCOLESTR pszHeaders,
		LPCOLESTR pszRedir,
		UINT uiCP);

	HWND m_IEServerHwnd;
	STDMETHOD(get_HWNDInternetExplorerServer)(LONG* pVal);
	STDMETHOD(put_HWNDInternetExplorerServer)(LONG newVal);
	BOOL RemoveBSCBFromDLArr(long Uid);
	STDMETHOD(HookProcNCode)(/*[in]*/ WINDOWSHOOK_TYPES lHookType, /*[in,out]*/ long *nCode);
	STDMETHOD(SetupWindowsHook)(/*[in]*/ WINDOWSHOOK_TYPES lHookType, /*[in]*/ long hwndTargetWnd , /*[in]*/ VARIANT_BOOL bStart, /*[in,out]*/ long *lUWMHookMsgID);
	STDMETHOD(CancelFileDownload)(long DlUid);
	STDMETHOD(DownloadUrlAsync)(BSTR URL, long *DLUID);
	STDMETHOD(get_HTTPprotocolManaged)(/*[out, retval]*/ VARIANT_BOOL *pVal);
	STDMETHOD(put_HTTPprotocolManaged)(/*[in]*/ VARIANT_BOOL newVal);
	STDMETHOD(get_HTTPSprotocolManaged)(/*[out, retval]*/ VARIANT_BOOL *pVal);
	STDMETHOD(put_HTTPSprotocolManaged)(/*[in]*/ VARIANT_BOOL newVal);

private:
	HRESULT CancelFileDl(long Uid);
	HRESULT WBCreateBSCBFileDL(WBBSCBFileDL **ppTargetBSCBFileDL);
	long m_Uid;
	//Array of BindStatusCallBacks for file downloads
	//Used from client side to abort timed out dls, ...
	CSimpleArray<WBBSCBFileDL*> m_arrDL;

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

public:
	STDMETHOD(GetScriptObjects)(IDispatch* ScriptDispatch, BSTR* strObjects);
};

///////////////////////////////////////////////////////////////////////
///////////A simple download manager with resume capabilities
////////////////////////////////////////////////////////////////////////
class WBBSCBFileDL : 
		public IBindStatusCallback, 
		public IHttpNegotiate,
		public IAuthenticate
{
public:
	WBBSCBFileDL();
	~WBBSCBFileDL();

    // IUnknown
    ULONG STDMETHODCALLTYPE AddRef();
    ULONG STDMETHODCALLTYPE Release();
    STDMETHODIMP QueryInterface(REFIID iid, void ** ppvObject);

	//IBindStatusCallback
    STDMETHODIMP OnStartBinding(DWORD dwReserved, IBinding * pib);
    STDMETHODIMP GetPriority(LONG * pnPriority);
    STDMETHODIMP OnLowResource(DWORD reserved);
    STDMETHODIMP OnProgress(ULONG ulProgress, ULONG ulProgressMax, ULONG ulStatusCode, LPCWSTR szStatusText);
    STDMETHODIMP OnStopBinding(HRESULT hresult,LPCWSTR szError);
    STDMETHODIMP GetBindInfo(DWORD *grfBINDF, BINDINFO * pbindinfo);
    STDMETHODIMP OnDataAvailable(DWORD grfBSCF, DWORD dwSize, FORMATETC* pformatetc, STGMEDIUM* pstgmed);
    STDMETHODIMP OnObjectAvailable(REFIID riid,IUnknown* punk);

	// IHttpNegotiate methods
    STDMETHODIMP BeginningTransaction(
                LPCWSTR szURL,
                LPCWSTR szHeaders,
                DWORD dwReserved,
                LPWSTR *pszAdditionalHeaders);

    STDMETHODIMP OnResponse(
                DWORD dwResponseCode,
                LPCWSTR szResponseHeaders,
                LPCWSTR szRequestHeaders,
                LPWSTR *pszAdditionalRequestHeaders);

	// IAuthenticate
	
	//Returns one of the following values:;
	//S_OK Authentication was successful. 
	//E_ACCESSDENIED Authentication failed. 
	//E_INVALIDARG One or more parameters are invalid.
	//Currently, the user name and password options handle only
	//the Basic authentication scheme and N..
	STDMETHODIMP Authenticate(HWND *phwnd, LPWSTR *pszUsername, LPWSTR *pszPassword);

	//Class specific
	bool InitByClient(long uID, CUtilMan *EventsPtr, BSTR lpUrl, HWND client);
	bool InitByUser(long uID, CUtilMan *pHost, LPCOLESTR UrlMonExtraHeaders, HWND client);

	bool CancelDL(void);
	bool IsDownloading(void);

	//Previous BSCB before we used RegisterBindStatuscallback
	IBindStatusCallback *m_pPrevBSCB;
	IBindCtx			*m_pBindCtx;
	long				m_Uid;

private:
	ULONG				m_cRef;
	BOOL				m_fRedirect; // need to be informed when we're being redirected by the server


	IBinding			*m_pBinding;
	LPSTREAM			m_pstm;
	//Path with backslash m_bstr
	CComBSTR			fPathToSave;
	//File name
	CComBSTR			fFileName; //filename.zip
	CComBSTR			fFileExt; //.zip
	CComBSTR			fFileSize; //in bytes
	//Contains URL
	//This can change if we receive a redirect in onprogress
	CComBSTR			fUrl;
	CComBSTR			m_strRedirectedURL;
	CComBSTR			m_strDLManExtraHeaders;
	//This is the full path (Path+filename) of save target file
	//If we receive a redirect in BeginningTranscaction, URL will change
	CComBSTR			fFullSavePath;
	//To write to file
	DWORD				m_cbOld;
	HANDLE				hFile;
	//This flag is used to send/not progress events
	//decided to have it to avoid unnecessary events fired
	//when client does not care to have them
	VARIANT_BOOL		m_SendProgressEvent;
	//To relay events
	CUtilMan			*m_Events;
	//To make sure we have a client to send info to
	//This is needed since we can end our app while URLMon
	//is using this class to continue download. Independent of
	//our app. Cool.
	HWND				m_hwndEvents;
	//To get client return value for Cancel
	VARIANT_BOOL		m_vboolCancelDL;
	VARIANT_BOOL		m_vboolResuming;
	BOOL				m_bCancelled;
	HWND				m_hwndClient;
	//To reset internal vars since we are reusing this class
	void ResetInternalVars(void);
};


OBJECT_ENTRY_AUTO(__uuidof(UtilMan), CUtilMan)
