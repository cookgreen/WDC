using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.UI
{
    public class GDIStaticTextPanel : Widget
    {
        private Image image;
        private AlignMethod textAlign;
        private string text;
        private Font font;
        private Brush brush;
        private AlignMethod controlAlignHorizontal;
        private AlignMethod controlAlignVertical;
        private bool autoSizeByText;
        private PointF actualPosition;
        private PointF textOffset;

        public string Text
		{
			get { return text; }
			set { text = value; }
		}

        public override PointF Position 
        {
            get { return actualPosition; }
            set { actualPosition = value; } 
        }

        public GDIStaticTextPanel(
            GDITextOption textOption, 
            Image image, 
            PointF position, 
            Size size,
            PointF textOffset,
            AlignMethod textAlign,
            bool autoSizeByText,
            AlignMethod controlAlignHorizontal = AlignMethod.MANUAL,
            AlignMethod controlAlignVertical = AlignMethod.MANUAL)
        { 
            winHeight = Engine.Instance.WinHeight;
            winWidth = Engine.Instance.WinWidth;
            font = new Font(textOption.FontFamily, textOption.FontSize);

            this.image = image;
            this.position = position;
            this.size = size;

            this.textOffset = textOffset;
            this.textAlign = textAlign;

            this.autoSizeByText = autoSizeByText;
            this.controlAlignHorizontal = controlAlignHorizontal;
            this.controlAlignVertical = controlAlignVertical;

            text = textOption.Text;
            brush = new SolidBrush(textOption.TextColor);
            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);
        }

        public void Draw(Graphics g)
        {
            SizeF fontSize = g.MeasureString(text, font);
            if (autoSizeByText)
            {
                size = new SizeF(fontSize.Width + 20, fontSize.Height + 20);
            }

            float x = position.X;
            float y = position.Y;
            switch(controlAlignHorizontal)
            {
                case AlignMethod.CENTER:
                    x = (winWidth - size.Width) / 2;
                    break;
                case AlignMethod.LEFT:
                    x = 0;
                    break;
                case AlignMethod.RIGHT:
                    x= winWidth - size.Width;
                    break;
            }

            switch (controlAlignVertical)
            {
                case AlignMethod.CENTER:
                    y = (winHeight - size.Height) / 2;
                    break;
                case AlignMethod.TOP:
                    y = 0;
                    break;
                case AlignMethod.BOTTOM:
                    y = winHeight - size.Height;
                    break;
            }
            actualPosition = new PointF(x, y);
            g.DrawImage(image, x, y, size.Width, size.Height);

            var newPos = new PointF(actualPosition.X + textOffset.X, actualPosition.Y + textOffset.Y);
            switch (textAlign)
            {
                case AlignMethod.CENTER:
                    newPos = new PointF(
                        actualPosition.X + (size.Width - fontSize.Width) / 2,
                        actualPosition.Y + (size.Height - fontSize.Height) / 2);
                    break;
                case AlignMethod.LEFT:
                    newPos = new PointF(
                        actualPosition.X, actualPosition.Y + (size.Height - fontSize.Height) / 2);
                    break;
                case AlignMethod.RIGHT:
                    newPos = new PointF(
                        actualPosition.X + winWidth - fontSize.Width,
                        actualPosition.Y + (size.Height - fontSize.Height) / 2);
                    break;
            }
            if (fontSize.Width > size.Width)
            {
                RectangleF rect = new RectangleF(
                    newPos.X, newPos.Y, 
                    size.Width - textOffset.X * 2, 
                    size.Height - textOffset.Y * 2);
                g.DrawString(text, font, brush, rect);
            }
            else
            {
                g.DrawString(text, font, brush, newPos);
            }
        }

        private void wordWrap(int startIndex, string text, Graphics g, PointF point)
        {
            int idx = startIndex;
            StringBuilder builder = new StringBuilder();
            for (int i = idx; i < text.Length; i++)
            {
                SizeF strSize = g.MeasureString(builder.ToString(), font);
                if (strSize.Width + 5 < size.Width)
                {
                    builder.Append(text[i]);
                }
                else
                {
                    g.DrawString(builder.ToString(), font, brush, point);
                    idx = i;
                    break;
                }
            }
            builder.Clear();

            if (idx < text.Length - 1)
            {
                wordWrap(idx, text, g, point);
            }
        }

        public void AppendLine(string line)
        {
            text += "\r\n" + line;
        }

        public override void Render(Graphics g, IRenderer renderer)
		{
            Draw(g);
		}
	}
}
