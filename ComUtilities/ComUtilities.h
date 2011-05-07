

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Tue Jul 27 21:19:46 2010
 */
/* Compiler settings for ComUtilities.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __ComUtilities_h__
#define __ComUtilities_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IDownloadManager_FWD_DEFINED__
#define __IDownloadManager_FWD_DEFINED__
typedef interface IDownloadManager IDownloadManager;
#endif 	/* __IDownloadManager_FWD_DEFINED__ */


#ifndef __IUtilMan_FWD_DEFINED__
#define __IUtilMan_FWD_DEFINED__
typedef interface IUtilMan IUtilMan;
#endif 	/* __IUtilMan_FWD_DEFINED__ */


#ifndef __IManagedAppBridge_FWD_DEFINED__
#define __IManagedAppBridge_FWD_DEFINED__
typedef interface IManagedAppBridge IManagedAppBridge;
#endif 	/* __IManagedAppBridge_FWD_DEFINED__ */


#ifndef __ICustManageApp_FWD_DEFINED__
#define __ICustManageApp_FWD_DEFINED__
typedef interface ICustManageApp ICustManageApp;
#endif 	/* __ICustManageApp_FWD_DEFINED__ */


#ifndef ___IUtilManEvents_FWD_DEFINED__
#define ___IUtilManEvents_FWD_DEFINED__
typedef interface _IUtilManEvents _IUtilManEvents;
#endif 	/* ___IUtilManEvents_FWD_DEFINED__ */


#ifndef __UtilMan_FWD_DEFINED__
#define __UtilMan_FWD_DEFINED__

#ifdef __cplusplus
typedef class UtilMan UtilMan;
#else
typedef struct UtilMan UtilMan;
#endif /* __cplusplus */

#endif 	/* __UtilMan_FWD_DEFINED__ */


#ifndef ___IManagedAppBridgeEvents_FWD_DEFINED__
#define ___IManagedAppBridgeEvents_FWD_DEFINED__
typedef interface _IManagedAppBridgeEvents _IManagedAppBridgeEvents;
#endif 	/* ___IManagedAppBridgeEvents_FWD_DEFINED__ */


#ifndef __ManagedAppBridge_FWD_DEFINED__
#define __ManagedAppBridge_FWD_DEFINED__

#ifdef __cplusplus
typedef class ManagedAppBridge ManagedAppBridge;
#else
typedef struct ManagedAppBridge ManagedAppBridge;
#endif /* __cplusplus */

#endif 	/* __ManagedAppBridge_FWD_DEFINED__ */


#ifndef ___ICustManageAppEvents_FWD_DEFINED__
#define ___ICustManageAppEvents_FWD_DEFINED__
typedef interface _ICustManageAppEvents _ICustManageAppEvents;
#endif 	/* ___ICustManageAppEvents_FWD_DEFINED__ */


#ifndef __CustManageApp_FWD_DEFINED__
#define __CustManageApp_FWD_DEFINED__

#ifdef __cplusplus
typedef class CustManageApp CustManageApp;
#else
typedef struct CustManageApp CustManageApp;
#endif /* __cplusplus */

#endif 	/* __CustManageApp_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IDownloadManager_INTERFACE_DEFINED__
#define __IDownloadManager_INTERFACE_DEFINED__

/* interface IDownloadManager */
/* [local][unique][uuid][object][helpstring] */ 


