// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently,
// but are changed infrequently

#pragma once

#ifndef STRICT
#define STRICT
#endif

// Modify the following defines if you have to target a platform prior to the ones specified below.
// Refer to MSDN for the latest info on corresponding values for different platforms.
#ifndef WINVER				// Allow use of features specific to Windows XP or later.
#define WINVER 0x0501		// Change this to the appropriate value to target other versions of Windows.
#endif

#ifndef _WIN32_WINNT		// Allow use of features specific to Windows XP or later.                   
#define _WIN32_WINNT 0x0501	// Change this to the appropriate value to target other versions of Windows.
#endif						

#ifndef _WIN32_WINDOWS		// Allow use of features specific to Windows 98 or later.
#define _WIN32_WINDOWS 0x0410 // Change this to the appropriate value to target Windows Me or later.
#endif

#ifndef _WIN32_IE			// Allow use of features specific to IE 6.0 or later.
#define _WIN32_IE 0x0700	// Change this to the appropriate value to target other versions of IE.
#endif

#define _ATL_APARTMENT_THREADED
#define _ATL_NO_AUTOMATIC_NAMESPACE

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

//To disable warning C4996 - wcscpy, _itow
//This function or variable may be unsafe. Consider using xxxxx_s instead. To disable deprecation, use _CRT_SECURE_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS

#include "resource.h"
#include <atlbase.h>
#include <atlcom.h>
#include "CriticalSectionWrapper.h"
//#include <atlstr.h>

extern CCriticalSectionWrapper gb_CritSectWrapper;

//gCtrlInstances keeps track of each instance of our control
//This global is needed due to the fact that a client may place
//this control on more than one form/dlg or have multiple instances of BW
//hosting in one control. In this case, using one
//global ptr to our control will cause the events to be routed to the
//first control, not the one we want. The control instances (this) is
//added to this array in Constructor and removed in Destructor.
extern ATL::CSimpleArray<void*> gCtrlInstances;
//Pointer to the first CUtilMan instance
extern LPVOID gMainCtrlInstance;
//Flag to track registering and unregistering of HTTP/HTTPS protocols
//Can only be done once per DLL load. Effects all instances of WB.
extern BOOL gb_IsHttpRegistered;
extern BOOL gb_IsHttpsRegistered;
//Protocol handling
extern ATL::CComPtr<IClassFactory> gb_spCFHTTP;
extern ATL::CComPtr<IClassFactory> gb_spCFHTTPS;
//Used in CUtilMan::SetupWindowsHook to setup hooks
extern HINSTANCE gb_thisInstance;

using namespace ATL;

