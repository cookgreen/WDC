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
    public class GDISpriteButton : Widget
	{
		private Sprite sprite;
		private Sprite hoverSprite;

		public GDISpriteButton(Bitmap image, Bitmap hoverImage, PointF position, float scale = 1, AlignMethod align = AlignMethod.CENTER)
        {
            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth;
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
		}
	}
}
