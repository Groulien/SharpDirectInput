namespace SharpDirectInput {
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Container class for DLLImport references 
    /// </summary>
    internal static class Win32 {
        /// <summary>
        /// Kernel32 reference.
        /// </summary>
        public const string Kernel32 = "kernel32.dll";
        /// <summary>
        /// DirectInput 8 Library
        /// </summary>
        public const string DirectInput = "dinput8.dll";
        /// <summary>
        /// Bridge DLL between managed and unmanaged code.
        /// </summary>
        public const string Bridge = 
    #if DEBUG
            // Relative path for easy debugging.
            "../../../Debug/DirectInputBridge.dll";
    #elif RELEASE
            // Release version should have the bridge next to the DLL.
            "DirectInputBridge.dll";
    #else
            // Precautionary error.
            #error Trying to build neither debug or release.
    #endif
        /// <summary>
        /// Releases a reference to an unmanaged object.
        /// </summary>
        /// <param name="IUnknown">Object to release.</param>
        /// <returns>Current number of references.</returns>
        [DllImport(Bridge, CallingConvention=CallingConvention.StdCall)]
        public static extern uint Release(IntPtr IUnknown);

        /// <summary>
        /// Gets the Module Handle of named module.
        /// </summary>
        /// <param name="lpModuleName">Name of the module to get a handle for. Pass NULL for current module.</param>
        /// <returns>Handle of the current module.</returns>
        [DllImport(Kernel32)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
