// DirectInputBridge.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DirectInputBridge.h"


// This is an example of an exported variable
DIRECTINPUTBRIDGE_API int nDirectInputBridge=0;

// This is an example of an exported function.
DIRECTINPUTBRIDGE_API int fnDirectInputBridge(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see DirectInputBridge.h for the class definition
CDirectInputBridge::CDirectInputBridge()
{
	return;
}
