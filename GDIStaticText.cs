using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer
{
    class GDIStaticText
    {
        private string text;
        private Font font;
        private Brush brush;
        private PointF position;
        private AlignMethod alignment;
        private bool inited;
        private bool neededAdjustWithFont;
        private int winWidth;
        private int winHeight;

        public GDIStaticText(string text, string fontName, int fontSize, Brush brush, PointF position, int winWidth, int winHeight, bool neededAdjustWithFont, AlignMethod alignment = AlignMethod.CENTER)
        {
            this.winHeight = winHeight;
            this.winWidth = winWidth;
            font = new Font(fontName, fontSize);
            this.text = text;
            this.brush = brush;
            this.position = position;
            this.alignment = alignment;
            this.neededAdjustWithFont = neededAdjustWithFont;
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
                }
                if(neededAdjustWithFont)
                {
                    position.Y -= fontSize.Height;
                }
                inited = true;
            }
            g.DrawString(text, font, brush, position);
        }
    }
}
