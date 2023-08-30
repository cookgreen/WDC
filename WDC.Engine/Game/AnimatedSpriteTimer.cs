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
		private int initDelayTime;
		private int currentDelayTime;
		public int CurrentTime { get { return time; } }

		public event Action Tick;

		public AnimatedSpriteTimer(int initDelayTime)
		{
			time = 0;
			this.initDelayTime = initDelayTime;
			currentDelayTime = initDelayTime;
		}

		public void Reset()
		{
			time = 0;
			currentDelayTime = -1;
		}

		public void Update()
		{
			if(time == initDelayTime)
			{
				Tick?.Invoke();
				time = 0;
			}
			else
			{
				time++;
			}
		}
	}
}
