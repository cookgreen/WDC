using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Core
{
    public class GDIRenderer : IRenderer
    {
        private Point resolution;
        public Point Resoultion { get { return resolution; } }

        public GDIRenderer(Point resolution)
        {
            this.resolution = resolution;
        }

        public void Render(Graphics g)
        {
        }
    }
}
