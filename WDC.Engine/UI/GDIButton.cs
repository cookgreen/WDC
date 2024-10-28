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
	public class GDITextOption
	{
		public string Text { get; set; }
		public Color TextColor { get; set; }
		public AlignMethod TextAlign { get; set; }
		public int FontSize { get; set; }
		public string FontFamily { get; set; }

		public GDITextOption()
		{
			TextColor = Color.Black;
			TextAlign = AlignMethod.CENTER;
			FontFamily = "Arial";
			FontSize = 15;
		}
    }

    public class GDIButton : Widget
	{
		private GDITextOption text;
		private Sprite sprite;
		private Sprite hoverSprite;

		public GDIButton(
			Bitmap image, 
			Bitmap hoverImage,
            GDITextOption text, 
			PointF position, 
			float scale = 1, 
			AlignMethod align = AlignMethod.CENTER)
        {
            this.text = text;
            winHeight = Engine.Instance.WinHeight;
            winWidth = Engine.Instance.WinWidth;
            sprite = new Sprite("ui_button", image, position, align, scale);
			hoverSprite = new Sprite("ui_button_hover", hoverImage, position, align, scale);

			this.position = position;
			area = new RectangleF(position.X - (image.Width * scale / 2), position.Y - (image.Height * scale / 2), image.Width * scale, image.Height * scale);

            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);
        }

		public override void Render(Graphics g, IRenderer renderer)
        {
            area = new RectangleF(left.ActualValue, top.ActualValue, sprite.Image.Width * sprite.Scale, sprite.Image.Height * sprite.Scale);
			Sprite renderSprite;
			if (state == LayerDetectedState.Enter)
			{
				renderSprite = hoverSprite;
			}
			else
			{
				renderSprite = sprite;
			}
			renderSprite.Position = new PointF(left.ActualValue, top.ActualValue);
			renderSprite.Render(g, renderer);

			Font font = new Font(text.FontFamily, text.FontSize);
			var size = g.MeasureString(text.Text, font);
			g.DrawString(text.Text, font, new SolidBrush(text.TextColor), new PointF(
				renderSprite.Position.X + (renderSprite.Size.Width - size.Width) / 2,
				renderSprite.Position.Y + (renderSprite.Size.Height - size.Height) / 2));
		}
	}
}
