using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpDirectInput;

namespace UnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            DirectInput di = new DirectInput();
            di.Setup();
        }
    }
}
