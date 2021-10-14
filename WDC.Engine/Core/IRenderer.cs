using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Core
{
    public interface IRenderer
    {
        Point Resoultion { get; }
        void ChangeResolution(Point resolution);
        int RenderOffset { get; }
        void Render(Graphics g);
    }
}