EXTERN_C const IID IID_IDownloadManager;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("988934A4-064B-11D3-BB80-00104B35E7F9")
    IDownloadManager : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Download( 
            /* [in] */ IMoniker *pmk,
            /* [in] */ IBindCtx *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IDownloadManagerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDownloadManager * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDownloadManager * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDownloadManager * This);
        
        HRESULT ( STDMETHODCALLTYPE *Download )( 
            IDownloadManager * This,
            /* [in] */ IMoniker *pmk,
            /* [in] */ IBindCtx *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP);
        
        END_INTERFACE
    } IDownloadManagerVtbl;

    interface IDownloadManager
    {
        CONST_VTBL struct IDownloadManagerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDownloadManager_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IDownloadManager_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IDownloadManager_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IDownloadManager_Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP)	\
    ( (This)->lpVtbl -> Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDownloadManager_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_ComUtilities_0000_0001 */
/* [local] */ 

typedef 
enum WINDOWSHOOK_TYPES
    {	WHT_CALLWNDPROC	= 0,
	WHT_CBT	= 1,
	WHT_GETMESSAGE	= 2,
	WHT_KEYBOARD	= 3,
	WHT_MOUSE	= 4,
	WHT_MSGFILTER	= 5,
	WHT_KEYBOARD_LL	= 6,
	WHT_MOUSE_LL	= 7,
	WHT_FOREGROUNDIDLE	= 8,
	WHT_CALLWNDPROCRET	= 9,
	WHT_SYSMSGFILTER	= 10,
	WHT_SHELL	= 11
    } 	WINDOWSHOOK_TYPES;



extern RPC_IF_HANDLE __MIDL_itf_ComUtilities_0000_0001_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_ComUtilities_0000_0001_v0_0_s_ifspec;

#ifndef __IUtilMan_INTERFACE_DEFINED__
#define __IUtilMan_INTERFACE_DEFINED__

/* interface IUtilMan */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IUtilMan;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD264321-7025-476C-8B7A-850E0B79DD41")
    IUtilMan : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HWNDInternetExplorerServer( 
            /* [retval][out] */ LONG *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HWNDInternetExplorerServer( 
            /* [in] */ LONG newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE HookProcNCode( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long *nCode) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SetupWindowsHook( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long *lUWMHookMsgID) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CancelFileDownload( 
            /* [in] */ long DlUid) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadUrlAsync( 
            /* [in] */ BSTR URL,
            /* [out][in] */ long *DLUID) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPSprotocolManaged( 
            /* [retval][out] */ VARIANT_BOOL *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPSprotocolManaged( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPprotocolManaged( 
            /* [retval][out] */ VARIANT_BOOL *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPprotocolManaged( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetScriptObjects( 
            /* [in] */ IDispatch *ScriptDispatch,
            /* [out][in] */ BSTR *strObjects) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IUtilManVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IUtilMan * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IUtilMan * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IUtilMan * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IUtilMan * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IUtilMan * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IUtilMan * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IUtilMan * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HWNDInternetExplorerServer )( 
            IUtilMan * This,
            /* [retval][out] */ LONG *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HWNDInternetExplorerServer )( 
            IUtilMan * This,
            /* [in] */ LONG newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HookProcNCode )( 
            IUtilMan * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long *nCode);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SetupWindowsHook )( 
            IUtilMan * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long *lUWMHookMsgID);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CancelFileDownload )( 
            IUtilMan * This,
            /* [in] */ long DlUid);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadUrlAsync )( 
            IUtilMan * This,
            /* [in] */ BSTR URL,
            /* [out][in] */ long *DLUID);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HTTPSprotocolManaged )( 
            IUtilMan * This,
            /* [retval][out] */ VARIANT_BOOL *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HTTPSprotocolManaged )( 
            IUtilMan * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HTTPprotocolManaged )( 
            IUtilMan * This,
            /* [retval][out] */ VARIANT_BOOL *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HTTPprotocolManaged )( 
            IUtilMan * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetScriptObjects )( 
            IUtilMan * This,
            /* [in] */ IDispatch *ScriptDispatch,
            /* [out][in] */ BSTR *strObjects);
        
        END_INTERFACE
    } IUtilManVtbl;

    interface IUtilMan
    {
        CONST_VTBL struct IUtilManVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IUtilMan_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IUtilMan_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IUtilMan_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IUtilMan_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IUtilMan_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IUtilMan_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IUtilMan_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IUtilMan_get_HWNDInternetExplorerServer(This,pVal)	\
    ( (This)->lpVtbl -> get_HWNDInternetExplorerServer(This,pVal) ) 

#define IUtilMan_put_HWNDInternetExplorerServer(This,newVal)	\
    ( (This)->lpVtbl -> put_HWNDInternetExplorerServer(This,newVal) ) 

#define IUtilMan_HookProcNCode(This,lHookType,nCode)	\
    ( (This)->lpVtbl -> HookProcNCode(This,lHookType,nCode) ) 

#define IUtilMan_SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID)	\
    ( (This)->lpVtbl -> SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID) ) 

#define IUtilMan_CancelFileDownload(This,DlUid)	\
    ( (This)->lpVtbl -> CancelFileDownload(This,DlUid) ) 

#define IUtilMan_DownloadUrlAsync(This,URL,DLUID)	\
    ( (This)->lpVtbl -> DownloadUrlAsync(This,URL,DLUID) ) 

#define IUtilMan_get_HTTPSprotocolManaged(This,pVal)	\
    ( (This)->lpVtbl -> get_HTTPSprotocolManaged(This,pVal) ) 

#define IUtilMan_put_HTTPSprotocolManaged(This,newVal)	\
    ( (This)->lpVtbl -> put_HTTPSprotocolManaged(This,newVal) ) 

#define IUtilMan_get_HTTPprotocolManaged(This,pVal)	\
    ( (This)->lpVtbl -> get_HTTPprotocolManaged(This,pVal) ) 

#define IUtilMan_put_HTTPprotocolManaged(This,newVal)	\
    ( (This)->lpVtbl -> put_HTTPprotocolManaged(This,newVal) ) 

#define IUtilMan_GetScriptObjects(This,ScriptDispatch,strObjects)	\
    ( (This)->lpVtbl -> GetScriptObjects(This,ScriptDispatch,strObjects) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IUtilMan_INTERFACE_DEFINED__ */


#ifndef __IManagedAppBridge_INTERFACE_DEFINED__
#define __IManagedAppBridge_INTERFACE_DEFINED__

/* interface IManagedAppBridge */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IManagedAppBridge;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EF49428E-8C06-4412-8F64-1CF796F0BEDF")
    IManagedAppBridge : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadCompleteManaged( 
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ VARIANT *data,
            /* [in] */ long dataLength) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadAbortManaged( 
            /* [in] */ long InetErrorCode) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_IEServerHwnd( 
            /* [retval][out] */ LONG *pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_URL( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_URL( 
            /* [in] */ BSTR pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_RequestHeaders( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_PostData( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_PostDataMimeType( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_DownloadData( 
            /* [in] */ VARIANT newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_DataMimeType( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_DataMimeType( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_DownloadCacheFileName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_DownloadCacheFileName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadCompleteManagedCache( 
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ BSTR sCacheFileName) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IManagedAppBridgeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IManagedAppBridge * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IManagedAppBridge * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IManagedAppBridge * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IManagedAppBridge * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IManagedAppBridge * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IManagedAppBridge * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IManagedAppBridge * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadCompleteManaged )( 
            IManagedAppBridge * This,
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ VARIANT *data,
            /* [in] */ long dataLength);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadAbortManaged )( 
            IManagedAppBridge * This,
            /* [in] */ long InetErrorCode);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_IEServerHwnd )( 
            IManagedAppBridge * This,
            /* [retval][out] */ LONG *pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_URL )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_URL )( 
            IManagedAppBridge * This,
            /* [in] */ BSTR pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_RequestHeaders )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_PostData )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_PostDataMimeType )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_DownloadData )( 
            IManagedAppBridge * This,
            /* [in] */ VARIANT newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_DataMimeType )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_DataMimeType )( 
            IManagedAppBridge * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_DownloadCacheFileName )( 
            IManagedAppBridge * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_DownloadCacheFileName )( 
            IManagedAppBridge * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadCompleteManagedCache )( 
            IManagedAppBridge * This,
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ BSTR sCacheFileName);
        
        END_INTERFACE
    } IManagedAppBridgeVtbl;

    interface IManagedAppBridge
    {
        CONST_VTBL struct IManagedAppBridgeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IManagedAppBridge_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IManagedAppBridge_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IManagedAppBridge_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IManagedAppBridge_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IManagedAppBridge_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IManagedAppBridge_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IManagedAppBridge_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IManagedAppBridge_DownloadCompleteManaged(This,sUrl,sMime,data,dataLength)	\
    ( (This)->lpVtbl -> DownloadCompleteManaged(This,sUrl,sMime,data,dataLength) ) 

#define IManagedAppBridge_DownloadAbortManaged(This,InetErrorCode)	\
    ( (This)->lpVtbl -> DownloadAbortManaged(This,InetErrorCode) ) 

#define IManagedAppBridge_get_IEServerHwnd(This,pVal)	\
    ( (This)->lpVtbl -> get_IEServerHwnd(This,pVal) ) 

#define IManagedAppBridge_get_URL(This,pVal)	\
    ( (This)->lpVtbl -> get_URL(This,pVal) ) 

#define IManagedAppBridge_put_URL(This,pVal)	\
    ( (This)->lpVtbl -> put_URL(This,pVal) ) 

#define IManagedAppBridge_get_RequestHeaders(This,pVal)	\
    ( (This)->lpVtbl -> get_RequestHeaders(This,pVal) ) 

#define IManagedAppBridge_get_PostData(This,pVal)	\
    ( (This)->lpVtbl -> get_PostData(This,pVal) ) 

#define IManagedAppBridge_get_PostDataMimeType(This,pVal)	\
    ( (This)->lpVtbl -> get_PostDataMimeType(This,pVal) ) 

#define IManagedAppBridge_put_DownloadData(This,newVal)	\
    ( (This)->lpVtbl -> put_DownloadData(This,newVal) ) 

#define IManagedAppBridge_get_DataMimeType(This,pVal)	\
    ( (This)->lpVtbl -> get_DataMimeType(This,pVal) ) 

#define IManagedAppBridge_put_DataMimeType(This,newVal)	\
    ( (This)->lpVtbl -> put_DataMimeType(This,newVal) ) 

#define IManagedAppBridge_get_DownloadCacheFileName(This,pVal)	\
    ( (This)->lpVtbl -> get_DownloadCacheFileName(This,pVal) ) 

#define IManagedAppBridge_put_DownloadCacheFileName(This,newVal)	\
    ( (This)->lpVtbl -> put_DownloadCacheFileName(This,newVal) ) 

#define IManagedAppBridge_DownloadCompleteManagedCache(This,sUrl,sMime,sCacheFileName)	\
    ( (This)->lpVtbl -> DownloadCompleteManagedCache(This,sUrl,sMime,sCacheFileName) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IManagedAppBridge_INTERFACE_DEFINED__ */


#ifndef __ICustManageApp_INTERFACE_DEFINED__
#define __ICustManageApp_INTERFACE_DEFINED__

/* interface ICustManageApp */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ICustManageApp;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C43E6EBA-1999-4089-B9EF-EAC44D4ED625")
    ICustManageApp : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadCompleteCustomApp( 
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ VARIANT *data,
            /* [in] */ long dataLength) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadAbortCustomApp( 
            /* [in] */ long InetErrorCode) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICustManageAppVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICustManageApp * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICustManageApp * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICustManageApp * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ICustManageApp * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ICustManageApp * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ICustManageApp * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICustManageApp * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadCompleteCustomApp )( 
            ICustManageApp * This,
            /* [in] */ BSTR sUrl,
            /* [in] */ BSTR sMime,
            /* [in] */ VARIANT *data,
            /* [in] */ long dataLength);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadAbortCustomApp )( 
            ICustManageApp * This,
            /* [in] */ long InetErrorCode);
        
        END_INTERFACE
    } ICustManageAppVtbl;

    interface ICustManageApp
    {
        CONST_VTBL struct ICustManageAppVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICustManageApp_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICustManageApp_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICustManageApp_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICustManageApp_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ICustManageApp_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ICustManageApp_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ICustManageApp_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define ICustManageApp_DownloadCompleteCustomApp(This,sUrl,sMime,data,dataLength)	\
    ( (This)->lpVtbl -> DownloadCompleteCustomApp(This,sUrl,sMime,data,dataLength) ) 

#define ICustManageApp_DownloadAbortCustomApp(This,InetErrorCode)	\
    ( (This)->lpVtbl -> DownloadAbortCustomApp(This,InetErrorCode) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICustManageApp_INTERFACE_DEFINED__ */



#ifndef __ComUtilitiesLib_LIBRARY_DEFINED__
#define __ComUtilitiesLib_LIBRARY_DEFINED__

/* library ComUtilitiesLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ComUtilitiesLib;

#ifndef ___IUtilManEvents_DISPINTERFACE_DEFINED__
#define ___IUtilManEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IUtilManEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IUtilManEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D6B43A79-C0FC-4E85-8BB4-6235B81C6CBF")
    _IUtilManEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IUtilManEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IUtilManEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IUtilManEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IUtilManEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IUtilManEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IUtilManEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IUtilManEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IUtilManEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IUtilManEventsVtbl;

    interface _IUtilManEvents
    {
        CONST_VTBL struct _IUtilManEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IUtilManEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IUtilManEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IUtilManEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IUtilManEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IUtilManEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IUtilManEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IUtilManEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IUtilManEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_UtilMan;

#ifdef __cplusplus

class DECLSPEC_UUID("98EDB477-3064-4D0E-A09E-CC73F9AAB324")
UtilMan;
#endif

#ifndef ___IManagedAppBridgeEvents_DISPINTERFACE_DEFINED__
#define ___IManagedAppBridgeEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IManagedAppBridgeEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IManagedAppBridgeEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("2639DA95-E95D-48B8-A379-083D2FA3E9BC")
    _IManagedAppBridgeEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IManagedAppBridgeEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IManagedAppBridgeEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IManagedAppBridgeEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IManagedAppBridgeEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IManagedAppBridgeEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IManagedAppBridgeEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IManagedAppBridgeEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IManagedAppBridgeEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _IManagedAppBridgeEventsVtbl;

    interface _IManagedAppBridgeEvents
    {
        CONST_VTBL struct _IManagedAppBridgeEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IManagedAppBridgeEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IManagedAppBridgeEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IManagedAppBridgeEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IManagedAppBridgeEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IManagedAppBridgeEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IManagedAppBridgeEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IManagedAppBridgeEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IManagedAppBridgeEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_ManagedAppBridge;

#ifdef __cplusplus

class DECLSPEC_UUID("2E9178C0-D804-4A93-B55D-3FFF54B95FF1")
ManagedAppBridge;
#endif

#ifndef ___ICustManageAppEvents_DISPINTERFACE_DEFINED__
#define ___ICustManageAppEvents_DISPINTERFACE_DEFINED__

/* dispinterface _ICustManageAppEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__ICustManageAppEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("B6C355FD-215E-40A6-92C5-564619B1FA86")
    _ICustManageAppEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _ICustManageAppEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _ICustManageAppEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _ICustManageAppEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _ICustManageAppEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _ICustManageAppEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _ICustManageAppEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _ICustManageAppEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _ICustManageAppEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _ICustManageAppEventsVtbl;

    interface _ICustManageAppEvents
    {
        CONST_VTBL struct _ICustManageAppEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _ICustManageAppEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _ICustManageAppEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _ICustManageAppEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _ICustManageAppEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _ICustManageAppEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _ICustManageAppEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _ICustManageAppEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___ICustManageAppEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CustManageApp;

#ifdef __cplusplus

class DECLSPEC_UUID("AD6E5643-7B0C-46AA-95AD-9773FF2A857A")
CustManageApp;
#endif
#endif /* __ComUtilitiesLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

unsigned long             __RPC_USER  VARIANT_UserSize(     unsigned long *, unsigned long            , VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserMarshal(  unsigned long *, unsigned char *, VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserUnmarshal(unsigned long *, unsigned char *, VARIANT * ); 
void                      __RPC_USER  VARIANT_UserFree(     unsigned long *, VARIANT * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


