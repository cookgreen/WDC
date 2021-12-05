using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public enum CurveType
    {
        None,
        Line,
        Pie,
        Bar
    }

    public class CurveAxis
    {
        private string text;

        public CurveAxis(string text)
        {
            this.text = text;
        }
    }

    public class RandomColor
    {
        private Random randomColorR;
        private Random randomColorG;
        private Random randomColorB;

        public RandomColor()
        {
        }

        public Color NextRandomColor
        {
            get
            {
                randomColorR = new Random(Guid.NewGuid().GetHashCode());
                randomColorG = new Random(Guid.NewGuid().GetHashCode());
                randomColorB = new Random(Guid.NewGuid().GetHashCode());

                return Color.FromArgb(
                    randomColorR.Next(0, 255),
                    randomColorG.Next(0, 255),
                    randomColorB.Next(0, 255)
                );
            }
        }
    }

    public class CurveWidget : Widget
    {
        private Color bkColor;
        private CurveType curveType;
        private object data;
        private CurveAxis xAxis;
        private CurveAxis yAxis;
        private string title;
        private RandomColor randColor;

        public CurveWidget(CurveType curveType, object data, CurveAxis xAxis, CurveAxis yAxis, string title)
        {
            bkColor = Color.FromKnownColor(KnownColor.Control);

            randColor = new RandomColor();

            this.curveType = curveType;
            this.data = data;
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.title = title;
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            g.Clear(bkColor);

            switch(curveType)
            {
                case CurveType.Line:
                    DrawLineChart(g);
                    break;
                case CurveType.Bar:
                    DrawBarChart(g);
                    break;
                case CurveType.Pie:
                    DrawPieChart(g);
                    break;
            }

            g.Flush();
        }

        private void DrawLineChart(Graphics g)
        {
            Dictionary<string, Dictionary<string, int>> chartData = data as Dictionary<string, Dictionary<string, int>>;
            if (chartData != null)
            {
                
            }
        }

        private void DrawBarChart(Graphics g)
        {
        }

        private void DrawPieChart(Graphics g)
        {
        }
    }
}
