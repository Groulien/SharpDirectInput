﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SharpDirectInput {
    public class DirectInput8Device : IDirectInputDevice {
        public IntPtr Handle {
            get;
            protected set;
        }
        public object State {
            get;
            protected set;
        }
        public DirectInput8Device(IntPtr deviceHandle) {
            if (IntPtr.Zero.Equals(deviceHandle))
                throw new ArgumentException("deviceHandle cannot be empty.");
            Handle = deviceHandle;
            Format = DataFormat.Invalid;
        }

        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_SetDataFormatEnum(IntPtr device, uint format);
        public void SetDataFormat(DataFormat format) {
            int result = DE_SetDataFormatEnum(Handle, (uint)format);
            if(result >= 0) {
                Format = format;
            } else {
                throw new Exception("Error code " + ((DirectInputError)result).ToString());
            }
        }
        public DataFormat Format {
            get;
            protected set;
        }

        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Acquire(IntPtr device);
        public void Acquire() {
            int result = DE_Acquire(Handle);
            if (result >= 0) {

            } else {
                throw new Exception("Error code " + result.ToString());
            }
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Unacquire(IntPtr device);
        public void Unacquire() {
            int result = DE_Unacquire(Handle);
            if (result >= 0) {

            } else {
                throw new Exception("Error code " + result.ToString());
            }
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_Release(IntPtr device);
        public void Release() {
            if (!IntPtr.Zero.Equals(Handle)) {
                Unacquire();
                // TODO: DE_Release(Handle);
                Handle = IntPtr.Zero;
            }
        }
        [DllImport(Const.bridgeDLL)]
        protected static extern int DE_GetDeviceState(IntPtr device, int structSize, IntPtr ptr);
        public bool Update() {
            Type type;
            switch (Format) {
            case DataFormat.Joystick:
                    type = typeof(JoyState);
                break;
            case DataFormat.Joystick2:
                    type = typeof(JoyState2);
                break;
            case DataFormat.Keyboard:
                    type = typeof(KeyboardState);
                break;

            case DataFormat.Mouse:
                    type = typeof(MouseState);
                break;
            case DataFormat.Mouse2:
                    type = typeof(MouseState2);
                break;
            default:
                return false;
            }
            object state;
            int result;
            unsafe
            {
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                result = DE_GetDeviceState(Handle, Marshal.SizeOf(type), ptr);
                if(result >= 0) {
                    state = Marshal.PtrToStructure(ptr, type);
                    State = state;
                }
                Marshal.DestroyStructure(ptr, type);
            }            
            if (result < 0) {
                throw new Exception("Error code " + result.ToString());
            }
            return true;
        }


        public void Dispose() {
            Release();
        }
    }
}
