// DirectInputBridge.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DirectInputBridge.h"
#include <tchar.h>

DIRECTINPUTBRIDGE_API ULONG __stdcall Release(IUnknown* ptr) {
	return ptr->Release();
}
DIRECTINPUTBRIDGE_API void __stdcall Test() {

#ifdef TEST
	DI8DEVTYPE_1STPERSON,
		// First-person action game device. The following subtypes are defined.
		DI8DEVTYPE1STPERSON_LIMITED,
		// Device that does not provide the minimum number of device objects for action mapping.
		DI8DEVTYPE1STPERSON_SHOOTER,
		// Device designed for first-person shooter games.
		DI8DEVTYPE1STPERSON_SIXDOF,
		// Device with six degrees of freedom; that is, three lateral axes and three rotational axes.
		DI8DEVTYPE1STPERSON_UNKNOWN,
		// Unknown subtype.

	DI8DEVTYPE_DEVICE,
	// Device that does not fall into another category.
	
	DI8DEVTYPE_DEVICECTRL,
		// Input device used to control another type of device from within the context of the application. The following subtypes are defined.
		DI8DEVTYPEDEVICECTRL_COMMSSELECTION,
		// Control used to make communications selections.
		DI8DEVTYPEDEVICECTRL_COMMSSELECTION_HARDWIRED,
		// Device that must use its default configuration and cannot be remapped.
		DI8DEVTYPEDEVICECTRL_UNKNOWN,
		// Unknown subtype.

	DI8DEVTYPE_DRIVING,
	// Device for steering. The following subtypes are defined.
		DI8DEVTYPEDRIVING_COMBINEDPEDALS,
		// Steering device that reports acceleration and brake pedal values from a single axis.
		DI8DEVTYPEDRIVING_DUALPEDALS,
		// Steering device that reports acceleration and brake pedal values from separate axes.
		DI8DEVTYPEDRIVING_HANDHELD,
		// Hand-held steering device.
		DI8DEVTYPEDRIVING_LIMITED,
		// Steering device that does not provide the minimum number of device objects for action mapping.
		DI8DEVTYPEDRIVING_THREEPEDALS,
		// Steering device that reports acceleration, brake, and clutch pedal values from separate axes.

	DI8DEVTYPE_FLIGHT,
	// Controller for flight simulation. The following subtypes are defined.
		DI8DEVTYPEFLIGHT_LIMITED,
		// Flight controller that does not provide the minimum number of device objects for action mapping.
		DI8DEVTYPEFLIGHT_RC,
		// Flight device based on a remote control for model aircraft.
		DI8DEVTYPEFLIGHT_STICK,
		// Joystick.
		DI8DEVTYPEFLIGHT_YOKE,
		// Yoke.

	DI8DEVTYPE_GAMEPAD,
	// Gamepad. The following subtypes are defined.
		DI8DEVTYPEGAMEPAD_LIMITED,
		// Gamepad that does not provide the minimum number of device objects for action mapping.
		DI8DEVTYPEGAMEPAD_STANDARD,
		// Standard gamepad that provides the minimum number of device objects for action mapping.
		DI8DEVTYPEGAMEPAD_TILT,
		// Gamepad that can report x-axis and y-axis data based on the attitude of the controller.

	DI8DEVTYPE_JOYSTICK,
	// Joystick. The following subtypes are defined.
		DI8DEVTYPEJOYSTICK_LIMITED,
		// Joystick that does not provide the minimum number of device objects for action mapping.
		DI8DEVTYPEJOYSTICK_STANDARD,
		// Standard joystick that provides the minimum number of device objects for action mapping.

	DI8DEVTYPE_KEYBOARD,
	// Keyboard or keyboard-like device. The following subtypes are defined.
		DI8DEVTYPEKEYBOARD_UNKNOWN,
		// Subtype could not be determined.
		DI8DEVTYPEKEYBOARD_PCXT,
		// IBM PC/XT 83-key keyboard.
		DI8DEVTYPEKEYBOARD_OLIVETTI,
		// Olivetti 102-key keyboard.
		DI8DEVTYPEKEYBOARD_PCAT,
		// IBM PC/AT 84-key keyboard.
		DI8DEVTYPEKEYBOARD_PCENH,
		// IBM PC Enhanced 101/102-key or Microsoft Natural keyboard.
		DI8DEVTYPEKEYBOARD_NOKIA1050,
		// Nokia 1050 keyboard.
		DI8DEVTYPEKEYBOARD_NOKIA9140,
		// Nokia 9140 keyboard.
		DI8DEVTYPEKEYBOARD_NEC98,
		// Japanese NEC PC98 keyboard.
		DI8DEVTYPEKEYBOARD_NEC98LAPTOP,
		// Japanese NEC PC98 laptop keyboard.
		DI8DEVTYPEKEYBOARD_NEC98106,
		// Japanese NEC PC98 106-key keyboard.
		DI8DEVTYPEKEYBOARD_JAPAN106,
		// Japanese 106-key keyboard.
		DI8DEVTYPEKEYBOARD_JAPANAX,
		// Japanese AX keyboard.
		DI8DEVTYPEKEYBOARD_J3100,
		// Japanese J3100 keyboard.

	DI8DEVTYPE_MOUSE,
	// A mouse or mouse-like device (such as a trackball). The following subtypes are defined.
		DI8DEVTYPEMOUSE_ABSOLUTE,
		// Mouse that returns absolute axis data.
		DI8DEVTYPEMOUSE_FINGERSTICK,
		// Fingerstick.
		DI8DEVTYPEMOUSE_TOUCHPAD,
		// Touchpad.
		DI8DEVTYPEMOUSE_TRACKBALL,
		// Trackball.
		DI8DEVTYPEMOUSE_TRADITIONAL,
		// Traditional mouse.
		DI8DEVTYPEMOUSE_UNKNOWN,
		// Subtype could not be determined.

	DI8DEVTYPE_REMOTE,
	// Remote-control device. The following subtype is defined.
		DI8DEVTYPEREMOTE_UNKNOWN,
		// Subtype could not be determined.

	DI8DEVTYPE_SCREENPOINTER,
	// Screen pointer. The following subtypes are defined.
		DI8DEVTYPESCREENPTR_UNKNOWN,
		// Unknown subtype.
		DI8DEVTYPESCREENPTR_LIGHTGUN,
		// Light gun.
		DI8DEVTYPESCREENPTR_LIGHTPEN,
		// Light pen.
		DI8DEVTYPESCREENPTR_TOUCH,
		// Touch screen.

	DI8DEVTYPE_SUPPLEMENTAL,
	// Specialized device with functionality unsuitable for the main control of an application, such as pedals used with a wheel. The following subtypes are defined.
		DI8DEVTYPESUPPLEMENTAL_2NDHANDCONTROLLER,
		// Secondary handheld controller.
		DI8DEVTYPESUPPLEMENTAL_COMBINEDPEDALS,
		// Device whose primary function is to report acceleration and brake pedal values from a single axis.
		DI8DEVTYPESUPPLEMENTAL_DUALPEDALS,
		// Device whose primary function is to report acceleration and brake pedal values from separate axes.
		DI8DEVTYPESUPPLEMENTAL_HANDTRACKER,
		// Device that tracks hand movement.
		DI8DEVTYPESUPPLEMENTAL_HEADTRACKER,
		// Device that tracks head movement.
		DI8DEVTYPESUPPLEMENTAL_RUDDERPEDALS,
		// Device with rudder pedals.
		DI8DEVTYPESUPPLEMENTAL_SHIFTER,
		// Device that reports gear selection from an axis.
		DI8DEVTYPESUPPLEMENTAL_SHIFTSTICKGATE,
		// Device that reports gear selection from button states.
		DI8DEVTYPESUPPLEMENTAL_SPLITTHROTTLE,
		// Device whose primary function is to report at least two throttle values. It may have other controls.
		DI8DEVTYPESUPPLEMENTAL_THREEPEDALS,
		// Device whose primary function is to report acceleration, brake, and clutch pedal values from separate axes.
		DI8DEVTYPESUPPLEMENTAL_THROTTLE,
		// Device whose primary function is to report a single throttle value. It may have other controls.
		DI8DEVTYPESUPPLEMENTAL_UNKNOWN
		// Unknown subtype
#endif
}