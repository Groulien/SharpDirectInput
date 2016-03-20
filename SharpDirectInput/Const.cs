namespace SharpDirectInput {
    /// <summary>
    /// Container class for DLLImport references 
    /// </summary>
    public static class Const {
        /// <summary>
        /// Kernel32 reference.
        /// </summary>
        public const string Kernel32 = "kernel32.dll";
        /// <summary>
        /// DirectInput 8 Library
        /// </summary>
        public const string dinputDLL = "dinput8.dll";
        /// <summary>
        /// Bridge DLL between managed and unmanaged code.
        /// </summary>
        public const string bridgeDLL = 
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
    }
}
