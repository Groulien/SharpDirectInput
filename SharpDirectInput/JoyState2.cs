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
        /// Size of the slider field.
        /// </summary>
        public const int SLIDER_LENGTH   = 2;
        /// <summary>
        /// Size of the pov field.
        /// </summary>
        public const int POV_LENGTH    = 4;
        /// <summary>
        /// Size of the buttons field.
        /// </summary>
        public const int BUTTONS_LENGTH    = 128;
        /// <summary>
        /// Size of the velocitySlider field
        /// </summary>
        public const int VELOCITY_LENGTH  = 2;
        /// <summary>
        /// Size of the accelerationSlider field.
        /// </summary>
        public const int ACCELERATION_LENGTH  = 2;
        /// <summary>
        /// Size of the forceSlider field.
        /// </summary>
        public const int FORCE_LENGTH  = 2;
        /// <summary>
        /// X-Axis Position
        /// </summary>
        public LONG x;                         
        /// <summary>
        /// Y-Axis Position
        /// </summary>
        public LONG y;                         
        /// <summary>
        /// Z-Axis Position
        /// </summary>
        public LONG z;                         
        /// <summary>
        /// X-Axis rotation
        /// </summary>
        public LONG rotationX;                        
        /// <summary>
        /// Y-Axis rotation
        /// </summary>
        public LONG rotationY;                        
        /// <summary>
        /// Z-Axis rotation
        /// </summary>
        public LONG rotationZ;                        
        /// <summary>
        /// extra axes positions
        /// </summary>
        public fixed LONG slider[SLIDER_LENGTH];  
        /// <summary>
        /// POV directions
        /// </summary>
        public fixed DWORD pov[POV_LENGTH];    
        /// <summary>
        /// 128 buttons
        /// </summary>
        public fixed BYTE buttons[BUTTONS_LENGTH];  
        /// <summary>
        /// x-axis velocity 
        /// </summary>
        public LONG VelocityX;                        
        /// <summary>
        /// y-axis velocity  
        /// </summary>
        public LONG VelocityY;                        
        /// <summary>
        /// z-axis velocity  
        /// </summary>
        public LONG VelocityZ;                        
        /// <summary>
        /// x-axis angular velocity
        /// </summary>
        public LONG angularVelocityX;                       
        /// <summary>
        /// y-axis angular velocity
        /// </summary>
        public LONG angularVelocityY;                       
        /// <summary>
        /// z-axis angular velocity 
        /// </summary>
        public LONG angularVelocityZ;                       
        /// <summary>
        /// extra axes velocities
        /// </summary>
        public fixed LONG velocitySlider[VELOCITY_LENGTH];
        /// <summary>
        /// x-axis acceleration
        /// </summary>
        public LONG accelerationX;                        
        /// <summary>
        /// y-axis acceleration
        /// </summary>
        public LONG accelerationY;                        
        /// <summary>
        /// z-axis acceleration
        /// </summary>
        public LONG accelerationZ;                        
        /// <summary>
        ///  x-axis angular acceleration
        /// </summary>
        public LONG angularAccelerationX;                       
        /// <summary>
        /// y-axis angular acceleration
        /// </summary>
        public LONG angularAccelerationY;                       
        /// <summary>
        /// z-axis angular acceleration
        /// </summary>
        public LONG angularAccelerationZ;                       
        /// <summary>
        /// extra axes accelerations
        /// </summary>
        public fixed LONG accelerationSlider[ACCELERATION_LENGTH];
        /// <summary>
        ///  x-axis force 
        /// </summary>
        public LONG forceX;                        
        /// <summary>
        /// y-axis force
        /// </summary>
        public LONG forceY;                       
        /// <summary>
        /// z-axis force
        /// </summary>
        public LONG forceZ;                       
        /// <summary>
        /// x-axis torque
        /// </summary>
        public LONG torqueX;                       
        /// <summary>
        /// y-axis torque   
        /// </summary>
        public LONG torqueY;                       
        /// <summary>
        /// z-axis torque  
        /// </summary>
        public LONG torqueZ;                       
        /// <summary>
        /// extra axes forces 
        /// </summary>
        public fixed LONG forceSlider[FORCE_LENGTH];

        /// <summary>
        /// Gets the value of specified axis.
        /// </summary>
        /// <param name="index">Index of the axis.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when an index is negative or too large.</exception>
        /// <returns>Value of the axis.</returns>
        public LONG GetAxis(int index) {
            switch (index) {
            case 0:
                return this.x;
            case 1:
                return this.y;
            case 2:
                return this.z;
            case 3:
                return this.rotationX;
            case 4:
                return this.rotationY;
            case 5:
                return this.rotationZ;
            case 6:
                return this.VelocityX;
            case 7:
                return this.VelocityY;
            case 8:
                return this.VelocityZ;
            default:
                throw new ArgumentOutOfRangeException("index", "State does not support given number of axes");
            }
        }
        /// <summary>
        /// Gets the value of the specified button.
        /// </summary>
        /// <param name="index">Index of the button.</param>
        /// <returns>Value of the button.</returns>
        public unsafe byte GetButton(int index) {
            if (index < 0 || index >= BUTTONS_LENGTH) {
                throw new ArgumentOutOfRangeException("index");
            }
            fixed (byte* ptr = buttons) {
                return ptr[index];
            }
        }
        /// <summary>
        /// Gets the POV value. Values greater than 360,000 tend to mean 'not pressed'.
        /// </summary>
        /// <param name="index">Index of the POV element.</param>
        /// <returns>Value of the POV element.</returns>
        public uint GetPOV(int index) {
            if (index < 0 || index >= POV_LENGTH) {
                throw new ArgumentOutOfRangeException("index");
            }
            fixed (uint* ptr = pov) {
                return ptr[index];
            }
        }
    }
}
