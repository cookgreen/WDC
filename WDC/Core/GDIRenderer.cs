using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wardeclarer.Core
{
    public class GDIRenderer : IRenderer
    {
        private Point resolution;
        private int renderOffset;
        public Point Resoultion { get { return resolution; } }
        public int RenderOffset { get { return renderOffset; } }

        public GDIRenderer()
        {
            
        }

        public void ChangeResolution(Point resolution)
        {
            this.resolution = resolution;
            renderOffset = (Screen.PrimaryScreen.Bounds.Width - resolution.X) / 2;
        }

        public void Render(Graphics g)
        {
        }
    }
}
