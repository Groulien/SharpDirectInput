#include "stdafx.h"
#include "Core.h"

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