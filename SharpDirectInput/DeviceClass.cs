namespace SharpDirectInput {
    /// <summary>
    /// The type of device, also known as DI8DEVCLASS.
    /// </summary>
    public enum DeviceClass : uint{
        /// <summary>
        /// Gets any and all devices even if not applicable for DirectInput.
        /// </summary>
        All             = 0,
        /// <summary>
        /// All devices that do not fall in another class.
        /// </summary>
        Device          = 1,
        /// <summary>
        /// All devices of type DI8DEVTYPE_MOUSE and DI8DEVTYPE_SCREENPOINTER.
        /// </summary>
        Pointer         = 2,
        /// <summary>
        /// All keyboards.
        /// </summary>
        Keyboard        = 3,
        /// <summary>
        /// Alls Joysticks and Controllers/Gamepads.
        /// </summary>
        GameController  = 4
    }
}
