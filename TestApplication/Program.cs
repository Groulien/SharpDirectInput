using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SharpDirectInput;

namespace TestApplication {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DirectInput di = new DirectInput();
            di.Setup();
            DeviceInstance[] connected = di.ListDevices(DeviceClass.GameController, DeviceFlag.AttachedOnly);
            if (connected.Length > 0) {
                if (connected.Length > 0) {
                    DirectInput8Device device = di.CreateDevice(connected[0].guidInstance);
                }
            }
            Application.Run(new MainForm());
        }
    }
}
