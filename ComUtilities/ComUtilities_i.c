

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


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


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_IDownloadManager,0x988934A4,0x064B,0x11D3,0xBB,0x80,0x00,0x10,0x4B,0x35,0xE7,0xF9);


MIDL_DEFINE_GUID(IID, IID_IUtilMan,0xDD264321,0x7025,0x476C,0x8B,0x7A,0x85,0x0E,0x0B,0x79,0xDD,0x41);


MIDL_DEFINE_GUID(IID, IID_IManagedAppBridge,0xEF49428E,0x8C06,0x4412,0x8F,0x64,0x1C,0xF7,0x96,0xF0,0xBE,0xDF);


MIDL_DEFINE_GUID(IID, IID_ICustManageApp,0xC43E6EBA,0x1999,0x4089,0xB9,0xEF,0xEA,0xC4,0x4D,0x4E,0xD6,0x25);


MIDL_DEFINE_GUID(IID, LIBID_ComUtilitiesLib,0xF8706742,0x6B5C,0x4E63,0x8D,0xBD,0x9C,0x79,0xA1,0x4D,0x20,0x09);


MIDL_DEFINE_GUID(IID, DIID__IUtilManEvents,0xD6B43A79,0xC0FC,0x4E85,0x8B,0xB4,0x62,0x35,0xB8,0x1C,0x6C,0xBF);


MIDL_DEFINE_GUID(CLSID, CLSID_UtilMan,0x98EDB477,0x3064,0x4D0E,0xA0,0x9E,0xCC,0x73,0xF9,0xAA,0xB3,0x24);


MIDL_DEFINE_GUID(IID, DIID__IManagedAppBridgeEvents,0x2639DA95,0xE95D,0x48B8,0xA3,0x79,0x08,0x3D,0x2F,0xA3,0xE9,0xBC);


MIDL_DEFINE_GUID(CLSID, CLSID_ManagedAppBridge,0x2E9178C0,0xD804,0x4A93,0xB5,0x5D,0x3F,0xFF,0x54,0xB9,0x5F,0xF1);


MIDL_DEFINE_GUID(IID, DIID__ICustManageAppEvents,0xB6C355FD,0x215E,0x40A6,0x92,0xC5,0x56,0x46,0x19,0xB1,0xFA,0x86);


MIDL_DEFINE_GUID(CLSID, CLSID_CustManageApp,0xAD6E5643,0x7B0C,0x46AA,0x95,0xAD,0x97,0x73,0xFF,0x2A,0x85,0x7A);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



