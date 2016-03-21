namespace SharpDirectInput {
    /// <summary>
    /// Flags used when enumeration devices.
    /// </summary>
    public enum DeviceFlag : ulong {
        /// <summary>
        /// All installed devices.
        /// </summary>
        AllDevices      = 0x00000000,
        /// <summary>
        /// Only devices currently attached.
        /// </summary>
        AttachedOnly    = 0x00000001,
        /// <summary>
        /// Only Devices that support ForceFeedback.
        /// DirectInput 5 and higher.
        /// </summary>
        ForceFeedback   = 0x00000100,
        /// <summary>
        /// Include devices that are aliases for other devices.
        /// DirectInput 5.0.10 and higher.
        /// </summary>
        IncludeAliases  = 0x00010000,
        /// <summary>
        /// Include placeholder AKA Phantom devices.
        /// DirectInput 5.0.10 and higher.
        /// </summary>
        IncludePhantoms = 0x00020000,
         /// <summary>
         /// Include 'hidden' devices.
        /// DirectInput 8 and higher.
        /// </summary>
        IncludeHidden   = 0x000400000
    }
}
