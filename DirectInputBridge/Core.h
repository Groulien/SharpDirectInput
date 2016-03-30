#pragma once
#ifndef CORE_H
#define CORE_H
#include "DirectInputBridge.h"
extern "C" {
	// 1. DirectInput itself
	DIRECTINPUTBRIDGE_API int __stdcall DirectInputCreate(HINSTANCE hinst, DWORD dwVersion, LPVOID *ppvOut);
	// 2. DirectInput actions 
	DIRECTINPUTBRIDGE_API int __stdcall DI_EnumDevices(IDirectInput8* directInput, unsigned int DI8DEVCLASS, unsigned int DIEDFL, DIDEVICEINSTANCE* array, int* size);
	DIRECTINPUTBRIDGE_API int __stdcall DI_CreateDevice(IDirectInput8* directInput, GUID guid, IDirectInputDevice8** outDevice);
}
#endif