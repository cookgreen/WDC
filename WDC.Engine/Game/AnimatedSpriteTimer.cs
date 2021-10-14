using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
	public class AnimatedSpriteTimer
	{
		private int time;
		public int CurrentTime { get { return time; } }

		public AnimatedSpriteTimer()
		{
			time = 0;
		}

		public void Reset()
		{
			time = 0;
		}

		public void Update()
		{
			time++;
		}
	}
}
