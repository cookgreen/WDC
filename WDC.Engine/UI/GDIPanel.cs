using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public class GDIPanel : Widget
    {
        protected int borderSize;
        protected Bitmap image;
        protected List<Widget> widgets;
        public List<Widget> Widgets { get { return widgets; } }

        public GDIPanel(
            Bitmap image,
            PointF position,
            Size size,
            int borderSize)
        {
            this.image = image;
            this.position = position;
            this.size = size;
            this.borderSize = borderSize;
            widgets = new List<Widget>();
        }

        public void AddWidget(Widget widget)
        {
            widget.Position = new PointF(
                position.X + widget.Position.X, 
                position.Y + widget.Position.Y);
            widgets.Add(widget);
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            g.DrawImage(image, position.X, position.Y, size.Width, size.Height);
            foreach(var widget in widgets)
            {
                widget.Render(g, renderer);
            }
        }
    }
}
