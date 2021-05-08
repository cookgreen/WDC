using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Core
{
    public interface IRenderable
    {
        void Render(Graphics g, IRenderer renderer);
    }
}
