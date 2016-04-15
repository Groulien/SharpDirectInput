using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpDirectInput {
    public enum DeviceType {
        
        //https://msdn.microsoft.com/en-us/library/windows/desktop/microsoft.directx_sdk.reference.dideviceinstance(v=vs.85).aspx
        /// <summary>
        /// Gamepad base type, subtypes are defined.
        /// </summary>
        Gamepad =            0x15,
        /// <summary>
        /// Gamepad that does not provide the minimum number of device objects for action mapping.
        /// </summary>
        GamepadLimited =    0x15 | (1 << 16) | (1 << 8),
        /// <summary>
        /// Standard gamepad that provides the minimum number of device objects for action mapping. 
        /// </summary>
        GamepadStandard =   0x15 | (1 << 16) | (2 << 8),
        /// <summary>
        /// Gamepad that can report x-axis and y-axis data based on the attitude of the controller.
        /// <summary>
        GamepadTilt =        0x15 | (1 << 16) | (3 << 8),

        /// <summary>
        /// Miscellaneous device which does not fall into another category.
        /// </summary>
        Device = 0x11,

        /// <summary>
        ///  Joystick, subtypes are defined.
        /// </summary>
        Joystick = 0x14,
        /// <summary>
        /// Joystick that does not provide the minimum number of device objects for action mapping.
        /// </summary>
        JoystickLimited = 1 << 8,
        /// <summary>
        /// Standard joystick that provides the minimum number of device objects for action mapping.
        /// </summary>
        JoystickStandard = 2 << 8,

        Keyboard = 0x13,

        Mouse = 0x12,

        Remote = 0x1B,

        Supplemental= 0x1C,

        FlagHumanInterfaceDevice = (1 << 16)
    }
}
