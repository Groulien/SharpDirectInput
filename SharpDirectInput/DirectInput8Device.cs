using System;
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

        [DllImport(Win32.Bridge)]
        protected static extern int DE_SetDataFormat(IntPtr device);

        [DllImport(Win32.Bridge)]
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

        [DllImport(Win32.Bridge)]
        protected static extern int DE_Acquire(IntPtr device);
        public void Acquire() {
            int result = DE_Acquire(Handle);
            if (result >= 0) {

            } else {
                throw new Exception("Error code " + result.ToString());
            }
        }
        [DllImport(Win32.Bridge)]
        protected static extern int DE_Unacquire(IntPtr device);
        public void Unacquire() {
            int result = DE_Unacquire(Handle);
            if (result >= 0) {

            } else {
                throw new Exception("Error code " + result.ToString());
            }
        }
        public void Release() {
            if (!IntPtr.Zero.Equals(Handle)) {
                Unacquire();
                Win32.Release(Handle);
                Handle = IntPtr.Zero;
            }
        }
        [DllImport(Win32.Bridge, CallingConvention=CallingConvention.StdCall)]
        protected static extern int DE_GetCapabilities(IntPtr device, ref DeviceCaps DiDevCaps);
        public DeviceCaps GetCapabilities() {
            DeviceCaps DiDevCaps = new DeviceCaps();
            DiDevCaps.dwSize = (uint)Marshal.SizeOf(typeof(DeviceCaps));
            int result = DE_GetCapabilities(Handle, ref DiDevCaps);
            if(result >= 0)
                return DiDevCaps;
            throw new Exception("Error code " + result.ToString());
        }
        [DllImport(Win32.Bridge, CallingConvention=CallingConvention.StdCall)]
        protected static extern int DE_Poll(IntPtr device);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Poll() {
            return DE_Poll(Handle) >= 0;
        }

        [DllImport(Win32.Bridge)]
        protected static extern int DE_GetDeviceState(IntPtr device, int structSize, IntPtr ptr);
        [DllImport(Win32.Bridge)]
        protected unsafe static extern int DE_GetDeviceState(IntPtr device, int structSize, byte* ptr);


        public bool Update() {
            Type type;
            object state;
            int result;
            switch (Format) {
            case DataFormat.Joystick:
                    type = typeof(JoyState);
                break;
            case DataFormat.Joystick2:
                    type = typeof(JoyState2);
                break;
            case DataFormat.Keyboard:
                    //type = typeof(KeyboardState);
                byte[] keys = new byte[256];
                unsafe {
                    fixed (byte* ptr = keys) {
                        
                        result = DE_GetDeviceState(Handle, keys.Length, ptr);
                    }
                }
                
                if(result >= 0)
                    State = keys;
                return result >= 0;

            case DataFormat.Mouse:
                    type = typeof(MouseState);
                break;
            case DataFormat.Mouse2:
                    type = typeof(MouseState2);
                break;
            default:
                return false;
            }
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
        [DllImport(Win32.Bridge)]
        protected unsafe static extern int DE_SetCooperationLevel(IntPtr device, uint flags);
        public void SetCooperationLevel(IntPtr Window, uint flags) {

        }


        public void Dispose() {
            Release();
        }
    }
}
