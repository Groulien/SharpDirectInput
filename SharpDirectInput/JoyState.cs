using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LONG = System.Int32;
using DWORD = System.UInt32;
using BYTE = System.Byte;
namespace SharpDirectInput {
    public unsafe struct JoyState {
        public LONG    lX;                     /* x-axis position              */
        public LONG    lY;                     /* y-axis position              */
        public LONG    lZ;                     /* z-axis position              */
        public LONG    lRx;                    /* x-axis rotation              */
        public LONG    lRy;                    /* y-axis rotation              */
        public LONG    lRz;                    /* z-axis rotation              */
        public fixed LONG    rglSlider[2];     /* extra axes positions         */
        public fixed DWORD   rgdwPOV[4];       /* POV directions               */
        public fixed BYTE    rgbButtons[32];   /* 32 buttons                   */
    }
}
