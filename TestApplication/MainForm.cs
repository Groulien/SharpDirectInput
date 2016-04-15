using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.Runtime.InteropServices;
using SharpDirectInput;

namespace TestApplication {
    public partial class MainForm : Form {
        private DirectInput directInput = new DirectInput();
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            directInput.Setup();
            this.Disposed += MainForm_Disposed;
        }

        void MainForm_Disposed(object sender, EventArgs e) {
            if (directInput != null) {
                directInput.Dispose();
                directInput = null;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            updateTimer.Enabled = false;
            if (directInput != null) {
                directInput.Dispose();
                directInput = null;
            }
            
        }
        private void timer_tick(object sender, EventArgs e) {
            inputRenderer.UpdateState();
        }

        private void refreshList(object sender, EventArgs e) {
            DeviceInstance[] instances = directInput.ListDevices();
            DeviceInfo[] values = new DeviceInfo[instances.Length];
            for (int i = 0; i < instances.Length; i++) {
                values[i] = new DeviceInfo(instances[i]);
            }
            listDevices.DataSource = values;
            listDevices.DisplayMember = "Name";
        }
        

        private void displayListItem(object sender, EventArgs e) {
            if (listDevices.SelectedItem == null)
                return;
            DeviceInfo info = (listDevices.SelectedItem as DeviceInfo);
            DeviceInstance instance = info.Device;
            DirectInput8Device next = directInput.CreateDevice(instance.guidInstance);
            if (next != null) {
                DeviceCaps caps = next.GetCapabilities();
                DataFormat format = caps.GetDataFormat();
                if (format != DataFormat.Invalid) {
                    next.SetDataFormat(format);
                    next.Acquire();
                }
                displayDevice(next, caps);
                updateTimer.Enabled = true;
            }
        }
        private void displayDevice(DirectInput8Device device, DeviceCaps caps) {
            DirectInput8Device current = inputRenderer.Device;
            if (current is IDisposable) {
                (current as IDisposable).Dispose();
            }

            inputRenderer.Device = device;
            inputRenderer.Capabilities = caps;

            txtDeviceType.Text = caps.GetBaseDeviceType().ToString();
            txtSize.Text = caps.dwSize.ToString();
            txtFlags.Text = caps.dwFlags.ToString();
            txtAxes.Text = caps.dwAxes.ToString();
            txtButtons.Text = caps.dwButtons.ToString();
            txtPOVs.Text = caps.dwPOVs.ToString();
            txtSamplePeriod.Text = caps.dwFFSamplePeriod.ToString();
            txtResolution.Text = caps.dwFFMinTimeResolution.ToString();
            txtFirmware.Text = caps.dwFirmwareRevision.ToString();
            txtHardware.Text = caps.dwHardwareRevision.ToString();
            txtDriver.Text = caps.dwFFDriverVersion.ToString();
        }
    }
}
