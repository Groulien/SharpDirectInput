namespace TestApplication.Visualizers {
    using System;
    using System.Drawing;
    public class AxisPainter : IPainter {
        const int radius = 32;
        Size size = new Size(radius * 2, radius *2);

        public AxisPainter() {
            X = Y = 0;
        }

        public Size Paint(Graphics g, Rectangle bounds, Point location) {
           PointF center = new PointF(location.X + radius, location.Y + radius);  
           PointF target = center;

            target.X += X * (float)radius;
            target.Y -= Y * (float)radius;
            g.DrawLine(Pens.Red, center, target);

            
            Rectangle area = new Rectangle(location, size);
            g.DrawEllipse(Pens.Black, area);

            return size;
        }

        /// <summary>
        /// Position on the axis from -1 to +1.
        /// </summary>
        public float X {
            get;
            set;
        }
        /// <summary>
        /// Position on the axis from -1 to +1.
        /// </summary>
        public float Y {
            get;
            set;
        }
        public Size Size {
            get {
                return size;
            }
        }

        public object Value {
            get {
                return new PointF(X, Y);
            }
            set {
                if (value is Point) {
                    Point p = (Point)value;
                    this.X = p.X / 100.0f;
                    this.Y = p.Y / 100.0f;
                } else if (value is PointF) {
                    PointF p = (PointF) value;
                    this.X = p.X;
                    this.Y = p.Y;
                } else {
                    throw new ArgumentException("value");
                }
            }
        }
    }
}
