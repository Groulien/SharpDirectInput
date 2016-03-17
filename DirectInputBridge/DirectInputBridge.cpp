// DirectInputBridge.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DirectInputBridge.h"
#include <tchar.h>




// This is an example of an exported variable
DIRECTINPUTBRIDGE_API int nDirectInputBridge=0;

// This is an example of an exported function.
DIRECTINPUTBRIDGE_API int fnDirectInputBridge(void)
{
	
	IDirectInput8* di = 0;
	DirectInput8Create(GetModuleHandle(NULL), DIRECTINPUT_VERSION, IID_IDirectInput8, (void**)&di, NULL);
	return 42;
}
DIRECTINPUTBRIDGE_API int alphaBetaGamma(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID *ppvOut, LPUNKNOWN punkOuter) {
	MessageBox(NULL, _T("Hello"), _T("Hello"), NULL);
	HRESULT result = DirectInput8Create(hinst, dwVersion, riidltf, ppvOut, punkOuter);
	return result;
}
// This is the constructor of a class that has been exported.
// see DirectInputBridge.h for the class definition
CDirectInputBridge::CDirectInputBridge()
{
	return;
}
