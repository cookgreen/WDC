using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        public Anchor Anchor { get; set; }

        public event Action DestReached;
        public bool GreyScale;

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
            this.scale = scale;
            size = new SizeF(image.Width * scale, image.Height * scale);
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
            Anchor = Anchor.LeftTop;
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
            PointF renderPos = position;
            switch (Anchor)
            {
                case Anchor.Center:
                    renderPos = new PointF(position.X - size.Width / 2, position.Y - size.Height / 2);
                    break;
                case Anchor.TopCenter:
                    renderPos = new PointF(position.X - size.Width / 2, position.Y);
                    break;
                case Anchor.BottomCenter:
                    renderPos = new PointF(position.X - size.Width / 2, position.Y - size.Height);
                    break;
                case Anchor.LeftBottom:
                    renderPos = new PointF(position.X, position.Y + size.Height);
                    break;
                case Anchor.LeftCenter:
                    renderPos = new PointF(position.X, position.Y - size.Height / 2);
                    break;
                case Anchor.LeftTop:
                    break;
                case Anchor.RightBottom:
                    renderPos = new PointF(position.X - size.Width, position.Y - size.Height);
                    break;
                case Anchor.RightCenter:
                    renderPos = new PointF(position.X - size.Width, position.Y - size.Height / 2);
                    break;
                case Anchor.RightTop:
                    renderPos = new PointF(position.X - size.Width, position.Y);
                    break;
            }

            if (GreyScale)
            {
                g.DrawImage(renderGreyScale(image), renderPos.X, renderPos.Y, image.Width * scale, image.Height * scale);
            }
            else
            {
                g.DrawImage(image, renderPos.X, renderPos.Y, image.Width * scale, image.Height * scale);
            }

            if(Engine.Instance.IsDebug)
            {
                g.DrawString(string.Format("X - {0}, Y - {1}", position.X, position.Y), new Font("Arial", 10), Brushes.Black, position.X, position.Y - 20);
                g.DrawRectangle(new Pen(new SolidBrush(Color.White)), renderPos.X, renderPos.Y, image.Width * scale, image.Height * scale);
            }
        }

        private Bitmap renderGreyScale(Image original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            newBitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
                  {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
                  });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
    }
}
