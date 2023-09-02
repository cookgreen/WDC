using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.UI;

namespace WDC.Game
{
    public class Sprite : GameObject
    {
        private Image image;
        private float scale;
        private SpriteMovement movement;

        public Image Image { get { return image; } }
        public float Scale { get { return scale; } }
        public SpriteMovement Movement { get { return movement; } }
		public event Action DestReached;

		public Sprite(
            string typeName, 
            Image image, 
            PointF position, 
            AlignMethod alignment = AlignMethod.CENTER,
			float scale = 1
         )
            : base(typeName)
        {
            this.typeName = typeName;
            this.image = image;
            this.position = position;
            size = new SizeF(image.Width, image.Height);
            this.scale = scale;
            switch (alignment)
            {
                case AlignMethod.CENTER:
                    this.position = new PointF(position.X - (image.Width * scale) / 2, position.Y - (image.Height * scale) / 2);
                    break;
                case AlignMethod.BOTTOM:
                    this.position = new PointF(position.X - (image.Width * scale) / 2, position.Y - (image.Height * scale) / 3 * 2);
                    break;
                case AlignMethod.PERCENT:
                    break;
                case AlignMethod.MANUAL:
                    break;
            }
        }

        public void SetSteering(SpriteMovement movement)
        {
            this.movement = movement;
            if(movement != null)
			{
				movement.DestReached += Movement_DestReached;
			}
        }

		private void Movement_DestReached()
		{
            DestReached?.Invoke();
		}

		public override void Render(Graphics g, IRenderer renderer)
        {
            if (movement != null)
            {
                position = movement.GetNext();
                movement.CheckDestReached();
            }

            g.DrawImage(image, position.X, position.Y, image.Width * scale, image.Height * scale);

            if(Engine.Instance.IsDebug)
            {
                g.DrawRectangle(new Pen(new SolidBrush(Color.White)), position.X, position.Y, image.Width * scale, image.Height * scale);
            }
        }
    }
}
