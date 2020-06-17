using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Game;
using Wardeclarer.Interface;
using Wardeclarer.Script;

namespace Wardeclarer.Core
{
	public class Engine
	{
        private static int winHeight;
        private static int winWidth;
        private frmRenderPanel mainForm;
        private WDCScript script;
		private GameObject lastEnterGameObject;
		private List<GameObject> gameObjects;
		public List<GameObject> GameObjects { get { return gameObjects; } }
        //public event Action CanvasClicked;
        public static int WinHeight { get { return winHeight; } }
        public static int WinWidth { get { return winWidth; } }
        private static Engine instance;
        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        public Engine()
		{
			lastEnterGameObject = null;
		}

        public void Init(WDCScript script)
        {
            this.script = script;
            script.BeforeRunScript();
        }

        public void MainFormLoaded(frmRenderPanel mainForm)
        {
            this.mainForm = mainForm;
            winWidth = mainForm.Width;
            winHeight = mainForm.Height;
            script.Init(this);
            script.SetRenderPanel(mainForm);
            if ((script as INotifyMessageWhenShutdown) != null)
            {
                ((INotifyMessageWhenShutdown)script).ShutdownShowMessage += Render_ShutdownShowMessage;
            }
        }

        private void Render_ShutdownShowMessage(string message, string title)
        {
            mainForm.Hide();
            if (MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                Application.Exit();
            }
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
            script.Update(g);
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
