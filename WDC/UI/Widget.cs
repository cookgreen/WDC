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
	public class Widget : GameObject
	{
        protected int winHeight;
        protected int winWidth;
        protected UIWidgetValue width;
        protected UIWidgetValue height;
        protected UIWidgetValue left;
        protected UIWidgetValue top;
        protected UIMetrics metrics;

        public float Left
        {
            get { return left.ActualValue; }
        }
        public float Top
        {
            get { return top.ActualValue; }
        }
        public UIMetrics Metrics
        {
            get
            {
                return metrics;
            }
            set
            {
                metrics = value;
                left.Metrics = value;
                top.Metrics = value;
            }
        }

        public Widget()
        {
            metrics = UIMetrics.Absolute;
        }
    }
}
