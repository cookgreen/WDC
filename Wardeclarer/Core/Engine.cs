using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Game;

namespace Wardeclarer.Core
{
	public class Engine
	{
		private GameObject lastEnterGameObject;
		private List<GameObject> gameObjects;
		public List<GameObject> GameObjects { get { return gameObjects; } }
		public event Action CanvasClicked;

		public Engine()
		{
			lastEnterGameObject = null;
		}

		public void AddIfNotExisted(GameObject gameObject)
		{
			var result = gameObjects.Where(o => o.UID == gameObject.UID);
			if (result.Count() == 0)
			{
				gameObjects.Add(gameObject);
			}
		}

		public void StartNewGame()
		{
			gameObjects = new List<GameObject>();
		}

		public void Exit()
		{
			gameObjects.Clear();
		}

		public void Update(Graphics g)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Update(g);
			}
		}

		public void MouseClicked(int x, int y)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				if(gameObjects[i].CheckEnterArea(x, y))
				{
					gameObjects[i].Click();
				}
			}
		}

		public void MouseMoved(int x, int y)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				var currentGameObject = gameObjects[i];
				if (currentGameObject.CheckEnterArea(x, y))
				{
					if (lastEnterGameObject != null &&
						currentGameObject.UID != lastEnterGameObject.UID)
					{
						lastEnterGameObject.Leave();
					}
					currentGameObject.Enter();
					lastEnterGameObject = currentGameObject;
					return;
				}
			}
			if (lastEnterGameObject != null)
			{
				lastEnterGameObject.Leave();
			}
		}
	}
}
