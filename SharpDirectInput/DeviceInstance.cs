namespace SharpDirectInput {
    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Structure with information on DirectInput devices.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DeviceInstance {
        /// <summary>
        /// Maximum length of names. Taken from dinput.h of the SDK.
        /// </summary>
        private const int MAX_PATH = 260;
        /// <summary>
        /// Size of the structure in bytes.
        /// </summary>
        public uint   dwSize;
        /// <summary>
        /// Guid of this instance, used for Device class instances.
        /// </summary>
        public Guid guidInstance;
        /// <summary>
        /// Guid of this product.
        /// </summary>
        public Guid guidProduct;
        /// <summary>
        /// Device type specifier. 
        /// The least-significant byte of the device type description code specifies the device type. 
        /// The next-significant byte specifies the device subtype. 
        /// This value can also be combined with DIDEVTYPE_HID, which specifies a Human Interface Device (human interface device).
        /// </summary>
        public uint dwDevType;
        /// <summary>
        /// Instance name in WCHAR_T format.
        /// </summary>
        public fixed byte tszInstanceName[MAX_PATH * 2];
        /// <summary>
        /// Instance name in WCHAR_T format.
        /// </summary>
        public fixed byte tszProductName[MAX_PATH * 2];
         // DIRECTINPUT_VERSION >= 0x0500
        /// <summary>
        /// Driver for Force Feedback.
        /// </summary>
        public Guid guidFFDriver;
        /// <summary>
        /// If the device is a Human Interface Device (HID), this member contains the HID usage page code.
        /// </summary>
        public ushort wUsagePage;
        /// <summary>
        /// If the device is a Human Interface Device (HID), this member contains the HID usage code.
        /// </summary>
        public ushort wUsage;
        /// <summary>
        /// Gets the instance name.
        /// </summary>
        /// <returns>String</returns>
        public string GetInstanceName() {
            byte[] duplicate = new byte[MAX_PATH * 2];
            int i = 0;
            fixed (byte* raw = tszInstanceName) {
                byte* ptr = raw;
                while (i < duplicate.Length) {
                    duplicate[i] = *ptr;
                    ptr++;
                    i++;
                }
            }
            return Encoding.Unicode.GetString(duplicate).TrimEnd('\0');
        }
        /// <summary>
        /// Gets the product name.
        /// </summary>
        /// <returns>String</returns>
        public string GetProductName() {
            byte[] duplicate = new byte[MAX_PATH * 2];
            int i = 0;
            fixed (byte* raw = tszProductName) {
                byte* ptr = raw;
                while (i < duplicate.Length) {
                    duplicate[i] = *ptr;
                    ptr++;
                    i++;
                }
            }
            return Encoding.Unicode.GetString(duplicate).TrimEnd('\0');
        }
    }
}
