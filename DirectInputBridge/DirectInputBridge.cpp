// DirectInputBridge.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DirectInputBridge.h"
#include <tchar.h>

#include <vector>

DIRECTINPUTBRIDGE_API int __stdcall DirectInputCreate(HINSTANCE hinst, DWORD dwVersion, LPVOID *ppvOut) {
	HRESULT result = DirectInput8Create(hinst, dwVersion, IID_IDirectInput8, ppvOut, NULL);
	return result;
}
DIDEVICEINSTANCE *list;
int listSize = 0;
int listCurrent = 0;
BOOL CALLBACK EnumJoysticksCallback(const DIDEVICEINSTANCE* pdidInstance, VOID* pContext) {
	list[listCurrent] = *pdidInstance;
	listCurrent++;
	if (listCurrent == listSize)
		DIENUM_STOP;
	//DIE = Direct Input ENUMeration
	return DIENUM_CONTINUE;
}

//http://stackoverflow.com/questions/2402978/get-an-array-of-structures-from-native-dll-to-c-sharp-application
DIRECTINPUTBRIDGE_API int __stdcall DI_EnumDevices(IDirectInput8* directInput, unsigned int DI8DEVCLASS, unsigned int DIEDFL, DIDEVICEINSTANCE* array, int* size) {
	list = array;
	listCurrent = 0;
	listSize = *size;
	HRESULT result = directInput->EnumDevices(DI8DEVCLASS, EnumJoysticksCallback, NULL, DIEDFL);
	if (FAILED(result))
		return result;
	*size = listCurrent;
	return result;
}
DIRECTINPUTBRIDGE_API int __stdcall DI_CreateDevice(IDirectInput8* directInput, GUID guid, IDirectInputDevice8** outDevice) {
	//directInput->CreateDevice()

	HRESULT result = directInput->CreateDevice(guid, outDevice, NULL);
	return result;
}
DIRECTINPUTBRIDGE_API int DI_CreateGenericDevice(IDirectInput8* directInput) {
	//directInput->CreateDevice()
	return -1;
}
DIRECTINPUTBRIDGE_API unsigned long DI_Release(IDirectInput8* directInput) {
	return directInput->Release();
}
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
DIRECTINPUTBRIDGE_API int Test() {
	IDirectInput8* ptr;
	if (FAILED(DirectInputCreate(GetModuleHandle(NULL), 0x0800, (void**)&ptr)))
		return -1;
	//if (-1 < DI_EnumDevices(ptr, DI8DEVCLASS_GAMECTRL, DIEDFL_ATTACHEDONLY, NULL, NULL))
		//return -2;
	

	//https://msdn.microsoft.com/en-us/library/windows/desktop/microsoft.directx_sdk.idirectinput8.idirectinput8.enumdevices(v=vs.85).aspx
	//ptr->EnumDevices(DI8DEVCLASS_ALL, EnumJoysticksCallback, NULL, DIEDFL_ATTACHEDONLY);
	
	
	
	ptr->Release();
	return 0;
}