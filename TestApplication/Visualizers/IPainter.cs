using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TestApplication.Visualizers {
    public interface IPainter {
        Size Size {
            get;
        }
        object Value {
            get;
            set;
        }
        Size Paint(Graphics g, Rectangle bounds, Point location);
    }
}
