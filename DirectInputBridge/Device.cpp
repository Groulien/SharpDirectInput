#include "stdafx.h"
#include "Device.h"
//
// Devices
//
DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormat(IDirectInputDevice8* device, LPCDIDATAFORMAT format) {
	return device->SetDataFormat(format);
}
//Enum variant.
DIRECTINPUTBRIDGE_API int __stdcall DE_SetDataFormatEnum(IDirectInputDevice8* device, int format) {
	static DIDATAFORMAT formats[5] {
		c_dfDIKeyboard,
			c_dfDIMouse,
			c_dfDIMouse2,
			c_dfDIJoystick,
			c_dfDIJoystick2
	};

	if (format < 0 || format >= 5) {
		return -1;
	}
	return DE_SetDataFormat(device, &formats[format]);

}
DIRECTINPUTBRIDGE_API int __stdcall DE_GetDeviceState(IDirectInputDevice8* device, DWORD stateSize, LPVOID stateStruct) {
	return device->GetDeviceState(stateSize, stateStruct);
}
DIRECTINPUTBRIDGE_API int __stdcall DE_Acquire(IDirectInputDevice8* device) {
	return device->Acquire();
}
DIRECTINPUTBRIDGE_API int __stdcall DE_Unacquire(IDirectInputDevice8* device) {
	return device->Unacquire();
}
DIRECTINPUTBRIDGE_API int __stdcall DE_GetCapabilities(IDirectInputDevice8* device, DIDEVCAPS* caps) {
	return device->GetCapabilities(caps);
}
DIRECTINPUTBRIDGE_API int __stdcall DE_Poll(IDirectInputDevice8* device) {
	return device->Poll();
}
DIRECTINPUTBRIDGE_API int __stdcall DE_SetCooperationLevel(IDirectInputDevice8* device, HWND handle, DWORD flags) {
	flags = DISCL_BACKGROUND | DISCL_EXCLUSIVE;
	return device->SetCooperativeLevel(handle, flags);
}