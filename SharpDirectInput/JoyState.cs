using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LONG = System.Int32;
using DWORD = System.UInt32;
using BYTE = System.Byte;
namespace SharpDirectInput {
    public unsafe struct JoyState {
        public const int SLIDER_LENGTH = 2;
        public const int POV_LENGTH = 4;
        public const int BUTTONS_LENGTH = 32;

        public LONG    lX;                     /* x-axis position              */
        public LONG    lY;                     /* y-axis position              */
        public LONG    lZ;                     /* z-axis position              */
        public LONG    lRx;                    /* x-axis rotation              */
        public LONG    lRy;                    /* y-axis rotation              */
        public LONG    lRz;                    /* z-axis rotation              */
        public fixed LONG   rglSlider[SLIDER_LENGTH];     /* extra axes positions         */
        public fixed DWORD rgdwPOV[POV_LENGTH];       /* POV directions               */
        public fixed BYTE rgbButtons[BUTTONS_LENGTH];   /* 32 buttons                   */

        public unsafe byte GetButton(int index) {
            if (index < 0 || index >= BUTTONS_LENGTH) {
                throw new ArgumentOutOfRangeException("index");
            }
            fixed (byte* ptr = rgbButtons) {
                return ptr[index];
            }
        }
        public unsafe LONG GetSlider(int index) {
            if (index < 0 || index >= SLIDER_LENGTH) {
                throw new ArgumentOutOfRangeException("index");
            }
            fixed (LONG* ptr = rglSlider) {
                return ptr[index];
            }
        }
        public unsafe DWORD GetPov(int index) {
            if (index < 0 || index >= POV_LENGTH) {
                throw new ArgumentOutOfRangeException("index");
            }
            fixed (DWORD* ptr = rgdwPOV) {
                return ptr[index];
            }
        }
        public unsafe LONG GetAxis(int index) {
            switch (index) {
            case 0:
                return this.lX;
            case 1:
                return this.lY;
            case 2:
                return this.lZ;
            case 3:
                return this.lRx;
            case 4:
                return this.lRy;
            case 5:
                return this.lRz;
            default:
                throw new ArgumentOutOfRangeException("index");
            }
        }
    }
}
