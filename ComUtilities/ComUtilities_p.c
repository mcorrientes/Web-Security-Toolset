

/* this ALWAYS GENERATED file contains the proxy stub code */


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

#if defined(_M_AMD64)


#pragma warning( disable: 4049 )  /* more than 64k source lines */
#if _MSC_VER >= 1200
#pragma warning(push)
#endif

#pragma warning( disable: 4211 )  /* redefine extern to static */
#pragma warning( disable: 4232 )  /* dllimport identity*/
#pragma warning( disable: 4024 )  /* array to pointer mapping*/
#pragma warning( disable: 4152 )  /* function/data pointer conversion in expression */

#define USE_STUBLESS_PROXY


/* verify that the <rpcproxy.h> version is high enough to compile this file*/
#ifndef __REDQ_RPCPROXY_H_VERSION__
#define __REQUIRED_RPCPROXY_H_VERSION__ 475
#endif


#include "rpcproxy.h"
#ifndef __RPCPROXY_H_VERSION__
#error this stub requires an updated version of <rpcproxy.h>
#endif /* __RPCPROXY_H_VERSION__ */


#include "ComUtilities.h"

#define TYPE_FORMAT_STRING_SIZE   1033                              
#define PROC_FORMAT_STRING_SIZE   979                               
#define EXPR_FORMAT_STRING_SIZE   1                                 
#define TRANSMIT_AS_TABLE_SIZE    0            
#define WIRE_MARSHAL_TABLE_SIZE   2            

typedef struct _ComUtilities_MIDL_TYPE_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ TYPE_FORMAT_STRING_SIZE ];
    } ComUtilities_MIDL_TYPE_FORMAT_STRING;

typedef struct _ComUtilities_MIDL_PROC_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ PROC_FORMAT_STRING_SIZE ];
    } ComUtilities_MIDL_PROC_FORMAT_STRING;

typedef struct _ComUtilities_MIDL_EXPR_FORMAT_STRING
    {
    long          Pad;
    unsigned char  Format[ EXPR_FORMAT_STRING_SIZE ];
    } ComUtilities_MIDL_EXPR_FORMAT_STRING;


static const RPC_SYNTAX_IDENTIFIER  _RpcTransferSyntax = 
{{0x8A885D04,0x1CEB,0x11C9,{0x9F,0xE8,0x08,0x00,0x2B,0x10,0x48,0x60}},{2,0}};


extern const ComUtilities_MIDL_TYPE_FORMAT_STRING ComUtilities__MIDL_TypeFormatString;
extern const ComUtilities_MIDL_PROC_FORMAT_STRING ComUtilities__MIDL_ProcFormatString;
extern const ComUtilities_MIDL_EXPR_FORMAT_STRING ComUtilities__MIDL_ExprFormatString;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IUtilMan_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IUtilMan_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO IManagedAppBridge_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO IManagedAppBridge_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ICustManageApp_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ICustManageApp_ProxyInfo;


extern const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ];

#if !defined(__RPC_WIN64__)
#error  Invalid build platform for this stub.
#endif

