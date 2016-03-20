using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpDirectInput;

namespace UnitTest {
    [TestClass]
    public class UnitTest_DirectInput {
        [TestMethod]
        public void Test_DI_Initialization() {
            DirectInput di = new DirectInput();
            di.Setup();
            Assert.AreNotEqual(IntPtr.Zero, di.Handle);
            Assert.AreEqual(0, di.Release());
            di.Dispose();
            Assert.AreEqual(IntPtr.Zero, di.Handle);
        }
        [TestMethod]
        public void Test_DI_GetDevices() {
            DirectInput di = new DirectInput();
            di.Setup();
            DeviceInstance[] devices = di.ListDevices(DeviceClass.GameController, DeviceFlag.AttachedOnly);
            if (devices.Length > 0) {
                DirectInput8Device device = di.CreateDevice(devices[0].guidInstance);
            }
        }

    }
}
