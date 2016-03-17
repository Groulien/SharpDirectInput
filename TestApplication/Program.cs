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
            new DirectInput().Setup();
            Application.Run(new MainForm());
        }
    }
}
