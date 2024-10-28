using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public class GDIImagePanel : GDIPanel
    {
        private Bitmap bkImage;
        public GDIImagePanel(Bitmap image, Bitmap bkImage, PointF position, Size size, int borderSize) 
            : base(image, position, size, borderSize)
        {
            this.bkImage = bkImage;
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            g.DrawImage(image, position.X, position.Y, size.Width, size.Height);
            g.DrawImage(bkImage, position.X + borderSize, position.Y + borderSize, size.Width - borderSize * 2, size.Height - borderSize * 2);
        }
    }
}
