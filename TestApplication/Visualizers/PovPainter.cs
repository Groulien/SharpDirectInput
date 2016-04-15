using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication.Visualizers {
    using System.Drawing;
    class PovPainter : IPainter {
        const int radius = 32;
        private Size size = new Size(radius*2, radius*2);
        public Size Size {
            get {
                return size;
            }
        }

        public object Value {
            get;
            set;
        }

        public Size Paint(Graphics g, Rectangle bounds, Point location) {
            uint v = 0;
            if (Value is uint) {
                v = (uint)Value;
            }
            if (v <= 36000) {
                float radians = (float)((v/100.0f) * (Math.PI / 180.0f));
                float x = (float)Math.Sin(radians);
                float y = (float)Math.Cos(radians);
                PointF center = new PointF(location.X + radius, location.Y + radius);
                PointF target = center;
                
                target.X += x * (float)radius;
                target.Y -= y * (float)radius;
                g.DrawLine(Pens.Red, center, target);

            }
            Rectangle area = new Rectangle(location, size);
            g.DrawEllipse(Pens.Black, area);
            
            return size;
        }
    }
}
