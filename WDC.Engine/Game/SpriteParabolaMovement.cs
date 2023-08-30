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
		private double init_angle;
		private int speed;
		public override event Action DestReached;

		public SpriteParabolaMovement(
			double init_angle, 
			int speed,
			int collideCheckTolerance
		) : base(collideCheckTolerance)
		{
			this.init_angle = init_angle;
			this.speed = speed;
		}

		public override PointF GetNext()
		{
			return base.GetNext();
		}

		public override void CheckDestReached()
		{
			base.CheckDestReached();
		}
	}
}
