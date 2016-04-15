using DWORD = System.UInt32;
using System.Runtime.InteropServices;
namespace SharpDirectInput {
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceCaps {
        internal static DeviceType[] stereotypes = new DeviceType[] {
            DeviceType.Keyboard,    
            DeviceType.Mouse,
            DeviceType.Gamepad,
            DeviceType.Joystick,
            DeviceType.Remote,
            DeviceType.Supplemental
        };
        public DWORD   dwSize;
        public DWORD   dwFlags;
        public DWORD   dwDevType;
        public DWORD   dwAxes;
        public DWORD   dwButtons;
        public DWORD   dwPOVs;
        // DIRECTINPUT_VERSION >= 0x0500
        public DWORD   dwFFSamplePeriod;
        public DWORD   dwFFMinTimeResolution;
        public DWORD   dwFirmwareRevision;
        public DWORD   dwHardwareRevision;
        public DWORD   dwFFDriverVersion;


        public DeviceType GetBaseDeviceType() {
            DeviceType type = (DeviceType)dwDevType;
            for (int i = 0; i < stereotypes.Length; i++) {
                if ((type & stereotypes[i]) == stereotypes[i]) // faster than HasFlag.
                    return stereotypes[i];
            }
            return DeviceType.Device;
        }
        public DataFormat GetDataFormat() {
            switch (this.GetBaseDeviceType()) {
            case DeviceType.Keyboard:
                return DataFormat.Keyboard;
            case DeviceType.Mouse:
                return DataFormat.Mouse2;
            case DeviceType.Gamepad:
            case DeviceType.Joystick:
                return DataFormat.Joystick2;
            default:
                return DataFormat.Invalid;
            }
        }
    }
}
