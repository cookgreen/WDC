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
		private List<GameObject> gameObjects;
		public List<GameObject> GameObjects { get { return gameObjects; } }
		public event Action CanvasClicked;

		public Engine()
		{
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
	}
}
