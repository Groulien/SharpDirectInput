using DWORD = System.UInt32;
using System.Runtime.InteropServices;
namespace SharpDirectInput {
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceCaps {
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
    }
}
