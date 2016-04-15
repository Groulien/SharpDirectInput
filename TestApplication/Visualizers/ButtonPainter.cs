using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication.Visualizers {
    using System.Drawing;
    using System.Windows.Forms;
    class ButtonPainter : IPainter {
        Font font;
        StringFormat sf = new StringFormat()
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };
        Size size;
        public ButtonPainter()
            : this(new Font(FontFamily.GenericSerif, 12)){
           
        }
        public ButtonPainter(Font font) {
            this.font = font;
            size = TextRenderer.MeasureText("000", font);
        }
        public Size Size {
            get {
                return size;
            }
        }

        public object Value {
            get;
            set;
        }
        public int Index {
            get;
            set;
        }

        public Size Paint(Graphics g, Rectangle bounds, Point location) {
            bool pressed = false;
            if(Value is bool) {
                pressed = (bool) Value;
            }else if(Value is byte) {
                pressed = (byte) Value > 0;
            }else if (Value is int) {
                pressed = (int) Value > 0;
            }
            Brush foreGround = (pressed ? Brushes.White : Brushes.Black);
            Brush backGround = (pressed ? Brushes.Black : Brushes.White);
            Pen border = Pens.Black;
            
            Rectangle area = new Rectangle(location, size);

            g.FillRectangle(backGround, area);
            g.DrawString(Index.ToString("000"), font, foreGround, area, sf);
            g.DrawRectangle(border, area);


            return size;
        }
    }
}
