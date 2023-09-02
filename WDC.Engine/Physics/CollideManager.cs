using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Game;

namespace WDC.Physics
{
	public class CollideManager
	{
		private Dictionary<Actor, List<Actor>> collideCheckDic;
		private static CollideManager instance;
		public static CollideManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CollideManager();
				}
				return instance;
			}
		}

		public event Action<Actor, Actor> CollideHappened;

		public CollideManager()
		{
			collideCheckDic = new Dictionary<Actor, List<Actor>>();
		}

		public void AddCollideCheckRange(Actor collideActor1, List<Actor> collideActorList)
		{
			if(collideCheckDic.ContainsKey(collideActor1))
			{
				collideCheckDic[collideActor1].AddRange(collideActorList);
			}
			else
			{
				collideCheckDic.Add(collideActor1, collideActorList);
			}
		}

		public void Update()
		{
			foreach (var pair in collideCheckDic)
			{
				Actor collideCheckActor1 = pair.Key;
				List<Actor> collideActorList = pair.Value;
				RectangleF actor1Rect = new RectangleF(collideCheckActor1.Position, collideCheckActor1.GameObject.Size);
				foreach(var actor in collideActorList)
				{
					RectangleF actor2Rect = new RectangleF(actor.Position, actor.GameObject.Size);
					if (actor1Rect.IntersectsWith(actor2Rect))
					{
						CollideHappened?.Invoke(collideCheckActor1, actor);
						break;
					}
				}
			}
		}

		public void ClearAll()
		{
			collideCheckDic.Clear();
		}
	}
}
