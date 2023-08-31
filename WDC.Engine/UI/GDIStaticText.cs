using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public class GDIStaticText : Widget
    {
        private string text;
        private Font font;
        private Brush brush;
        private AlignMethod alignment;
        private bool inited;
        private bool neededAdjustWithFont;

        public string Text
		{
			get { return text; }
			set { text = value; }
		}

        public GDIStaticText(string text, string fontName, int fontSize, Brush brush, PointF position, bool neededAdjustWithFont, AlignMethod alignment = AlignMethod.CENTER)
        {
            winHeight = Engine.Instance.WinHeight;
            winWidth = Engine.Instance.WinWidth;
            font = new Font(fontName, fontSize);
            this.text = text;
            this.brush = brush;
            this.position = position;
            this.alignment = alignment;
            this.neededAdjustWithFont = neededAdjustWithFont;

            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);
        }

        public void Draw(Graphics g)
        {
            if(!inited)
            {
                SizeF fontSize = g.MeasureString(text, font);
                switch (alignment)
                {
                    case AlignMethod.CENTER:
                        position = new PointF(winWidth / 2 - fontSize.Width / 2, position.Y);
                        break;
                    case AlignMethod.LEFT:
                        position = new PointF(0, position.Y);
                        break;
                    case AlignMethod.RIGHT:
                        position = new PointF(winWidth - fontSize.Width, position.Y);
                        break;
                    case AlignMethod.PERCENT:
                        position = new PointF(left.ActualValue, top.ActualValue);
                        break;
                    case AlignMethod.MANUAL:
                        break;
                }
                if(neededAdjustWithFont)
                {
                    position.Y -= fontSize.Height;
                }
                inited = true;
            }
            g.DrawString(text, font, brush, position);
        }

		public override void Render(Graphics g, IRenderer renderer)
		{
            Draw(g);
		}
	}
}
