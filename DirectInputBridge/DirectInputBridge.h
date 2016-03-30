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

// Target version:
#define DIRECTINPUT_VERSION 0x0800

#pragma comment(lib, "dinput8.lib")
#pragma comment(lib, "dxguid.lib")
#include <inttypes.h>
#include <dinput.h>
#include <string>

extern "C" {
	DIRECTINPUTBRIDGE_API ULONG __stdcall Release(IUnknown* ptr);
	DIRECTINPUTBRIDGE_API void __stdcall Test();
}