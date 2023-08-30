using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
	public class SpriteMovement
    {
        protected int collideCheckTolerance;
		protected PointF destPosition;
        public PointF DestPosition 
        {
            get { return destPosition; }
		}
		public virtual event Action DestReached;

		public SpriteMovement(int collideCheckTolerance)
        {
            destPosition = new PointF(-1, -1);
            this.collideCheckTolerance = collideCheckTolerance;
		}

        public virtual PointF GetNext()
        {
            return new PointF();
        }

        protected virtual PointF GextNextX()
        {
            return new PointF();
        }

        protected virtual PointF GextNextY()
        {
            return new PointF();
        }

        public virtual void CheckDestReached()
        {
            DestReached?.Invoke();
		}
    }
}
