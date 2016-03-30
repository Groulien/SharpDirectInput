using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LONG = System.Int32;
using DWORD = System.UInt32;
using BYTE = System.Byte;
namespace SharpDirectInput {
    public unsafe struct MouseState2 {
        public LONG    lX;
        public LONG    lY;
        public LONG    lZ;
        public fixed BYTE rgbButtons[8];
    }
}
