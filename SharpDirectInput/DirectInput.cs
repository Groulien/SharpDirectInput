using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SharpDirectInput {
    public class DirectInput {
        protected const int DIRECTINPUT_VERSION = 0x0800;
#region Imports
        protected const string dinputDLL = "dinput8.dll";
        protected const string bridgeDLL = 
        #if DEBUG
            "../../../Debug/DirectInputBridge.dll"; 
        #elif RELEASE
            "DirectInputBridge.dll";
        #else
            #error Trying to build neither debug or release.
        #endif
        [DllImport(dinputDLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int DirectInput8Create(
            IntPtr hinst, 
            uint dwVersion, //C++ DWORD = C++ unsigned long = C# unsigned int
            [In] ref Guid riidltf, 
            ref IntPtr ptr,
            [MarshalAs(UnmanagedType.IUnknown)]object unknown); // = LPUNKNOWN = IUnknown*
        // HRESULT DirectInput8Create(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID* ppvOut, LPUNKNOWN punkouter);

        [DllImport("kernel32.dll")]
        protected static extern IntPtr GetModuleHandle(string lpModuleName);

#endregion Imports
        public DirectInput(uint version = DIRECTINPUT_VERSION) {
            this.Version = version;
        }
        public IntPtr Handle {
            get;
            protected set;
        }
        public uint Version {
            get;
            protected set;
        }
        
        
        public void Setup() {
            IntPtr result = IntPtr.Zero;
            uint v = (uint)Version;
            Guid IID_IDirectInput8W = new Guid(0xBF798031, 0x483A, 0x4DA2, 0xAA, 0x99, 0x5D, 0x64, 0xED, 0x36, 0x97, 0x00);
            if (0 == DirectInput8Create(GetModuleHandle(null), v, ref IID_IDirectInput8W, ref result, null)) {
                this.Handle = result;
            } else {
                throw new Exception();
            }
        }   
    }
}
