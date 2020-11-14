using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Game
{
    public class SpriteAxisMovement : SpriteMovement
    {
        private int type;
        private int direction;
        private PointF startPos;
        private float speed;
        public SpriteAxisMovement(int type, int direction, PointF startPos, float speed)
        {
            this.type = type;//0-X; 1-Y
            this.direction = direction;//0-Positive; 1-Negative
            this.startPos = startPos;
            this.speed = speed;
        }
        public override PointF GetNext()
        {
            switch(type)
            {
                case 0:
                    return GextNextX();
                case 1:
                    return GextNextY();
                default:
                    return startPos;
            }
        }

        protected override PointF GextNextX()
        {
            int mulValue = 1;
            if (direction == 1)
            {
                mulValue = -1;
            }
            startPos.X = startPos.X + speed * mulValue;
            return startPos;
        }

        protected override PointF GextNextY()
        {
            int mulValue = 1;
            if (direction == 1)
            {
                mulValue = -1;
            }
            startPos.Y = startPos.Y + speed * mulValue;
            return startPos;
        }
    }
}
