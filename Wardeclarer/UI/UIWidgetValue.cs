using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.UI
{
    public class UIWidgetValue
    {
        private UIMetrics metrics;
        private float value;
        private float actualValue;
        private float referenceValue;
        public float ActualValue
        {
            get
            {
                switch(metrics)
                {
                    case UIMetrics.Absolute:
                        actualValue = value;
                        break;
                    case UIMetrics.Relative:
                        actualValue = referenceValue * value;
                        break;
                    default:
                        actualValue = value;
                        break;
                }
                return actualValue;
            }
        }
        public UIMetrics Metrics
        {
            get { return metrics; }
            set { metrics = value; }
        }

        public UIWidgetValue(UIMetrics metrics, float value, int referenceValue)
        {
            this.metrics = metrics;
            if (metrics == UIMetrics.Relative)
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= 1)
                {
                    value = 1;
                }
            }
            this.value = value;
            this.referenceValue = referenceValue;
        }
    }
}
