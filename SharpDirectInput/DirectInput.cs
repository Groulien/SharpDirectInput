namespace SharpDirectInput {
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// EntryPoint to the DirectInput API, classes and functions.
    /// </summary>
    public class DirectInput : IDisposable {
        /// <summary>
        /// Latest version of DirectInput.
        /// </summary>
        protected const uint DIRECTINPUT_LATEST_VERSION = 0x0800;
        /// <summary>
        /// Gets the Module Handle of named module.
        /// </summary>
        /// <param name="lpModuleName">Name of the module to get a handle for. Pass NULL for current module.</param>
        /// <returns>Handle of the current module.</returns>
        [DllImport(Const.Kernel32)]
        protected static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Creates a new instance of DirectInput.
        /// </summary>
        /// <param name="version">Version of DirectInput to target.</param>
        public DirectInput(uint version = DIRECTINPUT_LATEST_VERSION) {
            this.Version = version;
        }
        ~DirectInput() {
            Dispose();
        }
        /// <summary>
        /// Pointer to the unmanaged DirectInput objct.
        /// </summary>
        public IntPtr Handle {
            get;
            protected set;
        }
        /// <summary>
        /// Version of DirectInput.
        /// </summary>
        public uint Version {
            get;
            protected set;
        }
#if LEGACY
        // This code was used for jumping directly into DirectInput.

        [DllImport(Const.dinputDLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int DirectInput8Create(
            IntPtr hinst,
            uint dwVersion, //C++ DWORD = C++ unsigned long = C# unsigned int
            [In] ref Guid riidltf,
            ref IntPtr ptr,
            [MarshalAs(UnmanagedType.IUnknown)]object unknown); // = LPUNKNOWN = IUnknown*
        // HRESULT DirectInput8Create(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID* ppvOut, LPUNKNOWN punkouter);
        //(0 <= DirectInput8Create(GetModuleHandle(null), Version, ref IID_IDirectInput8W, ref result, null))
#endif
        /// <summary>
        /// Create an instance of DirectInput.
        /// </summary>
        /// <param name="handleInstance">Handle to the application module instance.</param>
        /// <param name="dwVersion">Version of DirectInput</param>
        /// <param name="directInput">Handle to a DirectInput instance</param>
        /// <returns>Error if less than 0.</returns>
        [DllImport(Const.bridgeDLL, CallingConvention = CallingConvention.StdCall)]
        protected static extern int DirectInputCreate(IntPtr handleInstance, uint dwVersion, out IntPtr directInput);
        /// <summary>
        /// Creates the internal DirectInput handle.
        /// </summary>
        public void Setup() {
            IntPtr handle;
            int result = DirectInputCreate(GetModuleHandle(null), this.Version, out handle);
            if (result >= 0) {
                this.Handle = handle;
            } else {
                throw new Exception("Error code " + result.ToString());
            }
        }

        /// <summary>
        /// Enumerates and returns DirectInput devices of specified class and filtered by flags.
        /// </summary>
        /// <param name="directInput">Handle to DirectInput</param>
        /// <param name="DI8DEVCLASS">Device Class to enumerate for.</param>
        /// <param name="DIEDFL">Flag to filter with.</param>
        /// <param name="array">Array to store information in.</param>
        /// <param name="count">[IN] Size of input array, [OUT] number of devices in array.</param>
        /// <returns>Error if less than 0.</returns>
        [DllImport(Const.bridgeDLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        protected static extern int DI_EnumDevices(IntPtr directInput, uint DI8DEVCLASS, uint DIEDFL, [In, Out] DeviceInstance[] array, ref int count);
        /// <summary>
        /// Gets device information.
        /// </summary>
        /// <returns></returns>
        public DeviceInstance[] ListDevices(DeviceClass deviceType = DeviceClass.All, DeviceFlag flags = DeviceFlag.AttachedOnly) {
            DeviceInstance[] array = new DeviceInstance[50];
            int l = array.Length;
            int result = DI_EnumDevices(Handle, (uint)deviceType, (uint)flags, array, ref l);
            if (result >= 0) {
                if (l != array.Length)
                    Array.Resize(ref array, l);
                return array;
            }
            throw new Exception("Error code "+result.ToString());
            
        }
        /// <summary>
        /// Creates a DirectInput Device for specified guid.
        /// </summary>
        /// <param name="directInput">DirectInput instance.</param>
        /// <param name="guid">Instance guid of the device.</param>
        /// <param name="device">Output pointer to the unmanaged device class.</param>
        /// <returns></returns>
        [DllImport(Const.bridgeDLL, CallingConvention = CallingConvention.StdCall)]
        protected static extern int DI_CreateDevice(IntPtr directInput, Guid guid, ref IntPtr device);
        /// <summary>
        /// Creates a DirectInput Device based on an instance Guid.
        /// </summary>
        /// <param name="guid">Instance Guid of the device to create.</param>
        /// <returns></returns>
        public DirectInput8Device CreateDevice(Guid guid) {
            IntPtr deviceHandle = IntPtr.Zero;
            int result = DI_CreateDevice(Handle, guid, ref deviceHandle);
            if (result >= 0 && !IntPtr.Zero.Equals(deviceHandle))
                return new DirectInput8Device(deviceHandle);
            throw new Exception("Error code " + result.ToString());
        }
        /// <summary>
        /// Creates a DirectInput Device of specified device class.
        /// </summary>
        /// <param name="devClass">Class to create instance for.</param>
        /// <returns>DirectInput Device</returns>
        public DirectInput8Device CreateDevice(DeviceClass devClass) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Releases the handle to unmanaged DirectInput object.
        /// </summary>
        /// <param name="directInputHandle">Handle to release.</param>
        /// <returns>0 or positive on success.</returns>
        [DllImport(Const.bridgeDLL, CallingConvention = CallingConvention.StdCall)]
        protected static extern uint DI_Release(IntPtr directInputHandle); 
        /// <summary>
        /// Releases the handle to unmanaged DirectInput object.
        /// </summary>
        public uint Release() {
            uint result = 0;
            if (!IntPtr.Zero.Equals(Handle)) {
                result = DI_Release(Handle);
                Handle = IntPtr.Zero;
            }
            return result;
        }
        /// <summary>
        /// Disposes of the DirectInput object.
        /// </summary>
        public void Dispose() {
            Release();
        }
    }
}
