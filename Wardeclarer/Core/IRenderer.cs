using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Core
{
    public interface IRenderer
    {
        Point Resoultion { get; }
        void Render(Graphics g);
    }
}
