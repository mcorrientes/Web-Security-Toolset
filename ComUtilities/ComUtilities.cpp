// ComUtilities.cpp : Implementation of DLL Exports.


#include "stdafx.h"
#include "resource.h"
#include "ComUtilities.h"

CCriticalSectionWrapper gb_CritSectWrapper;
CSimpleArray<void*> gCtrlInstances;
LPVOID gMainCtrlInstance;
BOOL gb_IsHttpRegistered;
BOOL gb_IsHttpsRegistered;
CComPtr<IClassFactory> gb_spCFHTTP;
CComPtr<IClassFactory> gb_spCFHTTPS;
HINSTANCE gb_thisInstance;

class CComUtilitiesModule : public CAtlDllModuleT< CComUtilitiesModule >
{
public :
	DECLARE_LIBID(LIBID_ComUtilitiesLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_COMUTILITIES, "{B35CD94C-3877-41D3-936C-9E1683C6182D}")
};

CComUtilitiesModule _AtlModule;


#ifdef _MANAGED
#pragma managed(push, off)
#endif

// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
    if (dwReason == DLL_PROCESS_ATTACH)
    {
		//Default is false
		gb_IsHttpRegistered = FALSE;
		gb_IsHttpsRegistered = FALSE;
		gMainCtrlInstance = NULL;
		gb_thisInstance = hInstance;
		// Initialize COM library
		OleInitialize(NULL);
    }
    else if (dwReason == DLL_PROCESS_DETACH)
	{
		// Release COM library
	    OleUninitialize();
		//Any registered HTTPProtocol + HTTPSProtocol
		//will be unregistered once we are done here
		if(gCtrlInstances.GetSize() > 0)
		{
			for(int i = 0; i < gCtrlInstances.GetSize(); i++)
				gCtrlInstances[i] = NULL;
		}
		gCtrlInstances.RemoveAll();
		gb_thisInstance = NULL;
	}

	hInstance;
    return _AtlModule.DllMain(dwReason, lpReserved); 
}

#ifdef _MANAGED
#pragma managed(pop)
#endif




// Used to determine whether the DLL can be unloaded by OLE
STDAPI DllCanUnloadNow(void)
{
    return _AtlModule.DllCanUnloadNow();
}


// Returns a class factory to create an object of the requested type
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _AtlModule.DllGetClassObject(rclsid, riid, ppv);
}


// DllRegisterServer - Adds entries to the system registry
STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    HRESULT hr = _AtlModule.DllRegisterServer();
	return hr;
}


// DllUnregisterServer - Removes entries from the system registry
STDAPI DllUnregisterServer(void)
{
	HRESULT hr = _AtlModule.DllUnregisterServer();
	return hr;
}

