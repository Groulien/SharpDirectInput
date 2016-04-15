using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TestApplication.Visualizers {
    using System.Drawing;
    class TriggerPainter: IPainter {
        private Size size = new Size(200, 12);
        public Size Size {
            get {
                return size;
            }
        }

        public Size Paint(Graphics g, Rectangle bounds, Point location) {
            int width = size.Width;
            if (width > bounds.Width)
                width = bounds.Width;

            float percentage = 0.5f;
            if(Value != null) {
                if (Value is float) {
                    percentage = (float)Value / 65535.0f;
                } else if (Value is int) {
                    percentage = (float)(int)Value / 65535.0f;
                }
               
            }
            Rectangle area = new Rectangle(location, new Size((int)(width * percentage), size.Height));

            g.FillRectangle(Brushes.RoyalBlue, area);
            area.Width = width;
            g.DrawRectangle(Pens.Black, area);
            
            return size;
        }


        public object Value {
            get;
            set;
        }
    }
}
