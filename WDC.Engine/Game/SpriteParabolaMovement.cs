using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
	public class SpriteParabolaMovement : SpriteMovement
	{
		private SpriteMovementDirection direction;
		private double speed;
		private double gravity;
		private double angle;
		private double shecheng;
		private PointF initPos;
		private double time;

		public SpriteParabolaMovement(
			SpriteMovementDirection direction,
			double angle,
			double speed, 
			double gravity, 
			PointF initPos) : base(5)
		{
			this.speed = speed;
			this.gravity = gravity;
			this.angle = angle;
			this.initPos = initPos;
			this.direction = direction;
			shecheng = (speed * speed / gravity) * (Math.Sin(2 * angle));
			time = 0;
		}

		public override PointF GetNext()
		{
			double mulVal = 1;
			double offsetX = speed * time * Math.Cos(angle * Math.PI / 180);
			double offsetY = speed * time * Math.Sin(angle * Math.PI / 180) - 0.5d * gravity * time * time;

			if(direction== SpriteMovementDirection.Left) 
			{
				mulVal = -1;
			}

			time += 0.5;

			return new PointF((float)(initPos.X + offsetX * mulVal), (float)(initPos.Y + offsetY));
		}

		public PointF GetNext(PointF position)
		{
			double offsetX = speed * Math.Cos(angle * Math.PI / 180);
			double offsetY = speed * Math.Sin(angle * Math.PI / 180) - gravity * time - 0.5d * gravity;
			return new PointF((float)(position.X + offsetX), (float)(position.Y - offsetY));
		}
	}
}
