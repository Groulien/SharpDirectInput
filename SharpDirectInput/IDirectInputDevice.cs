namespace SharpDirectInput {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    /// <summary>
    /// 
    /// </summary>
    public interface IDirectInputDevice : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IntPtr Handle {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        void Acquire();
        /// <summary>
        /// 
        /// </summary>
        void Unacquire();
        /// <summary>
        /// 
        /// </summary>
        void Release();
    }
}
