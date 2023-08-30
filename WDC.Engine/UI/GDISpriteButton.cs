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

		public GDISpriteButton(Bitmap image, Bitmap hoverImage, PointF position, int tolenrece = 15, float scale = 1, AlignMethod align = AlignMethod.CENTER)
        {
            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth;
            sprite = new Sprite(image, position, tolenrece, scale, align);
			hoverSprite = new Sprite(hoverImage, position, tolenrece, scale, align);

			this.position = position;
			area = new RectangleF(position.X - (image.Width * scale / 2), position.Y - (image.Height * scale / 2), image.Width * scale, image.Height * scale);

            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);
        }

		public override void Render(Graphics g, IRenderer renderer)
        {
            area = new RectangleF(left.ActualValue, top.ActualValue, sprite.Image.Width * sprite.Scale, sprite.Image.Height * sprite.Scale);
            if (state == LayerDetectedState.None || state == LayerDetectedState.Leave)
			{
                sprite.Position = new PointF(left.ActualValue, top.ActualValue);
                sprite.Render(g, renderer);
			}
			else if (state == LayerDetectedState.Enter)
            {
                hoverSprite.Position = new PointF(left.ActualValue, top.ActualValue);
                hoverSprite.Render(g, renderer);
			}
		}
	}
}
