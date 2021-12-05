using CurveScript.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using WDC.Core;
using WDC.Script;
using WDC.UI;

namespace CurveScript
{
    public class CurveScript : WDCScript
    {
        private int winHeight;
        private int winWidth;
        private GDISelectableOption option1;
        private GDISelectableOption option2;
        private GDISelectableOption option3;
        private List<GDISelectableOption> options;
        private CurveWidget curveWidget;
        private Engine engine;

        public void BeforeRunScript()
        {
        }

        public void Init(Engine engine)
        {
            this.engine = engine;
            engine.ChangeBackground(Resources.worldmap);

            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth; 
            
            options = new List<GDISelectableOption>();
            option1 = new GDISelectableOption("1) Line Chart", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            option2 = new GDISelectableOption("2) Pie Chart", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            option3 = new GDISelectableOption("3) Bar Chart", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            
            options.Add(option1);
            options.Add(option2);
            options.Add(option3);

            for (int i = 0; i < options.Count; i++)
            {
                options[i].Position = new PointF(0, winHeight - ((options.Count - i) * options[i].Height));
            }

            option1.MouseClicked += Option1_MouseClicked;
            option2.MouseClicked += Option2_MouseClicked;
            option3.MouseClicked += Option3_MouseClicked;
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            engine.AddIfNotExisted(curveWidget);

            engine.AddIfNotExisted(option1);
            engine.AddIfNotExisted(option2);
            engine.AddIfNotExisted(option3);
        }

        /// <summary>
        /// Line Chart
        /// </summary>
        private void Option1_MouseClicked()
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();
            data.Add("玉米", new Dictionary<string, int>() {
                { "2001年", 100 },
                { "2002年", 120},
                { "2003年", 80},
                { "2004年", 75},
                { "2005年", 90}
            });
            data.Add("大豆", new Dictionary<string, int>() {
                { "2001年", 30 },
                { "2002年", 50},
                { "2003年", 40},
                { "2004年", 100},
                { "2005年", 60}
            });
            data.Add("大麦", new Dictionary<string, int>() {
                { "2001年", 120 },
                { "2002年", 130},
                { "2003年", 150},
                { "2004年", 100},
                { "2005年", 160}
            });
            data.Add("水稻", new Dictionary<string, int>() {
                { "2001年", 90 },
                { "2002年", 100},
                { "2003年", 120},
                { "2004年", 150},
                { "2005年", 180}
            });
            data.Add("马铃薯", new Dictionary<string, int>() {
                { "2001年", 75 },
                { "2002年", 60},
                { "2003年", 90},
                { "2004年", 20},
                { "2005年", 40}
            });

            curveWidget = new CurveWidget(
                CurveType.Line, 
                data, 
                new CurveAxis("年"), 
                new CurveAxis("数量: 百万吨"),
                "2001-2005年物品数量变化统计表"
            );
        }

        /// <summary>
        /// Pie Chart
        /// </summary>
        private void Option2_MouseClicked()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("玉米", 130);
            data.Add("大豆", 80);
            data.Add("大麦", 240);
            data.Add("水稻", 120);
            data.Add("马铃薯", 320);

            curveWidget = new CurveWidget(
                CurveType.Pie, 
                data, 
                new CurveAxis("物品类型"), 
                new CurveAxis("数量: 百万吨"),
                "某年度物品占比统计表"
            );
        }

        /// <summary>
        /// Bar Chart
        /// </summary>
        private void Option3_MouseClicked()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("玉米", 130);
            data.Add("大豆", 80);
            data.Add("大麦", 240);
            data.Add("水稻", 120);
            data.Add("马铃薯", 320);

            curveWidget = new CurveWidget(
                CurveType.Bar, 
                data, 
                new CurveAxis("物品类型"), 
                new CurveAxis("数量: 百万吨"),
                "某年度物品数量统计表"
            );
        }
    }
}
