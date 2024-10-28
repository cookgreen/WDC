using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

		public bool ShowToolTip { get; set; }
        public string Tooltip { get; set; }
		public bool Enabled { get; set; }

		public event Action<string, bool, string, Point> ShowToolTipEvent;

        public GDISpriteButton(Bitmap image, Bitmap hoverImage, PointF position, UIMetrics metrics, float scale = 1, AlignMethod align = AlignMethod.CENTER)
        {
			this.metrics = metrics;

            winHeight = Engine.Instance.WinHeight;
            winWidth = Engine.Instance.WinWidth;
            sprite = new Sprite("ui_button", image, position, align, scale);
			hoverSprite = new Sprite("ui_button_hover", hoverImage, position, align, scale);
			size = sprite.Size;

			this.position = position;
			area = new RectangleF(position.X, position.Y, image.Width * scale, image.Height * scale);

            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);

            Enabled = true;
        }

        public override bool CheckEnterArea(int x, int y, Engine engine)
        {
            if (Enabled)
            {
                return base.CheckEnterArea(x, y, engine);
            }
            else
            {
                return false;
            }
        }

        public override void Render(Graphics g, IRenderer renderer)
        {
            left = new UIWidgetValue(metrics, position.X, winWidth);
            top = new UIWidgetValue(metrics, position.Y, winHeight);

            area = new RectangleF(left.ActualValue, top.ActualValue, sprite.Image.Width * sprite.Scale, sprite.Image.Height * sprite.Scale);
			
			Sprite renderSprite;
			switch(state)
			{
				case LayerDetectedState.Enter:
                    renderSprite = hoverSprite;
                    if (Enabled)
                    {
                        renderSprite.GreyScale = false;
                        if (ShowToolTip && !string.IsNullOrEmpty(Tooltip))
                        {
                            ShowToolTipEvent?.Invoke(uniqueID, true, Tooltip, mousePosition);
                        }
                    }
					break;
				case LayerDetectedState.Leave:
                    renderSprite = sprite;
                    if (ShowToolTip && !string.IsNullOrEmpty(Tooltip))
                    {
                        ShowToolTipEvent?.Invoke(uniqueID, false, Tooltip, mousePosition);
                    }
                    break;
				default:
                    renderSprite = sprite; 
					break;
			}

            renderSprite.GreyScale = !Enabled;

            switch (metrics)
			{
				case UIMetrics.Pixel:
					renderSprite.Position = position;
                    renderSprite.Render(g, renderer);
                    break;
				case UIMetrics.Relative:
                    renderSprite.Position = new PointF(left.ActualValue, top.ActualValue);
                    renderSprite.Render(g, renderer);
                    break;
			}
		}
    }
}
