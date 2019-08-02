using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer
{
    public enum AlignMethod
    {
        CENTER,
        LEFT,
        RIGHT,
        BOTTOM,
    }

    /// <summary>
    /// Can render an text option which can receive the mouse click command
    /// </summary>
    public class GDISelectableOption
    {
        private string text;
        private PointF position;
        private Brush brush;
        private RectangleF area;
        private Font font;
        private bool inited;
        private AlignMethod alignment;
        private int winHeight;
        private int winWidth;

        public event Action Clicked;
        public bool Enabled
        {
            get
            {
                return inited;
            }
        }
        public int Height
        {
            get
            {
                return font.Height;
            }
        }

        public PointF Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public GDISelectableOption(string text, string fontName, int fontSize, Brush brush, int winWidth, int winHeight, PointF position, ref List<GDISelectableOption> options, bool needAdjustWithFont = false, AlignMethod alignment = AlignMethod.CENTER)
        {
            this.winHeight = winHeight;
            this.winWidth = winWidth;
            font = new Font(fontName, fontSize);
            this.brush = brush;
            this.position = position;
            this.text = text;
            inited = false;
            if (needAdjustWithFont)
            {
                this.position.Y = this.position.Y - font.Height;
            }
            this.alignment = alignment;
        }
        public void Draw(Graphics g)
        {
            if (!inited)
            {
                area = new RectangleF();
                SizeF fontSize = g.MeasureString(text, font);
                area.Height = fontSize.Height;
                area.Width = fontSize.Width;
                inited = true;
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
            }
            g.DrawString(text, font, brush, Position);
        }

        public bool CheckEnterArea(float x, float y)
        {
            if (area == null)
            {
                return false;
            }
            return x > Position.X && x < Position.X + area.Width && y > Position.Y && y < Position.Y + area.Height;
        }

        public void Click()
        {
            Clicked?.Invoke();
        }
    }
}
