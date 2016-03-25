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
        DirectInput8Device current = null;
        DeviceCaps? capabilities = null;
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            di.Setup();
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
            if(current.Update())
                panel1.Invalidate();
            return;
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

        private void performRefresh(object sender, EventArgs e) {
            DeviceInstance[] instances = di.ListDevices();
            DeviceInfo[] values = new DeviceInfo[instances.Length];
            for (int i = 0; i < instances.Length; i++) {
                values[i] = new DeviceInfo(instances[i]);
            }
            listDevices.DataSource = values;
            listDevices.DisplayMember = "Name";
        }
        

        private void displayDevice(object sender, EventArgs e) {
            if (listDevices.SelectedItem == null)
                return;
            DeviceInstance instance = (listDevices.SelectedItem as DeviceInfo).Device;
            DirectInput8Device next = di.CreateDevice(instance.guidInstance);
            StringBuilder sb = new StringBuilder();
            if (next != null) {
                DeviceCaps caps = next.GetCapabilities();
                capabilities = caps;

                foreach (FieldInfo field in caps.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)) {
                    sb.AppendFormat("{0} = {1}\n", field.Name, field.GetValue(caps));
                }
                if (current != null) {
                    current.Dispose();
                }
                current = next;
                if(instance.GetProductName().Contains("XBOX")) {
                    current.SetDataFormat(DataFormat.Joystick2);
                    current.Acquire();
                }
                label1.Text = sb.ToString();
                timer1.Enabled = true;
            }
        }

        private void paintState(object sender, PaintEventArgs e) {
            if (current == null)
                return;
            e.Graphics.Clear(panel1.BackColor);
            object state = current.State;
            if(state is JoyState2) {
                paintJoyState2(e.Graphics, e.ClipRectangle, (JoyState2)state, capabilities.Value);
            }

        }
        private unsafe void paintJoyState2(Graphics g, Rectangle bounds, JoyState2 state, DeviceCaps caps) {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Point cursor = new Point(0, 0);
            Size size = g.MeasureString("000", panel1.Font, bounds.Size).ToSize();
            Rectangle rect;
            for (int i = 0; i < caps.dwButtons; i++) {
                if (cursor.X + size.Width > bounds.Right) {
                    cursor.Y += size.Height;
                    cursor.X = bounds.Left;
                }
                rect = new Rectangle(cursor, size);
                Brush front, back;
                if(state.rgbButtons[i] > 0) {
                    front = Brushes.White;
                    back = Brushes.Black;
                } else {
                    front = Brushes.Black;
                    back = Brushes.White;
                }
                g.FillRectangle(back, rect);
                g.DrawString(i.ToString("00"), panel1.Font, front, rect);
                g.DrawRectangle(Pens.Black, rect);

                // TODO: Add Button Component
                cursor.X += size.Width;
            }
            const int radius = 20;
            size = new Size(radius, radius);
            Tuple<int, int>[] axes = new Tuple<int, int>[caps.dwAxes];
            if(axes.Length >= 0) {
                axes[0] = new Tuple<int, int>(state.lX, state.lY);
                if(axes.Length > 1) {
                    axes[1] = new Tuple<int, int>(state.lRx, state.lRy);
                    if(axes.Length > 2) {
                        axes[2] = new Tuple<int, int>(state.lZ, state.lRz);
                        if(axes.Length > 3) {
                            axes[3] = new Tuple<int, int>(state.lVX, state.lVY);
                            if (axes.Length > 4) {
                                axes[4] = new Tuple<int, int>(0, 0);
                            }
                        }
                    }
                }

            }


            for (int i = 0, j = 0; i < caps.dwAxes; j++ ) {
                if(cursor.X + size.Width > bounds.Right) {
                    cursor.Y += size.Height;
                    cursor.X = bounds.Left;
                }
                rect = new Rectangle(cursor, size);
                g.DrawEllipse(Pens.Black, rect);

                //add pointer(s)
                Tuple<int, int> t = axes[j];
                float pX = ((float)t.Item1 / 65535.0f);
                float pY = ((float)t.Item2 / 65535.0f);
                g.FillRectangle(Brushes.Black, cursor.X + radius * pX, cursor.Y + radius * pY, 2, 2);
                

                //g.DrawString(state.lX.ToString(), panel1.Font, Brushes.Black, cursor);

                cursor.X += size.Width;
                // TODO: Add Axes Component
                if(caps.dwAxes - i > 2) {
                    i += 2;
                }else{
                    i++;
                }
            }
            g.DrawString(state.lX.ToString(), panel1.Font, Brushes.Black, cursor);
            for (int i = 0; i < caps.dwPOVs; i++) {
                // TODO: Add POV Component
            }
        }
    }
}
