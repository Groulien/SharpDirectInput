using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpDirectInput;

namespace TestApplication {
    public partial class MainForm : Form {
        List<DirectInput8Device> devices = new List<DirectInput8Device>();
        DirectInput di = new DirectInput();
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            di.Setup();
            foreach (object o in di.ListDevices()) {
                DirectInput8Device device = di.CreateDevice(0 /*o.GUID*/);
                AddDevice(device);
            }
        }
        private void AddDevice(DirectInput8Device device) {
            device.Acquire();
            devices.Add(device);
            // TODO: Add device to layout.
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            while (devices.Count > 0) {
                devices[0].Dispose();
                devices.RemoveAt(0);
            }
        }
    }
}
