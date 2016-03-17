using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpDirectInput {
    public class DirectInput8Device : IDirectInput8Device {
        public void SetDataFormat() {
        
        }
        public void Acquire() {
        
        }
        public void Release() {
        
        }
        public bool Update() {
            return false;
        }
        public object State {
            get;
            set;
        }
    }
}
