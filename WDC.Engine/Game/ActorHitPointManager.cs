using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.Game
{
	public class ActorHitPointManager
	{
		public event Action<Actor, Actor> ActorIsDead;

		private static ActorHitPointManager instance;
		public static ActorHitPointManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new ActorHitPointManager();
				}
				return instance;
			}
		}

		public void Update()
		{
		}

		public void KillActor(Actor killedActor, Actor killerActor)
		{
			ActorIsDead?.Invoke(killedActor, killerActor);
		}
	}
}
