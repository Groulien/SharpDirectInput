using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApplication {
    using TestApplication.Visualizers;
    using SharpDirectInput;
    public partial class InputRenderControl : UserControl {
        TriggerPainter pTrigger = new TriggerPainter();
        AxisPainter pAxis = new AxisPainter();
        PovPainter pPov = new PovPainter();
        ButtonPainter pBtn = new ButtonPainter();
        public InputRenderControl() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }
        public DirectInput8Device Device{
            get;
            set;
        }
        public DeviceCaps Capabilities {
            get;
            set;
        }
        public void UpdateState() {
            if (Device != null && Device.Update()) {
                state = Device.State;
            }
            this.Invalidate();
        }
        protected object state;
        protected override void OnPaint(PaintEventArgs e) {
            const int margin = 5;
            base.OnPaint(e);
            if (Device  == null || state == null || Device.Format == DataFormat.Invalid) {
                return;
            }
            
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Point p = e.ClipRectangle.Location;
            if (state is JoyState) {
                JoyState joy = (JoyState)state;
                for (int i = 0; i < Capabilities.dwButtons; i++) {
                    pBtn.Index = i;
                    pBtn.Value = joy.GetButton(i);
                    p.X += pBtn.Paint(e.Graphics, e.ClipRectangle, p).Width;
                    if (i == Capabilities.dwButtons - 1) {
                        p.Y += pBtn.Size.Height;
                        p.X = e.ClipRectangle.Left;
                        break;
                    }
                    if (p.X + pBtn.Size.Width > e.ClipRectangle.Right) {
                        p.Y += pBtn.Size.Height;
                        p.X = e.ClipRectangle.Left;
                    }
                }
                return;
            }
            if (state is JoyState2) {
                JoyState2 joy = (JoyState2)state;
                for (int i = 0; i < Capabilities.dwButtons; i++) {
                    pBtn.Index = i;
                    pBtn.Value = joy.GetButton(i);
                    PaintAndWrap(pBtn, e.Graphics, e.ClipRectangle, ref p, (i == Capabilities.dwButtons - 1));
                }
                p.Y += margin;
                for (int i = 0; i < Capabilities.dwAxes; i++) {
                    pTrigger.Value = joy.GetAxis(i);
                    p.Y += pTrigger.Paint(e.Graphics, e.ClipRectangle, p).Height;
                }
                p.Y += margin;
                for (int i = 0; i < Capabilities.dwPOVs; i++) {
                    pPov.Value = joy.GetPOV(i);
                    p.Y += pPov.Paint(e.Graphics, e.ClipRectangle, p).Height;
                }
                return;
            }
            if (state is MouseState) {
                MouseState mouse = (MouseState)state;
                //x, y, z
                // 4 buttons
                return;
            }
            if (state is MouseState2) {
                MouseState2 mouse = (MouseState2)state;
                string output = string.Format("X: {0}\nY: {1}\nZ: {2}", mouse.lX, mouse.lY, mouse.lZ);
                e.Graphics.DrawString(output, Font, Brushes.Black, p);
                p.Y += (int)e.Graphics.MeasureString(output, Font).Height;

                for (int i = 0; i < Capabilities.dwButtons; i++) {
                    pBtn.Value = mouse.GetButton(i);
                    pBtn.Index = i;
                    PaintAndWrap(pBtn, e.Graphics, e.ClipRectangle, ref p, (i == Capabilities.dwButtons - 1));
                }
                return;
            }
            if (state is byte[]) {
                byte[] keys = (state as byte[]);
                for (int i = 0; i < Capabilities.dwButtons; i++) {
                    pBtn.Index = i;
                    pBtn.Value = keys[i];
                    PaintAndWrap(pBtn, e.Graphics, e.ClipRectangle, ref p, (i == Capabilities.dwButtons - 1));
                }
            }
        }
        protected void PaintAndWrap(IPainter painter, Graphics g, Rectangle bounds, ref Point p, bool end) {
            if (p.X + painter.Size.Width > bounds.Right) {
                p.Y += painter.Size.Height;
                p.X = bounds.Left;
            }
            if (end) {
                p.Y += painter.Paint(g, bounds, p).Height;
                p.X = bounds.Left;
            } else {
                p.X += painter.Paint(g, bounds, p).Width;
            }
        }
    }
}
