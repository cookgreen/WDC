using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
    public enum SpriteAxisMovementType
    {
        MovementByXAxis,
		MovementByYAxis
	}

	public enum SpriteMovementDirection
	{
		Left,
		Right,
        Up,
        Down
	}

	public class SpriteAxisMovement : SpriteMovement
    {
        private SpriteAxisMovementType type;
        private SpriteMovementDirection direction;
        private PointF position;
        private float speed;

		public override event Action DestReached;

		public SpriteAxisMovement(
			SpriteAxisMovementType type,
			SpriteMovementDirection direction,
            PointF startPos,
            float speed,
            int collideCheckTolerance) : base(collideCheckTolerance)
        {
            this.type = type;
            this.direction = direction;
            this.speed = speed;
			position = startPos;
		}

        public SpriteAxisMovement(
			SpriteAxisMovementType type, 
            SpriteMovementDirection direction, 
            PointF startPos, 
            PointF destPos, 
            float speed,
			int collideCheckTolerance) : base(collideCheckTolerance)
		{
            this.type = type;
            this.direction = direction;
            this.position = startPos;
            destPosition = destPos;
            this.speed = speed;
        }

        public override PointF GetNext()
        {
            switch(type)
            {
                case SpriteAxisMovementType.MovementByXAxis:
                    return GextNextX();
                case SpriteAxisMovementType.MovementByYAxis:
                    return GextNextY();
                default:
                    return position;
            }
        }

        protected override PointF GextNextX()
        {
            int mulValue = 1;
            if (direction == SpriteMovementDirection.Left ||
                direction == SpriteMovementDirection.Up)
            {
                mulValue = -1;
            }
            position = new PointF(position.X + speed * mulValue, position.Y);
            return position;
        }

        protected override PointF GextNextY()
        {
            int mulValue = 1;
            if (direction == SpriteMovementDirection.Left ||
				direction == SpriteMovementDirection.Up)
            {
                mulValue = -1;
			}
			position = new PointF(position.X, position.Y + speed * mulValue);
            return position;
        }

		public override void CheckDestReached()
		{
			if (destPosition.X != -1 &&
				destPosition.Y != -1)
			{
				if (destPosition.X != position.X &&
					destPosition.Y != position.Y)
				{
					float distanceX = Math.Abs(destPosition.X - position.X);
					float distanceY = Math.Abs(destPosition.Y - position.Y);

                    //Debug
                    //Font font = new Font("Arial", 50);
                    //g.DrawString(string.Format("Distance X: {0}, Distance Y: {1}", distanceX, distanceY), font, Brushes.White, 0, 0);

                    if (type == SpriteAxisMovementType.MovementByXAxis)
                    {
                        if (distanceX <= collideCheckTolerance)
                        {
                            DestReached?.Invoke();
                        }
                    }
                    else if (type == SpriteAxisMovementType.MovementByYAxis)
                    {
                        if (distanceY <= collideCheckTolerance)
                        {
                            DestReached?.Invoke();
                        }
                    }
				}
				else
				{
					DestReached?.Invoke();
				}
			}
		}
	}
}
