using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SharpDirectInput {
    public class DirectInput8Device : IDirectInputDevice {
        private IntPtr deviceHandle;

        public DirectInput8Device(IntPtr deviceHandle) {
            if (IntPtr.Zero.Equals(deviceHandle))
                throw new ArgumentException("deviceHandle cannot be empty.");
            this.Handle = deviceHandle;
        }

        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_SetDataFormatEnum(IntPtr device, uint format);
        public void SetDataFormat(DataFormat format) {
            DE_SetDataFormatEnum(Handle, (uint)format);
        }
        public DataFormat Format {
            get;
            set;
        }

        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Acquire(IntPtr device);
        public void Acquire() {
            //TODO: resolve
            DE_Acquire(Handle);
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Unacquire(IntPtr device);
        public void Unacquire() {
            DE_Unacquire(Handle);
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Release(IntPtr device);
        public void Release() {
            if (!IntPtr.Zero.Equals(Handle)) {
                this.Unacquire();
                DE_Release(Handle);
                this.Handle = IntPtr.Zero;
            }
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_GetState(IntPtr device, int structSize, ref object structure);
        public bool Update() {
            DataFormat format = DataFormat.Mouse2;
            Type t;
            object data;
            switch (format) {
            case DataFormat.Joystick:
                t = typeof(JoyState);
                data = new JoyState();
                break;
            case DataFormat.Joystick2:
                data = new JoyState2();
                break;
            case DataFormat.Keyboard:
                data = new KeyboardState();
                break;

            case DataFormat.Mouse:
                data = new MouseState();
                break;
            case DataFormat.Mouse2:
                data = new MouseState2();
                break;
            default:
                return false;
            }
            DE_GetState(Handle, Marshal.SizeOf(data), ref data);
            return true;
        }
        public IntPtr Handle {
            get;
            protected set;
        }

        public void Dispose() {
            Release();
        }
    }
}
