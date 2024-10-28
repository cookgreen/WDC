using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
	public class AnimatedSpriteTimer
	{
		private float time;
		private float initDelayTime;
		private float currentDelayTime;
		private float intervalTime;
		private bool isActive;

		public float CurrentTime { get { return time; } }

		public event Action Tick;

		public AnimatedSpriteTimer(float initDelayTime, float intervalTime)
		{
			time = 0;
			this.initDelayTime = initDelayTime;
			this.intervalTime = intervalTime;
			currentDelayTime = initDelayTime;
			isActive = false;
		}

		public void Start()
		{
			isActive = true;
		}

		public void Reset()
		{
			time = 0;
			currentDelayTime = -1;
		}

		public void Update()
		{
			if(!isActive)
			{
				return;
			}

			if(time == initDelayTime)
			{
				Tick?.Invoke();
				time = 0;
			}
			else
			{
				time += intervalTime;
			}
		}

		public void Deactive()
		{
			isActive = false;
		}
	}
}