static const ComUtilities_MIDL_PROC_FORMAT_STRING ComUtilities__MIDL_ProcFormatString =
    {
        0,
        {

	/* Procedure get_HWNDInternetExplorerServer */

			0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/*  2 */	NdrFcLong( 0x0 ),	/* 0 */
/*  6 */	NdrFcShort( 0x7 ),	/* 7 */
/*  8 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 10 */	NdrFcShort( 0x0 ),	/* 0 */
/* 12 */	NdrFcShort( 0x24 ),	/* 36 */
/* 14 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 16 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 18 */	NdrFcShort( 0x0 ),	/* 0 */
/* 20 */	NdrFcShort( 0x0 ),	/* 0 */
/* 22 */	NdrFcShort( 0x0 ),	/* 0 */
/* 24 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 26 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 28 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 30 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 32 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 34 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 36 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DownloadAbortCustomApp */


	/* Procedure DownloadAbortManaged */


	/* Procedure put_HWNDInternetExplorerServer */

/* 38 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 40 */	NdrFcLong( 0x0 ),	/* 0 */
/* 44 */	NdrFcShort( 0x8 ),	/* 8 */
/* 46 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 48 */	NdrFcShort( 0x8 ),	/* 8 */
/* 50 */	NdrFcShort( 0x8 ),	/* 8 */
/* 52 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 54 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */
/* 60 */	NdrFcShort( 0x0 ),	/* 0 */
/* 62 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter InetErrorCode */


	/* Parameter InetErrorCode */


	/* Parameter newVal */

/* 64 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 66 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 68 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */


	/* Return value */

/* 70 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 72 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 74 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure HookProcNCode */

/* 76 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 78 */	NdrFcLong( 0x0 ),	/* 0 */
/* 82 */	NdrFcShort( 0x9 ),	/* 9 */
/* 84 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 86 */	NdrFcShort( 0x22 ),	/* 34 */
/* 88 */	NdrFcShort( 0x24 ),	/* 36 */
/* 90 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x3,		/* 3 */
/* 92 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 94 */	NdrFcShort( 0x0 ),	/* 0 */
/* 96 */	NdrFcShort( 0x0 ),	/* 0 */
/* 98 */	NdrFcShort( 0x0 ),	/* 0 */
/* 100 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter lHookType */

/* 102 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 104 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 106 */	0xd,		/* FC_ENUM16 */
			0x0,		/* 0 */

	/* Parameter nCode */

/* 108 */	NdrFcShort( 0x158 ),	/* Flags:  in, out, base type, simple ref, */
/* 110 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 112 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 114 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 116 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 118 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetupWindowsHook */

/* 120 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 122 */	NdrFcLong( 0x0 ),	/* 0 */
/* 126 */	NdrFcShort( 0xa ),	/* 10 */
/* 128 */	NdrFcShort( 0x30 ),	/* X64 Stack size/offset = 48 */
/* 130 */	NdrFcShort( 0x30 ),	/* 48 */
/* 132 */	NdrFcShort( 0x24 ),	/* 36 */
/* 134 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x5,		/* 5 */
/* 136 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 138 */	NdrFcShort( 0x0 ),	/* 0 */
/* 140 */	NdrFcShort( 0x0 ),	/* 0 */
/* 142 */	NdrFcShort( 0x0 ),	/* 0 */
/* 144 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter lHookType */

/* 146 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 148 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 150 */	0xd,		/* FC_ENUM16 */
			0x0,		/* 0 */

	/* Parameter hwndTargetWnd */

/* 152 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 154 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 156 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter bStart */

/* 158 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 160 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 162 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Parameter lUWMHookMsgID */

/* 164 */	NdrFcShort( 0x158 ),	/* Flags:  in, out, base type, simple ref, */
/* 166 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 168 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 170 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 172 */	NdrFcShort( 0x28 ),	/* X64 Stack size/offset = 40 */
/* 174 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CancelFileDownload */

/* 176 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 178 */	NdrFcLong( 0x0 ),	/* 0 */
/* 182 */	NdrFcShort( 0xb ),	/* 11 */
/* 184 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 186 */	NdrFcShort( 0x8 ),	/* 8 */
/* 188 */	NdrFcShort( 0x8 ),	/* 8 */
/* 190 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 192 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 194 */	NdrFcShort( 0x0 ),	/* 0 */
/* 196 */	NdrFcShort( 0x0 ),	/* 0 */
/* 198 */	NdrFcShort( 0x0 ),	/* 0 */
/* 200 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter DlUid */

/* 202 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 204 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 206 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 208 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 210 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 212 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DownloadUrlAsync */

/* 214 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 216 */	NdrFcLong( 0x0 ),	/* 0 */
/* 220 */	NdrFcShort( 0xc ),	/* 12 */
/* 222 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 224 */	NdrFcShort( 0x1c ),	/* 28 */
/* 226 */	NdrFcShort( 0x24 ),	/* 36 */
/* 228 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 230 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 232 */	NdrFcShort( 0x0 ),	/* 0 */
/* 234 */	NdrFcShort( 0x1 ),	/* 1 */
/* 236 */	NdrFcShort( 0x0 ),	/* 0 */
/* 238 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter URL */

/* 240 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 242 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 244 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Parameter DLUID */

/* 246 */	NdrFcShort( 0x158 ),	/* Flags:  in, out, base type, simple ref, */
/* 248 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 250 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 252 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 254 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 256 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_HTTPSprotocolManaged */

/* 258 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 260 */	NdrFcLong( 0x0 ),	/* 0 */
/* 264 */	NdrFcShort( 0xd ),	/* 13 */
/* 266 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 268 */	NdrFcShort( 0x0 ),	/* 0 */
/* 270 */	NdrFcShort( 0x22 ),	/* 34 */
/* 272 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 274 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 276 */	NdrFcShort( 0x0 ),	/* 0 */
/* 278 */	NdrFcShort( 0x0 ),	/* 0 */
/* 280 */	NdrFcShort( 0x0 ),	/* 0 */
/* 282 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 284 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 286 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 288 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 290 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 292 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 294 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_HTTPSprotocolManaged */

/* 296 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 298 */	NdrFcLong( 0x0 ),	/* 0 */
/* 302 */	NdrFcShort( 0xe ),	/* 14 */
/* 304 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 306 */	NdrFcShort( 0x6 ),	/* 6 */
/* 308 */	NdrFcShort( 0x8 ),	/* 8 */
/* 310 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 312 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 314 */	NdrFcShort( 0x0 ),	/* 0 */
/* 316 */	NdrFcShort( 0x0 ),	/* 0 */
/* 318 */	NdrFcShort( 0x0 ),	/* 0 */
/* 320 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 322 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 324 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 326 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 328 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 330 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 332 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_HTTPprotocolManaged */

/* 334 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 336 */	NdrFcLong( 0x0 ),	/* 0 */
/* 340 */	NdrFcShort( 0xf ),	/* 15 */
/* 342 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 344 */	NdrFcShort( 0x0 ),	/* 0 */
/* 346 */	NdrFcShort( 0x22 ),	/* 34 */
/* 348 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 350 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 352 */	NdrFcShort( 0x0 ),	/* 0 */
/* 354 */	NdrFcShort( 0x0 ),	/* 0 */
/* 356 */	NdrFcShort( 0x0 ),	/* 0 */
/* 358 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 360 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 362 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 364 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 366 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 368 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 370 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_HTTPprotocolManaged */

/* 372 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 374 */	NdrFcLong( 0x0 ),	/* 0 */
/* 378 */	NdrFcShort( 0x10 ),	/* 16 */
/* 380 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 382 */	NdrFcShort( 0x6 ),	/* 6 */
/* 384 */	NdrFcShort( 0x8 ),	/* 8 */
/* 386 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 388 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 390 */	NdrFcShort( 0x0 ),	/* 0 */
/* 392 */	NdrFcShort( 0x0 ),	/* 0 */
/* 394 */	NdrFcShort( 0x0 ),	/* 0 */
/* 396 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 398 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 400 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 402 */	0x6,		/* FC_SHORT */
			0x0,		/* 0 */

	/* Return value */

/* 404 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 406 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 408 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure GetScriptObjects */

/* 410 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 412 */	NdrFcLong( 0x0 ),	/* 0 */
/* 416 */	NdrFcShort( 0x11 ),	/* 17 */
/* 418 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 420 */	NdrFcShort( 0x0 ),	/* 0 */
/* 422 */	NdrFcShort( 0x8 ),	/* 8 */
/* 424 */	0x47,		/* Oi2 Flags:  srv must size, clt must size, has return, has ext, */
			0x3,		/* 3 */
/* 426 */	0xa,		/* 10 */
			0x7,		/* Ext Flags:  new corr desc, clt corr check, srv corr check, */
/* 428 */	NdrFcShort( 0x1 ),	/* 1 */
/* 430 */	NdrFcShort( 0x1 ),	/* 1 */
/* 432 */	NdrFcShort( 0x0 ),	/* 0 */
/* 434 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter ScriptDispatch */

/* 436 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 438 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 440 */	NdrFcShort( 0x32 ),	/* Type Offset=50 */

	/* Parameter strObjects */

/* 442 */	NdrFcShort( 0x11b ),	/* Flags:  must size, must free, in, out, simple ref, */
/* 444 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 446 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 448 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 450 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 452 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DownloadCompleteCustomApp */


	/* Procedure DownloadCompleteManaged */

/* 454 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 456 */	NdrFcLong( 0x0 ),	/* 0 */
/* 460 */	NdrFcShort( 0x7 ),	/* 7 */
/* 462 */	NdrFcShort( 0x30 ),	/* X64 Stack size/offset = 48 */
/* 464 */	NdrFcShort( 0x8 ),	/* 8 */
/* 466 */	NdrFcShort( 0x8 ),	/* 8 */
/* 468 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x5,		/* 5 */
/* 470 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 472 */	NdrFcShort( 0x0 ),	/* 0 */
/* 474 */	NdrFcShort( 0x1 ),	/* 1 */
/* 476 */	NdrFcShort( 0x0 ),	/* 0 */
/* 478 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter sUrl */


	/* Parameter sUrl */

/* 480 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 482 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 484 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Parameter sMime */


	/* Parameter sMime */

/* 486 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 488 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 490 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Parameter data */


	/* Parameter data */

/* 492 */	NdrFcShort( 0x10b ),	/* Flags:  must size, must free, in, simple ref, */
/* 494 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 496 */	NdrFcShort( 0x3fa ),	/* Type Offset=1018 */

	/* Parameter dataLength */


	/* Parameter dataLength */

/* 498 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 500 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 502 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */


	/* Return value */

/* 504 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 506 */	NdrFcShort( 0x28 ),	/* X64 Stack size/offset = 40 */
/* 508 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_IEServerHwnd */

/* 510 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 512 */	NdrFcLong( 0x0 ),	/* 0 */
/* 516 */	NdrFcShort( 0x9 ),	/* 9 */
/* 518 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 520 */	NdrFcShort( 0x0 ),	/* 0 */
/* 522 */	NdrFcShort( 0x24 ),	/* 36 */
/* 524 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 526 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 528 */	NdrFcShort( 0x0 ),	/* 0 */
/* 530 */	NdrFcShort( 0x0 ),	/* 0 */
/* 532 */	NdrFcShort( 0x0 ),	/* 0 */
/* 534 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 536 */	NdrFcShort( 0x2150 ),	/* Flags:  out, base type, simple ref, srv alloc size=8 */
/* 538 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 540 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 542 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 544 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 546 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_URL */

/* 548 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 550 */	NdrFcLong( 0x0 ),	/* 0 */
/* 554 */	NdrFcShort( 0xa ),	/* 10 */
/* 556 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 558 */	NdrFcShort( 0x0 ),	/* 0 */
/* 560 */	NdrFcShort( 0x8 ),	/* 8 */
/* 562 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 564 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 566 */	NdrFcShort( 0x1 ),	/* 1 */
/* 568 */	NdrFcShort( 0x0 ),	/* 0 */
/* 570 */	NdrFcShort( 0x0 ),	/* 0 */
/* 572 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 574 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 576 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 578 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 580 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 582 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 584 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_URL */

/* 586 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 588 */	NdrFcLong( 0x0 ),	/* 0 */
/* 592 */	NdrFcShort( 0xb ),	/* 11 */
/* 594 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 596 */	NdrFcShort( 0x0 ),	/* 0 */
/* 598 */	NdrFcShort( 0x8 ),	/* 8 */
/* 600 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 602 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 604 */	NdrFcShort( 0x0 ),	/* 0 */
/* 606 */	NdrFcShort( 0x1 ),	/* 1 */
/* 608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 610 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 612 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 614 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 616 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 618 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 620 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 622 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_RequestHeaders */

/* 624 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 626 */	NdrFcLong( 0x0 ),	/* 0 */
/* 630 */	NdrFcShort( 0xc ),	/* 12 */
/* 632 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 634 */	NdrFcShort( 0x0 ),	/* 0 */
/* 636 */	NdrFcShort( 0x8 ),	/* 8 */
/* 638 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 640 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 642 */	NdrFcShort( 0x1 ),	/* 1 */
/* 644 */	NdrFcShort( 0x0 ),	/* 0 */
/* 646 */	NdrFcShort( 0x0 ),	/* 0 */
/* 648 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 650 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 652 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 654 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 656 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 658 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 660 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_PostData */

/* 662 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 664 */	NdrFcLong( 0x0 ),	/* 0 */
/* 668 */	NdrFcShort( 0xd ),	/* 13 */
/* 670 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 672 */	NdrFcShort( 0x0 ),	/* 0 */
/* 674 */	NdrFcShort( 0x8 ),	/* 8 */
/* 676 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 678 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 680 */	NdrFcShort( 0x1 ),	/* 1 */
/* 682 */	NdrFcShort( 0x0 ),	/* 0 */
/* 684 */	NdrFcShort( 0x0 ),	/* 0 */
/* 686 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 688 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 690 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 692 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 694 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 696 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 698 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_PostDataMimeType */

/* 700 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 702 */	NdrFcLong( 0x0 ),	/* 0 */
/* 706 */	NdrFcShort( 0xe ),	/* 14 */
/* 708 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 710 */	NdrFcShort( 0x0 ),	/* 0 */
/* 712 */	NdrFcShort( 0x8 ),	/* 8 */
/* 714 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 716 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 718 */	NdrFcShort( 0x1 ),	/* 1 */
/* 720 */	NdrFcShort( 0x0 ),	/* 0 */
/* 722 */	NdrFcShort( 0x0 ),	/* 0 */
/* 724 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 726 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 728 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 730 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 732 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 734 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 736 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_DownloadData */

/* 738 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 740 */	NdrFcLong( 0x0 ),	/* 0 */
/* 744 */	NdrFcShort( 0xf ),	/* 15 */
/* 746 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 748 */	NdrFcShort( 0x0 ),	/* 0 */
/* 750 */	NdrFcShort( 0x8 ),	/* 8 */
/* 752 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 754 */	0xa,		/* 10 */
			0x85,		/* Ext Flags:  new corr desc, srv corr check, has big amd64 byval param */
/* 756 */	NdrFcShort( 0x0 ),	/* 0 */
/* 758 */	NdrFcShort( 0x1 ),	/* 1 */
/* 760 */	NdrFcShort( 0x0 ),	/* 0 */
/* 762 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 764 */	NdrFcShort( 0x10b ),	/* Flags:  must size, must free, in, simple ref, */
/* 766 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 768 */	NdrFcShort( 0x3fa ),	/* Type Offset=1018 */

	/* Return value */

/* 770 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 772 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 774 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_DataMimeType */

/* 776 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 778 */	NdrFcLong( 0x0 ),	/* 0 */
/* 782 */	NdrFcShort( 0x10 ),	/* 16 */
/* 784 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 786 */	NdrFcShort( 0x0 ),	/* 0 */
/* 788 */	NdrFcShort( 0x8 ),	/* 8 */
/* 790 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 792 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 794 */	NdrFcShort( 0x1 ),	/* 1 */
/* 796 */	NdrFcShort( 0x0 ),	/* 0 */
/* 798 */	NdrFcShort( 0x0 ),	/* 0 */
/* 800 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 802 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 804 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 806 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 808 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 810 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 812 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_DataMimeType */

/* 814 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 816 */	NdrFcLong( 0x0 ),	/* 0 */
/* 820 */	NdrFcShort( 0x11 ),	/* 17 */
/* 822 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 824 */	NdrFcShort( 0x0 ),	/* 0 */
/* 826 */	NdrFcShort( 0x8 ),	/* 8 */
/* 828 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 830 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 832 */	NdrFcShort( 0x0 ),	/* 0 */
/* 834 */	NdrFcShort( 0x1 ),	/* 1 */
/* 836 */	NdrFcShort( 0x0 ),	/* 0 */
/* 838 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 840 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 842 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 844 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 846 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 848 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 850 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure get_DownloadCacheFileName */

/* 852 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 854 */	NdrFcLong( 0x0 ),	/* 0 */
/* 858 */	NdrFcShort( 0x12 ),	/* 18 */
/* 860 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 862 */	NdrFcShort( 0x0 ),	/* 0 */
/* 864 */	NdrFcShort( 0x8 ),	/* 8 */
/* 866 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 868 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 870 */	NdrFcShort( 0x1 ),	/* 1 */
/* 872 */	NdrFcShort( 0x0 ),	/* 0 */
/* 874 */	NdrFcShort( 0x0 ),	/* 0 */
/* 876 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pVal */

/* 878 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 880 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 882 */	NdrFcShort( 0x4c ),	/* Type Offset=76 */

	/* Return value */

/* 884 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 886 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 888 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure put_DownloadCacheFileName */

/* 890 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 892 */	NdrFcLong( 0x0 ),	/* 0 */
/* 896 */	NdrFcShort( 0x13 ),	/* 19 */
/* 898 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 900 */	NdrFcShort( 0x0 ),	/* 0 */
/* 902 */	NdrFcShort( 0x8 ),	/* 8 */
/* 904 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x2,		/* 2 */
/* 906 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 908 */	NdrFcShort( 0x0 ),	/* 0 */
/* 910 */	NdrFcShort( 0x1 ),	/* 1 */
/* 912 */	NdrFcShort( 0x0 ),	/* 0 */
/* 914 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter newVal */

/* 916 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 918 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 920 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 922 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 924 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 926 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DownloadCompleteManagedCache */

/* 928 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 930 */	NdrFcLong( 0x0 ),	/* 0 */
/* 934 */	NdrFcShort( 0x14 ),	/* 20 */
/* 936 */	NdrFcShort( 0x28 ),	/* X64 Stack size/offset = 40 */
/* 938 */	NdrFcShort( 0x0 ),	/* 0 */
/* 940 */	NdrFcShort( 0x8 ),	/* 8 */
/* 942 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 944 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 946 */	NdrFcShort( 0x0 ),	/* 0 */
/* 948 */	NdrFcShort( 0x1 ),	/* 1 */
/* 950 */	NdrFcShort( 0x0 ),	/* 0 */
/* 952 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter sUrl */

/* 954 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 956 */	NdrFcShort( 0x8 ),	/* X64 Stack size/offset = 8 */
/* 958 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Parameter sMime */

/* 960 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 962 */	NdrFcShort( 0x10 ),	/* X64 Stack size/offset = 16 */
/* 964 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Parameter sCacheFileName */

/* 966 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 968 */	NdrFcShort( 0x18 ),	/* X64 Stack size/offset = 24 */
/* 970 */	NdrFcShort( 0x24 ),	/* Type Offset=36 */

	/* Return value */

/* 972 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 974 */	NdrFcShort( 0x20 ),	/* X64 Stack size/offset = 32 */
/* 976 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

			0x0
        }
    };

static const ComUtilities_MIDL_TYPE_FORMAT_STRING ComUtilities__MIDL_TypeFormatString =
    {
        0,
        {
			NdrFcShort( 0x0 ),	/* 0 */
/*  2 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/*  4 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/*  6 */	
			0x11, 0x8,	/* FC_RP [simple_pointer] */
/*  8 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 10 */	
			0x12, 0x0,	/* FC_UP */
/* 12 */	NdrFcShort( 0xe ),	/* Offset= 14 (26) */
/* 14 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 16 */	NdrFcShort( 0x2 ),	/* 2 */
/* 18 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 20 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 22 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 24 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 26 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 28 */	NdrFcShort( 0x8 ),	/* 8 */
/* 30 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (14) */
/* 32 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 34 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 36 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 38 */	NdrFcShort( 0x0 ),	/* 0 */
/* 40 */	NdrFcShort( 0x8 ),	/* 8 */
/* 42 */	NdrFcShort( 0x0 ),	/* 0 */
/* 44 */	NdrFcShort( 0xffde ),	/* Offset= -34 (10) */
/* 46 */	
			0x11, 0xc,	/* FC_RP [alloced_on_stack] [simple_pointer] */
/* 48 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 50 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 52 */	NdrFcLong( 0x20400 ),	/* 132096 */
/* 56 */	NdrFcShort( 0x0 ),	/* 0 */
/* 58 */	NdrFcShort( 0x0 ),	/* 0 */
/* 60 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 62 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 64 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 66 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 68 */	
			0x11, 0x0,	/* FC_RP */
/* 70 */	NdrFcShort( 0x6 ),	/* Offset= 6 (76) */
/* 72 */	
			0x13, 0x0,	/* FC_OP */
/* 74 */	NdrFcShort( 0xffd0 ),	/* Offset= -48 (26) */
/* 76 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 78 */	NdrFcShort( 0x0 ),	/* 0 */
/* 80 */	NdrFcShort( 0x8 ),	/* 8 */
/* 82 */	NdrFcShort( 0x0 ),	/* 0 */
/* 84 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (72) */
/* 86 */	
			0x11, 0x0,	/* FC_RP */
/* 88 */	NdrFcShort( 0x3a2 ),	/* Offset= 930 (1018) */
/* 90 */	
			0x12, 0x0,	/* FC_UP */
/* 92 */	NdrFcShort( 0x38a ),	/* Offset= 906 (998) */
/* 94 */	
			0x2b,		/* FC_NON_ENCAPSULATED_UNION */
			0x9,		/* FC_ULONG */
/* 96 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 98 */	NdrFcShort( 0xfff8 ),	/* -8 */
/* 100 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 102 */	NdrFcShort( 0x2 ),	/* Offset= 2 (104) */
/* 104 */	NdrFcShort( 0x10 ),	/* 16 */
/* 106 */	NdrFcShort( 0x2f ),	/* 47 */
/* 108 */	NdrFcLong( 0x14 ),	/* 20 */
/* 112 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 114 */	NdrFcLong( 0x3 ),	/* 3 */
/* 118 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 120 */	NdrFcLong( 0x11 ),	/* 17 */
/* 124 */	NdrFcShort( 0x8001 ),	/* Simple arm type: FC_BYTE */
/* 126 */	NdrFcLong( 0x2 ),	/* 2 */
/* 130 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 132 */	NdrFcLong( 0x4 ),	/* 4 */
/* 136 */	NdrFcShort( 0x800a ),	/* Simple arm type: FC_FLOAT */
/* 138 */	NdrFcLong( 0x5 ),	/* 5 */
/* 142 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 144 */	NdrFcLong( 0xb ),	/* 11 */
/* 148 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 150 */	NdrFcLong( 0xa ),	/* 10 */
/* 154 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 156 */	NdrFcLong( 0x6 ),	/* 6 */
/* 160 */	NdrFcShort( 0xe8 ),	/* Offset= 232 (392) */
/* 162 */	NdrFcLong( 0x7 ),	/* 7 */
/* 166 */	NdrFcShort( 0x800c ),	/* Simple arm type: FC_DOUBLE */
/* 168 */	NdrFcLong( 0x8 ),	/* 8 */
/* 172 */	NdrFcShort( 0xff5e ),	/* Offset= -162 (10) */
/* 174 */	NdrFcLong( 0xd ),	/* 13 */
/* 178 */	NdrFcShort( 0xdc ),	/* Offset= 220 (398) */
/* 180 */	NdrFcLong( 0x9 ),	/* 9 */
/* 184 */	NdrFcShort( 0xff7a ),	/* Offset= -134 (50) */
/* 186 */	NdrFcLong( 0x2000 ),	/* 8192 */
/* 190 */	NdrFcShort( 0xe2 ),	/* Offset= 226 (416) */
/* 192 */	NdrFcLong( 0x24 ),	/* 36 */
/* 196 */	NdrFcShort( 0x2d8 ),	/* Offset= 728 (924) */
/* 198 */	NdrFcLong( 0x4024 ),	/* 16420 */
/* 202 */	NdrFcShort( 0x2d2 ),	/* Offset= 722 (924) */
/* 204 */	NdrFcLong( 0x4011 ),	/* 16401 */
/* 208 */	NdrFcShort( 0x2d0 ),	/* Offset= 720 (928) */
/* 210 */	NdrFcLong( 0x4002 ),	/* 16386 */
/* 214 */	NdrFcShort( 0x2ce ),	/* Offset= 718 (932) */
/* 216 */	NdrFcLong( 0x4003 ),	/* 16387 */
/* 220 */	NdrFcShort( 0x2cc ),	/* Offset= 716 (936) */
/* 222 */	NdrFcLong( 0x4014 ),	/* 16404 */
/* 226 */	NdrFcShort( 0x2ca ),	/* Offset= 714 (940) */
/* 228 */	NdrFcLong( 0x4004 ),	/* 16388 */
/* 232 */	NdrFcShort( 0x2c8 ),	/* Offset= 712 (944) */
/* 234 */	NdrFcLong( 0x4005 ),	/* 16389 */
/* 238 */	NdrFcShort( 0x2c6 ),	/* Offset= 710 (948) */
/* 240 */	NdrFcLong( 0x400b ),	/* 16395 */
/* 244 */	NdrFcShort( 0x2b0 ),	/* Offset= 688 (932) */
/* 246 */	NdrFcLong( 0x400a ),	/* 16394 */
/* 250 */	NdrFcShort( 0x2ae ),	/* Offset= 686 (936) */
/* 252 */	NdrFcLong( 0x4006 ),	/* 16390 */
/* 256 */	NdrFcShort( 0x2b8 ),	/* Offset= 696 (952) */
/* 258 */	NdrFcLong( 0x4007 ),	/* 16391 */
/* 262 */	NdrFcShort( 0x2ae ),	/* Offset= 686 (948) */
/* 264 */	NdrFcLong( 0x4008 ),	/* 16392 */
/* 268 */	NdrFcShort( 0x2b0 ),	/* Offset= 688 (956) */
/* 270 */	NdrFcLong( 0x400d ),	/* 16397 */
/* 274 */	NdrFcShort( 0x2ae ),	/* Offset= 686 (960) */
/* 276 */	NdrFcLong( 0x4009 ),	/* 16393 */
/* 280 */	NdrFcShort( 0x2ac ),	/* Offset= 684 (964) */
/* 282 */	NdrFcLong( 0x6000 ),	/* 24576 */
/* 286 */	NdrFcShort( 0x2aa ),	/* Offset= 682 (968) */
/* 288 */	NdrFcLong( 0x400c ),	/* 16396 */
/* 292 */	NdrFcShort( 0x2a8 ),	/* Offset= 680 (972) */
/* 294 */	NdrFcLong( 0x10 ),	/* 16 */
/* 298 */	NdrFcShort( 0x8002 ),	/* Simple arm type: FC_CHAR */
/* 300 */	NdrFcLong( 0x12 ),	/* 18 */
/* 304 */	NdrFcShort( 0x8006 ),	/* Simple arm type: FC_SHORT */
/* 306 */	NdrFcLong( 0x13 ),	/* 19 */
/* 310 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 312 */	NdrFcLong( 0x15 ),	/* 21 */
/* 316 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 318 */	NdrFcLong( 0x16 ),	/* 22 */
/* 322 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 324 */	NdrFcLong( 0x17 ),	/* 23 */
/* 328 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 330 */	NdrFcLong( 0xe ),	/* 14 */
/* 334 */	NdrFcShort( 0x286 ),	/* Offset= 646 (980) */
/* 336 */	NdrFcLong( 0x400e ),	/* 16398 */
/* 340 */	NdrFcShort( 0x28a ),	/* Offset= 650 (990) */
/* 342 */	NdrFcLong( 0x4010 ),	/* 16400 */
/* 346 */	NdrFcShort( 0x288 ),	/* Offset= 648 (994) */
/* 348 */	NdrFcLong( 0x4012 ),	/* 16402 */
/* 352 */	NdrFcShort( 0x244 ),	/* Offset= 580 (932) */
/* 354 */	NdrFcLong( 0x4013 ),	/* 16403 */
/* 358 */	NdrFcShort( 0x242 ),	/* Offset= 578 (936) */
/* 360 */	NdrFcLong( 0x4015 ),	/* 16405 */
/* 364 */	NdrFcShort( 0x240 ),	/* Offset= 576 (940) */
/* 366 */	NdrFcLong( 0x4016 ),	/* 16406 */
/* 370 */	NdrFcShort( 0x236 ),	/* Offset= 566 (936) */
/* 372 */	NdrFcLong( 0x4017 ),	/* 16407 */
/* 376 */	NdrFcShort( 0x230 ),	/* Offset= 560 (936) */
/* 378 */	NdrFcLong( 0x0 ),	/* 0 */
/* 382 */	NdrFcShort( 0x0 ),	/* Offset= 0 (382) */
/* 384 */	NdrFcLong( 0x1 ),	/* 1 */
/* 388 */	NdrFcShort( 0x0 ),	/* Offset= 0 (388) */
/* 390 */	NdrFcShort( 0xffff ),	/* Offset= -1 (389) */
/* 392 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 394 */	NdrFcShort( 0x8 ),	/* 8 */
/* 396 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 398 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 400 */	NdrFcLong( 0x0 ),	/* 0 */
/* 404 */	NdrFcShort( 0x0 ),	/* 0 */
/* 406 */	NdrFcShort( 0x0 ),	/* 0 */
/* 408 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 410 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 412 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 414 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 416 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 418 */	NdrFcShort( 0x2 ),	/* Offset= 2 (420) */
/* 420 */	
			0x12, 0x0,	/* FC_UP */
/* 422 */	NdrFcShort( 0x1e4 ),	/* Offset= 484 (906) */
/* 424 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x89,		/* 137 */
/* 426 */	NdrFcShort( 0x20 ),	/* 32 */
/* 428 */	NdrFcShort( 0xa ),	/* 10 */
/* 430 */	NdrFcLong( 0x8 ),	/* 8 */
/* 434 */	NdrFcShort( 0x50 ),	/* Offset= 80 (514) */
/* 436 */	NdrFcLong( 0xd ),	/* 13 */
/* 440 */	NdrFcShort( 0x70 ),	/* Offset= 112 (552) */
/* 442 */	NdrFcLong( 0x9 ),	/* 9 */
/* 446 */	NdrFcShort( 0x90 ),	/* Offset= 144 (590) */
/* 448 */	NdrFcLong( 0xc ),	/* 12 */
/* 452 */	NdrFcShort( 0xb0 ),	/* Offset= 176 (628) */
/* 454 */	NdrFcLong( 0x24 ),	/* 36 */
/* 458 */	NdrFcShort( 0x102 ),	/* Offset= 258 (716) */
/* 460 */	NdrFcLong( 0x800d ),	/* 32781 */
/* 464 */	NdrFcShort( 0x11e ),	/* Offset= 286 (750) */
/* 466 */	NdrFcLong( 0x10 ),	/* 16 */
/* 470 */	NdrFcShort( 0x138 ),	/* Offset= 312 (782) */
/* 472 */	NdrFcLong( 0x2 ),	/* 2 */
/* 476 */	NdrFcShort( 0x14e ),	/* Offset= 334 (810) */
/* 478 */	NdrFcLong( 0x3 ),	/* 3 */
/* 482 */	NdrFcShort( 0x164 ),	/* Offset= 356 (838) */
/* 484 */	NdrFcLong( 0x14 ),	/* 20 */
/* 488 */	NdrFcShort( 0x17a ),	/* Offset= 378 (866) */
/* 490 */	NdrFcShort( 0xffff ),	/* Offset= -1 (489) */
/* 492 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 494 */	NdrFcShort( 0x0 ),	/* 0 */
/* 496 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 498 */	NdrFcShort( 0x0 ),	/* 0 */
/* 500 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 502 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 506 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 508 */	
			0x12, 0x0,	/* FC_UP */
/* 510 */	NdrFcShort( 0xfe1c ),	/* Offset= -484 (26) */
/* 512 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 514 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 516 */	NdrFcShort( 0x10 ),	/* 16 */
/* 518 */	NdrFcShort( 0x0 ),	/* 0 */
/* 520 */	NdrFcShort( 0x6 ),	/* Offset= 6 (526) */
/* 522 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 524 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 526 */	
			0x11, 0x0,	/* FC_RP */
/* 528 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (492) */
/* 530 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 532 */	NdrFcShort( 0x0 ),	/* 0 */
/* 534 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 536 */	NdrFcShort( 0x0 ),	/* 0 */
/* 538 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 540 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 544 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 546 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 548 */	NdrFcShort( 0xff6a ),	/* Offset= -150 (398) */
/* 550 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 552 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 554 */	NdrFcShort( 0x10 ),	/* 16 */
/* 556 */	NdrFcShort( 0x0 ),	/* 0 */
/* 558 */	NdrFcShort( 0x6 ),	/* Offset= 6 (564) */
/* 560 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 562 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 564 */	
			0x11, 0x0,	/* FC_RP */
/* 566 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (530) */
/* 568 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 570 */	NdrFcShort( 0x0 ),	/* 0 */
/* 572 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 578 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 582 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 584 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 586 */	NdrFcShort( 0xfde8 ),	/* Offset= -536 (50) */
/* 588 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 590 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 592 */	NdrFcShort( 0x10 ),	/* 16 */
/* 594 */	NdrFcShort( 0x0 ),	/* 0 */
/* 596 */	NdrFcShort( 0x6 ),	/* Offset= 6 (602) */
/* 598 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 600 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 602 */	
			0x11, 0x0,	/* FC_RP */
/* 604 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (568) */
/* 606 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 608 */	NdrFcShort( 0x0 ),	/* 0 */
/* 610 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 612 */	NdrFcShort( 0x0 ),	/* 0 */
/* 614 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 616 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 620 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 622 */	
			0x12, 0x0,	/* FC_UP */
/* 624 */	NdrFcShort( 0x176 ),	/* Offset= 374 (998) */
/* 626 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 628 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 630 */	NdrFcShort( 0x10 ),	/* 16 */
/* 632 */	NdrFcShort( 0x0 ),	/* 0 */
/* 634 */	NdrFcShort( 0x6 ),	/* Offset= 6 (640) */
/* 636 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 638 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 640 */	
			0x11, 0x0,	/* FC_RP */
/* 642 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (606) */
/* 644 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/* 646 */	NdrFcLong( 0x2f ),	/* 47 */
/* 650 */	NdrFcShort( 0x0 ),	/* 0 */
/* 652 */	NdrFcShort( 0x0 ),	/* 0 */
/* 654 */	0xc0,		/* 192 */
			0x0,		/* 0 */
/* 656 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 658 */	0x0,		/* 0 */
			0x0,		/* 0 */
/* 660 */	0x0,		/* 0 */
			0x46,		/* 70 */
/* 662 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 664 */	NdrFcShort( 0x1 ),	/* 1 */
/* 666 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 668 */	NdrFcShort( 0x4 ),	/* 4 */
/* 670 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 672 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 674 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 676 */	NdrFcShort( 0x18 ),	/* 24 */
/* 678 */	NdrFcShort( 0x0 ),	/* 0 */
/* 680 */	NdrFcShort( 0xa ),	/* Offset= 10 (690) */
/* 682 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 684 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 686 */	NdrFcShort( 0xffd6 ),	/* Offset= -42 (644) */
/* 688 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 690 */	
			0x12, 0x0,	/* FC_UP */
/* 692 */	NdrFcShort( 0xffe2 ),	/* Offset= -30 (662) */
/* 694 */	
			0x21,		/* FC_BOGUS_ARRAY */
			0x3,		/* 3 */
/* 696 */	NdrFcShort( 0x0 ),	/* 0 */
/* 698 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 700 */	NdrFcShort( 0x0 ),	/* 0 */
/* 702 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 704 */	NdrFcLong( 0xffffffff ),	/* -1 */
/* 708 */	NdrFcShort( 0x0 ),	/* Corr flags:  */
/* 710 */	
			0x12, 0x0,	/* FC_UP */
/* 712 */	NdrFcShort( 0xffda ),	/* Offset= -38 (674) */
/* 714 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 716 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 718 */	NdrFcShort( 0x10 ),	/* 16 */
/* 720 */	NdrFcShort( 0x0 ),	/* 0 */
/* 722 */	NdrFcShort( 0x6 ),	/* Offset= 6 (728) */
/* 724 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 726 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 728 */	
			0x11, 0x0,	/* FC_RP */
/* 730 */	NdrFcShort( 0xffdc ),	/* Offset= -36 (694) */
/* 732 */	
			0x1d,		/* FC_SMFARRAY */
			0x0,		/* 0 */
/* 734 */	NdrFcShort( 0x8 ),	/* 8 */
/* 736 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 738 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 740 */	NdrFcShort( 0x10 ),	/* 16 */
/* 742 */	0x8,		/* FC_LONG */
			0x6,		/* FC_SHORT */
/* 744 */	0x6,		/* FC_SHORT */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 746 */	0x0,		/* 0 */
			NdrFcShort( 0xfff1 ),	/* Offset= -15 (732) */
			0x5b,		/* FC_END */
/* 750 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 752 */	NdrFcShort( 0x20 ),	/* 32 */
/* 754 */	NdrFcShort( 0x0 ),	/* 0 */
/* 756 */	NdrFcShort( 0xa ),	/* Offset= 10 (766) */
/* 758 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 760 */	0x36,		/* FC_POINTER */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 762 */	0x0,		/* 0 */
			NdrFcShort( 0xffe7 ),	/* Offset= -25 (738) */
			0x5b,		/* FC_END */
/* 766 */	
			0x11, 0x0,	/* FC_RP */
/* 768 */	NdrFcShort( 0xff12 ),	/* Offset= -238 (530) */
/* 770 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 772 */	NdrFcShort( 0x1 ),	/* 1 */
/* 774 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 776 */	NdrFcShort( 0x0 ),	/* 0 */
/* 778 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 780 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 782 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 784 */	NdrFcShort( 0x10 ),	/* 16 */
/* 786 */	NdrFcShort( 0x0 ),	/* 0 */
/* 788 */	NdrFcShort( 0x6 ),	/* Offset= 6 (794) */
/* 790 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 792 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 794 */	
			0x12, 0x0,	/* FC_UP */
/* 796 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (770) */
/* 798 */	
			0x1b,		/* FC_CARRAY */
			0x1,		/* 1 */
/* 800 */	NdrFcShort( 0x2 ),	/* 2 */
/* 802 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 804 */	NdrFcShort( 0x0 ),	/* 0 */
/* 806 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 808 */	0x6,		/* FC_SHORT */
			0x5b,		/* FC_END */
/* 810 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 812 */	NdrFcShort( 0x10 ),	/* 16 */
/* 814 */	NdrFcShort( 0x0 ),	/* 0 */
/* 816 */	NdrFcShort( 0x6 ),	/* Offset= 6 (822) */
/* 818 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 820 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 822 */	
			0x12, 0x0,	/* FC_UP */
/* 824 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (798) */
/* 826 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 828 */	NdrFcShort( 0x4 ),	/* 4 */
/* 830 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 832 */	NdrFcShort( 0x0 ),	/* 0 */
/* 834 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 836 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 838 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 840 */	NdrFcShort( 0x10 ),	/* 16 */
/* 842 */	NdrFcShort( 0x0 ),	/* 0 */
/* 844 */	NdrFcShort( 0x6 ),	/* Offset= 6 (850) */
/* 846 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 848 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 850 */	
			0x12, 0x0,	/* FC_UP */
/* 852 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (826) */
/* 854 */	
			0x1b,		/* FC_CARRAY */
			0x7,		/* 7 */
/* 856 */	NdrFcShort( 0x8 ),	/* 8 */
/* 858 */	0x19,		/* Corr desc:  field pointer, FC_ULONG */
			0x0,		/*  */
/* 860 */	NdrFcShort( 0x0 ),	/* 0 */
/* 862 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 864 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 866 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 868 */	NdrFcShort( 0x10 ),	/* 16 */
/* 870 */	NdrFcShort( 0x0 ),	/* 0 */
/* 872 */	NdrFcShort( 0x6 ),	/* Offset= 6 (878) */
/* 874 */	0x8,		/* FC_LONG */
			0x40,		/* FC_STRUCTPAD4 */
/* 876 */	0x36,		/* FC_POINTER */
			0x5b,		/* FC_END */
/* 878 */	
			0x12, 0x0,	/* FC_UP */
/* 880 */	NdrFcShort( 0xffe6 ),	/* Offset= -26 (854) */
/* 882 */	
			0x15,		/* FC_STRUCT */
			0x3,		/* 3 */
/* 884 */	NdrFcShort( 0x8 ),	/* 8 */
/* 886 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 888 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 890 */	
			0x1b,		/* FC_CARRAY */
			0x3,		/* 3 */
/* 892 */	NdrFcShort( 0x8 ),	/* 8 */
/* 894 */	0x7,		/* Corr desc: FC_USHORT */
			0x0,		/*  */
/* 896 */	NdrFcShort( 0xffc8 ),	/* -56 */
/* 898 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 900 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 902 */	NdrFcShort( 0xffec ),	/* Offset= -20 (882) */
/* 904 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 906 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x3,		/* 3 */
/* 908 */	NdrFcShort( 0x38 ),	/* 56 */
/* 910 */	NdrFcShort( 0xffec ),	/* Offset= -20 (890) */
/* 912 */	NdrFcShort( 0x0 ),	/* Offset= 0 (912) */
/* 914 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 916 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 918 */	0x40,		/* FC_STRUCTPAD4 */
			0x4c,		/* FC_EMBEDDED_COMPLEX */
/* 920 */	0x0,		/* 0 */
			NdrFcShort( 0xfe0f ),	/* Offset= -497 (424) */
			0x5b,		/* FC_END */
/* 924 */	
			0x12, 0x0,	/* FC_UP */
/* 926 */	NdrFcShort( 0xff04 ),	/* Offset= -252 (674) */
/* 928 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 930 */	0x1,		/* FC_BYTE */
			0x5c,		/* FC_PAD */
/* 932 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 934 */	0x6,		/* FC_SHORT */
			0x5c,		/* FC_PAD */
/* 936 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 938 */	0x8,		/* FC_LONG */
			0x5c,		/* FC_PAD */
/* 940 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 942 */	0xb,		/* FC_HYPER */
			0x5c,		/* FC_PAD */
/* 944 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 946 */	0xa,		/* FC_FLOAT */
			0x5c,		/* FC_PAD */
/* 948 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 950 */	0xc,		/* FC_DOUBLE */
			0x5c,		/* FC_PAD */
/* 952 */	
			0x12, 0x0,	/* FC_UP */
/* 954 */	NdrFcShort( 0xfdce ),	/* Offset= -562 (392) */
/* 956 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 958 */	NdrFcShort( 0xfc4c ),	/* Offset= -948 (10) */
/* 960 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 962 */	NdrFcShort( 0xfdcc ),	/* Offset= -564 (398) */
/* 964 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 966 */	NdrFcShort( 0xfc6c ),	/* Offset= -916 (50) */
/* 968 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 970 */	NdrFcShort( 0xfdd6 ),	/* Offset= -554 (416) */
/* 972 */	
			0x12, 0x10,	/* FC_UP [pointer_deref] */
/* 974 */	NdrFcShort( 0x2 ),	/* Offset= 2 (976) */
/* 976 */	
			0x12, 0x0,	/* FC_UP */
/* 978 */	NdrFcShort( 0x14 ),	/* Offset= 20 (998) */
/* 980 */	
			0x15,		/* FC_STRUCT */
			0x7,		/* 7 */
/* 982 */	NdrFcShort( 0x10 ),	/* 16 */
/* 984 */	0x6,		/* FC_SHORT */
			0x1,		/* FC_BYTE */
/* 986 */	0x1,		/* FC_BYTE */
			0x8,		/* FC_LONG */
/* 988 */	0xb,		/* FC_HYPER */
			0x5b,		/* FC_END */
/* 990 */	
			0x12, 0x0,	/* FC_UP */
/* 992 */	NdrFcShort( 0xfff4 ),	/* Offset= -12 (980) */
/* 994 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 996 */	0x2,		/* FC_CHAR */
			0x5c,		/* FC_PAD */
/* 998 */	
			0x1a,		/* FC_BOGUS_STRUCT */
			0x7,		/* 7 */
/* 1000 */	NdrFcShort( 0x20 ),	/* 32 */
/* 1002 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1004 */	NdrFcShort( 0x0 ),	/* Offset= 0 (1004) */
/* 1006 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 1008 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1010 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 1012 */	0x4c,		/* FC_EMBEDDED_COMPLEX */
			0x0,		/* 0 */
/* 1014 */	NdrFcShort( 0xfc68 ),	/* Offset= -920 (94) */
/* 1016 */	0x5c,		/* FC_PAD */
			0x5b,		/* FC_END */
/* 1018 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 1020 */	NdrFcShort( 0x1 ),	/* 1 */
/* 1022 */	NdrFcShort( 0x18 ),	/* 24 */
/* 1024 */	NdrFcShort( 0x0 ),	/* 0 */
/* 1026 */	NdrFcShort( 0xfc58 ),	/* Offset= -936 (90) */
/* 1028 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 1030 */	NdrFcShort( 0xfc46 ),	/* Offset= -954 (76) */

			0x0
        }
    };

