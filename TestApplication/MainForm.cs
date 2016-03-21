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
        List<DirectInput8Device> devices = new List<DirectInput8Device>();
        DirectInput di = new DirectInput();
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            di.Setup();
            foreach (DeviceInstance instance in di.ListDevices(DeviceClass.GameController, DeviceFlag.AttachedOnly)) {
                DirectInput8Device device = di.CreateDevice(instance.guidInstance);
                device.SetDataFormat(DataFormat.Joystick2);
                AddDevice(device);
            }
            timer1.Enabled = true;
        }
        private void AddDevice(DirectInput8Device device) {
            device.Acquire();
            devices.Add(device);
            // TODO: Add device to layout.
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            timer1.Enabled = false;
            while (devices.Count > 0) {
                devices[0].Dispose();
                devices.RemoveAt(0);
            }
            
        }
        protected unsafe byte[] Unfix(byte* data, int count) {
            byte[] arr = new byte[count];
            for(int i = 0; i < count; i++) {
                arr[i] = *data;
                data++;
            }
            return arr;
        }
        protected unsafe uint[] Unfix(uint* data, int count) {
            uint[] arr = new uint[count];
            for (int i = 0; i < count; i++) {
                arr[i] = *data;
                data++;
            }
            return arr;
        }
        protected unsafe int[] Unfix(int* data, int count) {
            int[] arr = new int[count];
            for (int i = 0; i < count; i++) {
                arr[i] = *data;
                data++;
            }
            return arr;
        }
        protected List<int> IndexOf<T>(IEnumerable<T> ienumerable, Predicate<T> predicate) {
            List<int> indices = new List<int>();
            int i = 0;
            foreach(T value in ienumerable) {
                if(predicate(value)) {
                    indices.Add(i);
                }
                i++;
            }
            return indices;
        }
        private void timer1_Tick(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();
            foreach (DirectInput8Device device in devices) {
                if(device.Update()) {
                    sb.Clear();
                    object state = device.State;
                    if(!(state is JoyState2)) {
                        JoyState2 joy = (JoyState2)state;
                        byte[] rgb;
                        uint[] pov;
                        int[] rgl;
                        int[] rglV;
                        int[] rglA;
                        int[] rglS;
                        unsafe
                        {
                            rgl = Unfix(joy.rglSlider, JoyState2.rglS_Len);
                            rgb = Unfix(joy.rgbButtons, JoyState2.rgb_Len);
                            pov = Unfix(joy.rgdwPOV, JoyState2.rgd_Len);
                            rglV = Unfix(joy.rglVSlider, JoyState2.rglVS_len);
                            rglA = Unfix(joy.rglASlider, JoyState2.rglAS_len);
                            rglS = Unfix(joy.rglFSlider, JoyState2.rglFS_Len);

                        }
                        sb.AppendFormat("rgl = {0}\n", String.Join("," , rgl));
                        sb.AppendFormat("rgb = {0}\n", String.Join(",", rgb));
                        sb.AppendFormat("pov = {0}\n", String.Join(",", pov));
                        sb.AppendFormat("rglV = {0}\n", String.Join(",", rglV));
                        sb.AppendFormat("rglA = {0}\n", String.Join(",", rglA));
                        sb.AppendFormat("rglS = {0}\n", String.Join(",", rglS));

                    } else {
                        FieldInfo[] fields = state.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                        foreach (FieldInfo fi in fields) {
                            object value = fi.GetValue(state);
                            if(value.ToString().EndsWith("FixedBuffer")) {
                                Type t = value.GetType();
                                System.Diagnostics.Debugger.Break();
                            } else {
                                sb.AppendFormat("{0} = {1}\n", fi.Name, value);
                            }
                        }
                    }
                    
                    label1.Text = sb.ToString();
                }
            }
        }
    }
}
