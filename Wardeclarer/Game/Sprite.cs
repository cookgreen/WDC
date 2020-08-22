using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Game
{
    public class Sprite : GameObject
    {
        private Image image;
        private float scale;
        private PointF destPos;
        private SpriteMovement movement;
        private int movement_type;
        private int collideCheckTolerance;
        public event Action DestReached;
        public Image Image
        {
            get { return image; }
        }

        public float Scale
        {
            get { return scale; }
        }
        public Sprite(Image image, PointF position, int collideCheckTolerance = 15, float scale = 1, AlignMethod alignment = AlignMethod.CENTER, int movement_type = 0)
        {
            this.image = image;
            this.position = position;
            this.scale = scale;
            this.movement_type = movement_type;
            this.collideCheckTolerance = collideCheckTolerance;
            destPos = new PointF(-1, -1);
            switch (alignment)
            {
                case AlignMethod.CENTER:
                    this.position = new PointF(position.X - (image.Width * scale) / 2, position.Y - (image.Height * scale) / 2);
                    break;
                case AlignMethod.BOTTOM:
                    this.position = new PointF(position.X - (image.Width * scale) / 2, position.Y - (image.Height * scale) / 3 * 2);
                    break;
            }
        }

        public void SetSteering(SpriteMovement movement)
        {
            this.movement = movement;
        }

        public override void Render(Graphics g, Point resolution)
        {
            if (destPos.X != -1 && destPos.Y != -1)
            {
                if (destPos.X != position.X && destPos.Y != position.Y)
                {
                    float distanceX = Math.Abs(destPos.X - position.X);
                    float distanceY = Math.Abs(destPos.Y - position.Y);
                    
                    //Font font = new Font("Baskerville Old Face", 50);
                    //g.DrawString(string.Format("Distance X: {0}, Distance Y: {1}", distanceX, distanceY), font, Brushes.White, 0, 0);

                    if (movement_type == 0)
                    {
                        if (distanceX <= collideCheckTolerance)
                        {
                            DestReached?.Invoke();
                        }
                        else
                        {
                            position = movement.GetNext();
                        }
                    }
                    else if (movement_type == 1)
                    {
                        if (distanceY <= collideCheckTolerance)
                        {
                            DestReached?.Invoke();
                        }
                        else
                        {
                            position = movement.GetNext();
                        }
                    }
                }
                else
                {
                    DestReached?.Invoke();
                }
            }
            g.DrawImage(image, position.X, position.Y, image.Width * scale, image.Height * scale);
        }

        public void MoveTo(PointF destPos)
        {
            this.destPos = destPos;
        }
    }
}
