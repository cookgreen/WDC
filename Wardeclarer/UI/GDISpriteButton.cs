using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Common;
using Wardeclarer.Game;

namespace Wardeclarer.UI
{
	public class GDISpriteButton : Widget
	{
		private Sprite sprite;
		private Sprite hoverSprite;

		public GDISpriteButton(Bitmap image, Bitmap hoverImage, PointF position, int tolenrece = 15, float scale = 1, AlignMethod align = AlignMethod.CENTER)
		{
			sprite = new Sprite(image, position, tolenrece, scale, align);
			hoverSprite = new Sprite(hoverImage, position, tolenrece, scale, align);

			this.position = position;
			area = new RectangleF(position.X, position.Y, image.Width * scale, image.Height * scale);
		}

		public override void Update(Graphics g)
		{
			sprite.Render(g);
		}
	}
}
