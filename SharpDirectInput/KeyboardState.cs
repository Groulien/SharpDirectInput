using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpDirectInput {
    struct KeyboardState {
        public const int Length = 255;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public bool IsDown(int keycode) {
           // if(keycode > 0 && keycode < Length)
                //return keys[keycode] > 0;
            throw new InvalidOperationException();
        }
    }
}
