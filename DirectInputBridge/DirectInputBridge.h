// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the DIRECTINPUTBRIDGE_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// DIRECTINPUTBRIDGE_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef DIRECTINPUTBRIDGE_EXPORTS
#define DIRECTINPUTBRIDGE_API __declspec(dllexport)
#else
#define DIRECTINPUTBRIDGE_API __declspec(dllimport)
#endif

#pragma comment(lib, "dinput8.lib")
#pragma comment(lib, "dxguid.lib")
#include <inttypes.h>
#include <dinput.h>
#include <string>

extern "C" {
	// 1. DirectInput itself
	DIRECTINPUTBRIDGE_API ULONG __stdcall Release(IUnknown* ptr);
	DIRECTINPUTBRIDGE_API int __stdcall DirectInputCreate(HINSTANCE hinst, DWORD dwVersion, LPVOID *ppvOut);
	// 2. DirectInput actions 
	DIRECTINPUTBRIDGE_API unsigned long DI_Release(IDirectInput8* directInput);
	DIRECTINPUTBRIDGE_API int __stdcall DI_EnumDevices(IDirectInput8* directInput, unsigned int DI8DEVCLASS, unsigned int DIEDFL, DIDEVICEINSTANCE* array, int* size);
	DIRECTINPUTBRIDGE_API int __stdcall DI_CreateDevice(IDirectInput8* directInput, GUID guid, IDirectInputDevice8** outDevice);
	
	// 3. Device actions
	DIRECTINPUTBRIDGE_API int __stdcall DE_GetCapabilities(IDirectInputDevice8* device, DIDEVCAPS* devCaps);
	DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormat(IDirectInputDevice8* device, LPCDIDATAFORMAT format);
	DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormatEnum(IDirectInputDevice8* device, int format); 	//Enum variant.
	DIRECTINPUTBRIDGE_API int __stdcall DE_Acquire(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_Unacquire(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_Poll(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_GetDeviceState(IDirectInputDevice8* device, DWORD stateSize, LPVOID stateStruct);
	

	//4. Test
	DIRECTINPUTBRIDGE_API int Test();
}