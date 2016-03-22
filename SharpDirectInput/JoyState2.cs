using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LONG = System.Int32;
using DWORD = System.UInt32;
using BYTE = System.Byte;
using System.Runtime.InteropServices;
namespace SharpDirectInput {
    /// <summary>
    /// Data structure for the Joystick2 Data Format.
    /// </summary>
    /// <seealso cref="SharpDirectInput.DataFormat.Joystick2"/>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct JoyState2 {
        /// <summary>
        /// Size of the rglSlider field.
        /// </summary>
        public const int rglS_Len   = 2;
        /// <summary>
        /// Size of the rgdwPOV field.
        /// </summary>
        public const int rgd_Len    = 4;
        /// <summary>
        /// Size of the rgbButtons field.
        /// </summary>
        public const int rgb_Len    = 128;
        /// <summary>
        /// Size of the rglVSlider field
        /// </summary>
        public const int rglVS_len  = 2;
        /// <summary>
        /// Size of the rglASlider field.
        /// </summary>
        public const int rglAS_len  = 2;
        /// <summary>
        /// Size of the rglsFSlider field.
        /// </summary>
        public const int rglFS_Len  = 2;
        /// <summary>
        /// X-Axis Position
        /// </summary>
        public LONG lX;                         
        /// <summary>
        /// Y-Axis Position
        /// </summary>
        public LONG lY;                         
        /// <summary>
        /// Z-Axis Position
        /// </summary>
        public LONG lZ;                         
        /// <summary>
        /// X-Axis rotation
        /// </summary>
        public LONG lRx;                        
        /// <summary>
        /// Y-Axis rotation
        /// </summary>
        public LONG lRy;                        
        /// <summary>
        /// Z-Axis rotation
        /// </summary>
        public LONG lRz;                        
        /// <summary>
        /// extra axes positions
        /// </summary>
        public fixed LONG rglSlider[rglS_Len];  
        /// <summary>
        /// POV directions
        /// </summary>
        public fixed DWORD rgdwPOV[rgd_Len];    
        /// <summary>
        /// 128 buttons
        /// </summary>
        public fixed BYTE rgbButtons[rgb_Len];  
        /// <summary>
        /// x-axis velocity 
        /// </summary>
        public LONG lVX;                        
        /// <summary>
        /// y-axis velocity  
        /// </summary>
        public LONG lVY;                        
        /// <summary>
        /// z-axis velocity  
        /// </summary>
        public LONG lVZ;                        
        /// <summary>
        /// x-axis angular velocity
        /// </summary>
        public LONG lVRx;                       
        /// <summary>
        /// y-axis angular velocity
        /// </summary>
        public LONG lVRy;                       
        /// <summary>
        /// z-axis angular velocity 
        /// </summary>
        public LONG lVRz;                       
        /// <summary>
        /// extra axes velocities
        /// </summary>
        public fixed LONG rglVSlider[rglVS_len];
        /// <summary>
        /// x-axis acceleration
        /// </summary>
        public LONG lAX;                        
        /// <summary>
        /// y-axis acceleration
        /// </summary>
        public LONG lAY;                        
        /// <summary>
        /// z-axis acceleration
        /// </summary>
        public LONG lAZ;                        
        /// <summary>
        ///  x-axis angular acceleration
        /// </summary>
        public LONG lARx;                       
        /// <summary>
        /// y-axis angular acceleration
        /// </summary>
        public LONG lARy;                       
        /// <summary>
        /// z-axis angular acceleration
        /// </summary>
        public LONG lARz;                       
        /// <summary>
        /// extra axes accelerations
        /// </summary>
        public fixed LONG rglASlider[rglAS_len];
        /// <summary>
        ///  x-axis force 
        /// </summary>
        public LONG lFX;                        
        /// <summary>
        /// y-axis force
        /// </summary>
        public LONG lFY;                       
        /// <summary>
        /// z-axis force
        /// </summary>
        public LONG lFZ;                       
        /// <summary>
        /// x-axis torque
        /// </summary>
        public LONG lFRx;                       
        /// <summary>
        /// y-axis torque   
        /// </summary>
        public LONG lFRy;                       
        /// <summary>
        /// z-axis torque  
        /// </summary>
        public LONG lFRz;                       
        /// <summary>
        /// extra axes forces 
        /// </summary>
        public fixed LONG rglFSlider[rglFS_Len];
    }
}
