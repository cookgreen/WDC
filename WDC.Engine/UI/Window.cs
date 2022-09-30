using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Game;

namespace WDC.UI
{
    public class Window : UIObject
    {
        protected string caption;
        protected Sizer sizer;

        protected int winHeight;
        protected int winWidth;
        protected UIWidgetValue width;
        protected UIWidgetValue height;
        protected UIWidgetValue left;
        protected UIWidgetValue top;
        protected UIMetrics metrics;

        public Window()
        {
        }

        public Window(Sizer sizer, string caption, int height, int width, int left, int top)
        {
            this.sizer = sizer;
            this.caption = caption;
            winHeight = height;
            winWidth = width;
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            base.Render(g, renderer);

            if (sizer != null)
            {
                sizer.Render(g, renderer);
            }
        }
    }
}