static const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ] = 
        {
            
            {
            BSTR_UserSize
            ,BSTR_UserMarshal
            ,BSTR_UserUnmarshal
            ,BSTR_UserFree
            },
            {
            VARIANT_UserSize
            ,VARIANT_UserMarshal
            ,VARIANT_UserUnmarshal
            ,VARIANT_UserFree
            }

        };



/* Object interface: IUnknown, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IDownloadManager, ver. 0.0,
   GUID={0x988934A4,0x064B,0x11D3,{0xBB,0x80,0x00,0x10,0x4B,0x35,0xE7,0xF9}} */


/* Standard interface: __MIDL_itf_ComUtilities_0000_0001, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Object interface: IDispatch, ver. 0.0,
   GUID={0x00020400,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: IUtilMan, ver. 0.0,
   GUID={0xDD264321,0x7025,0x476C,{0x8B,0x7A,0x85,0x0E,0x0B,0x79,0xDD,0x41}} */

#pragma code_seg(".orpc")
static const unsigned short IUtilMan_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    0,
    38,
    76,
    120,
    176,
    214,
    258,
    296,
    334,
    372,
    410
    };

static const MIDL_STUBLESS_PROXY_INFO IUtilMan_ProxyInfo =
    {
    &Object_StubDesc,
    ComUtilities__MIDL_ProcFormatString.Format,
    &IUtilMan_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IUtilMan_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    ComUtilities__MIDL_ProcFormatString.Format,
    &IUtilMan_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(18) _IUtilManProxyVtbl = 
{
    &IUtilMan_ProxyInfo,
    &IID_IUtilMan,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* IDispatch::GetTypeInfoCount */ ,
    0 /* IDispatch::GetTypeInfo */ ,
    0 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::get_HWNDInternetExplorerServer */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::put_HWNDInternetExplorerServer */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::HookProcNCode */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::SetupWindowsHook */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::CancelFileDownload */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::DownloadUrlAsync */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::get_HTTPSprotocolManaged */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::put_HTTPSprotocolManaged */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::get_HTTPprotocolManaged */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::put_HTTPprotocolManaged */ ,
    (void *) (INT_PTR) -1 /* IUtilMan::GetScriptObjects */
};


static const PRPC_STUB_FUNCTION IUtilMan_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IUtilManStubVtbl =
{
    &IID_IUtilMan,
    &IUtilMan_ServerInfo,
    18,
    &IUtilMan_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: IManagedAppBridge, ver. 0.0,
   GUID={0xEF49428E,0x8C06,0x4412,{0x8F,0x64,0x1C,0xF7,0x96,0xF0,0xBE,0xDF}} */

#pragma code_seg(".orpc")
static const unsigned short IManagedAppBridge_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    454,
    38,
    510,
    548,
    586,
    624,
    662,
    700,
    738,
    776,
    814,
    852,
    890,
    928
    };

static const MIDL_STUBLESS_PROXY_INFO IManagedAppBridge_ProxyInfo =
    {
    &Object_StubDesc,
    ComUtilities__MIDL_ProcFormatString.Format,
    &IManagedAppBridge_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO IManagedAppBridge_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    ComUtilities__MIDL_ProcFormatString.Format,
    &IManagedAppBridge_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(21) _IManagedAppBridgeProxyVtbl = 
{
    &IManagedAppBridge_ProxyInfo,
    &IID_IManagedAppBridge,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* IDispatch::GetTypeInfoCount */ ,
    0 /* IDispatch::GetTypeInfo */ ,
    0 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::DownloadCompleteManaged */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::DownloadAbortManaged */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_IEServerHwnd */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_URL */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::put_URL */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_RequestHeaders */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_PostData */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_PostDataMimeType */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::put_DownloadData */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_DataMimeType */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::put_DataMimeType */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::get_DownloadCacheFileName */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::put_DownloadCacheFileName */ ,
    (void *) (INT_PTR) -1 /* IManagedAppBridge::DownloadCompleteManagedCache */
};


static const PRPC_STUB_FUNCTION IManagedAppBridge_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _IManagedAppBridgeStubVtbl =
{
    &IID_IManagedAppBridge,
    &IManagedAppBridge_ServerInfo,
    21,
    &IManagedAppBridge_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};


/* Object interface: ICustManageApp, ver. 0.0,
   GUID={0xC43E6EBA,0x1999,0x4089,{0xB9,0xEF,0xEA,0xC4,0x4D,0x4E,0xD6,0x25}} */

#pragma code_seg(".orpc")
static const unsigned short ICustManageApp_FormatStringOffsetTable[] =
    {
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    (unsigned short) -1,
    454,
    38
    };

static const MIDL_STUBLESS_PROXY_INFO ICustManageApp_ProxyInfo =
    {
    &Object_StubDesc,
    ComUtilities__MIDL_ProcFormatString.Format,
    &ICustManageApp_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ICustManageApp_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    ComUtilities__MIDL_ProcFormatString.Format,
    &ICustManageApp_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(9) _ICustManageAppProxyVtbl = 
{
    &ICustManageApp_ProxyInfo,
    &IID_ICustManageApp,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    0 /* IDispatch::GetTypeInfoCount */ ,
    0 /* IDispatch::GetTypeInfo */ ,
    0 /* IDispatch::GetIDsOfNames */ ,
    0 /* IDispatch_Invoke_Proxy */ ,
    (void *) (INT_PTR) -1 /* ICustManageApp::DownloadCompleteCustomApp */ ,
    (void *) (INT_PTR) -1 /* ICustManageApp::DownloadAbortCustomApp */
};


static const PRPC_STUB_FUNCTION ICustManageApp_table[] =
{
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    STUB_FORWARDING_FUNCTION,
    NdrStubCall2,
    NdrStubCall2
};

CInterfaceStubVtbl _ICustManageAppStubVtbl =
{
    &IID_ICustManageApp,
    &ICustManageApp_ServerInfo,
    9,
    &ICustManageApp_table[-3],
    CStdStubBuffer_DELEGATING_METHODS
};

static const MIDL_STUB_DESC Object_StubDesc = 
    {
    0,
    NdrOleAllocate,
    NdrOleFree,
    0,
    0,
    0,
    0,
    0,
    ComUtilities__MIDL_TypeFormatString.Format,
    1, /* -error bounds_check flag */
    0x50002, /* Ndr library version */
    0,
    0x700022b, /* MIDL Version 7.0.555 */
    0,
    UserMarshalRoutines,
    0,  /* notify & notify_flag routine table */
    0x1, /* MIDL flag */
    0, /* cs routines */
    0,   /* proxy/server info */
    0
    };

const CInterfaceProxyVtbl * const _ComUtilities_ProxyVtblList[] = 
{
    ( CInterfaceProxyVtbl *) &_IUtilManProxyVtbl,
    ( CInterfaceProxyVtbl *) &_IManagedAppBridgeProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ICustManageAppProxyVtbl,
    0
};

const CInterfaceStubVtbl * const _ComUtilities_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_IUtilManStubVtbl,
    ( CInterfaceStubVtbl *) &_IManagedAppBridgeStubVtbl,
    ( CInterfaceStubVtbl *) &_ICustManageAppStubVtbl,
    0
};

PCInterfaceName const _ComUtilities_InterfaceNamesList[] = 
{
    "IUtilMan",
    "IManagedAppBridge",
    "ICustManageApp",
    0
};

const IID *  const _ComUtilities_BaseIIDList[] = 
{
    &IID_IDispatch,
    &IID_IDispatch,
    &IID_IDispatch,
    0
};


#define _ComUtilities_CHECK_IID(n)	IID_GENERIC_CHECK_IID( _ComUtilities, pIID, n)

int __stdcall _ComUtilities_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( _ComUtilities, 3, 2 )
    IID_BS_LOOKUP_NEXT_TEST( _ComUtilities, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( _ComUtilities, 3, *pIndex )
    
}

const ExtendedProxyFileInfo ComUtilities_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & _ComUtilities_ProxyVtblList,
    (PCInterfaceStubVtblList *) & _ComUtilities_StubVtblList,
    (const PCInterfaceName * ) & _ComUtilities_InterfaceNamesList,
    (const IID ** ) & _ComUtilities_BaseIIDList,
    & _ComUtilities_IID_Lookup, 
    3,
    2,
    0, /* table of [async_uuid] interfaces */
    0, /* Filler1 */
    0, /* Filler2 */
    0  /* Filler3 */
};
#if _MSC_VER >= 1200
#pragma warning(pop)
#endif


#endif /* defined(_M_AMD64)*/

