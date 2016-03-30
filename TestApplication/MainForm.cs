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
            DeviceInfo info = (listDevices.SelectedItem as DeviceInfo);
            DeviceInstance instance = info.Device;
            DirectInput8Device next = di.CreateDevice(instance.guidInstance);
            StringBuilder sb = new StringBuilder();
            if (next != null) {
                DeviceCaps caps = next.GetCapabilities();
                capabilities = caps;

                foreach (FieldInfo field in caps.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)) {
                    if (field.Name == "dwDevType") {
                        DeviceType raw = (DeviceType)caps.dwDevType;
                        string desc = null;
                        if (raw.HasFlag(DeviceType.Gamepad)) {
                            desc = "Gamepad";
                            next.SetDataFormat(DataFormat.Joystick2);
                            next.Acquire();
                        } else if (raw.HasFlag(DeviceType.Joystick)) {
                            desc = "Joystick";
                        } else if (raw.HasFlag(DeviceType.Keyboard)) {
                            next.SetDataFormat(DataFormat.Keyboard);
                            next.Acquire();
                            desc = "Keyboard";
                        } else if (raw.HasFlag(DeviceType.Mouse)) {
                            desc = "Mouse";
                        } else if (raw.HasFlag(DeviceType.Remote)) {
                            desc = "Remote";
                        } else if (raw.HasFlag(DeviceType.Supplemental)) {
                            desc = "Supplemental";
                        } else if (raw.HasFlag(DeviceType.Device)) {
                            desc = "Miscellaneous";

                            if (caps.dwButtons > 4 && info.Name.Contains("Logitech")) {
                                next.SetCooperationLevel(this.Handle, 0 /*TODO: DISCL_BACKGROUND | DISCL_NONEXCLUSIVE*/);
                                next.SetDataFormat(DataFormat.Keyboard);
                                next.Acquire();
                            }



                        } else {
                            desc = "Unspecified";
                        }
                        sb.AppendFormat("{0} = {1} ({2})\n", field.Name, field.GetValue(caps), desc);
                    } else {
                        sb.AppendFormat("{0} = {1}\n", field.Name, field.GetValue(caps));
                    }
                }
                if (current != null) {
                    current.Dispose();
                }
                current = next;
                label1.Text = sb.ToString();
                timer1.Enabled = true;
            }
        }

        private void paintState(object sender, PaintEventArgs e) {
            if (current == null)
                return;
            e.Graphics.Clear(panel1.BackColor);

            Point cursor = new Point(0,0);
            if (current.Format == DataFormat.Joystick2) {
                paintJoyState2(e.Graphics, e.ClipRectangle, (JoyState2)current.State, capabilities.Value);
            } else if (current.Format == DataFormat.Keyboard) {
                byte[] data = (byte[])current.State;
                unsafe {
                    fixed (byte* ptr = data) {
                        paintKeys(e.Graphics, e.ClipRectangle, ref cursor, ptr, (int)capabilities.Value.dwButtons);
                    }
                }
                
                
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
        private unsafe void paintKeys(Graphics g, Rectangle bounds, ref Point cursor, byte* keys, int length) {
            Size size = g.MeasureString("000", panel1.Font, bounds.Size).ToSize();
            Rectangle rect;
            for (int i = 0; i < length; i++) {
                if (cursor.X + size.Width > bounds.Right) {
                    cursor.Y += size.Height;
                    cursor.X = bounds.Left;
                }
                rect = new Rectangle(cursor, size);
                Brush front, back;
                if (keys[i] > 0) {
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
        }
    }
}
