namespace SharpDirectInput {
    /// <summary>
    /// Default Data Formats used by DirectInput
    /// </summary>
    public enum DataFormat {
        /// <summary>
        /// Invalid, the data format has not (yet) been specified.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Data for up to 255 keys.
        /// </summary>
        Keyboard = 0,
        /// <summary>
        /// Data for XYZ and up to 4 buttons, maps to MouseState structure.
        /// </summary>
        Mouse = 1,
        /// <summary>
        /// Data for XYZ and up to 8 buttons, maps to MouseState2 structure.
        /// </summary>
        Mouse2 = 2,
        /// <summary>
        /// Maps to JoyState structure.
        /// </summary>
        Joystick = 3,
        /// <summary>
        /// Maps to JoyState2 structure.
        /// </summary>
        Joystick2 = 4
    }
}
