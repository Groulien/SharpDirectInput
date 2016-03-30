#pragma once
#ifndef Device_H
#define Device_H
#include "DirectInputBridge.h"

extern "C" {
	DIRECTINPUTBRIDGE_API int __stdcall DE_GetCapabilities(IDirectInputDevice8* device, DIDEVCAPS* devCaps);
	DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormat(IDirectInputDevice8* device, LPCDIDATAFORMAT format);
	DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormatEnum(IDirectInputDevice8* device, int format); 	//Enum variant.
	DIRECTINPUTBRIDGE_API int __stdcall DE_Acquire(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_Unacquire(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_Poll(IDirectInputDevice8* device);
	DIRECTINPUTBRIDGE_API int __stdcall DE_GetDeviceState(IDirectInputDevice8* device, DWORD stateSize, LPVOID stateStruct);
	DIRECTINPUTBRIDGE_API int __stdcall DE_SetCooperationLevel(IDirectInputDevice8* device, HWND handle, DWORD flags);
}

#endif