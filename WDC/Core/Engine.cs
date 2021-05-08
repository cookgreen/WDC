using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Configure;
using WDC.Console;
using WDC.Forms;
using WDC.Game;
using WDC.Interface;
using WDC.Locate;
using WDC.Script;

namespace WDC.Core
{
	public class Engine
	{
        private static int winHeight;
        private static int winWidth;
        private frmRenderPanel mainForm;
        private WDCScript script;
		private GameObject lastEnterGameObject;
		private bool isEnableCheat;
		private List<GameObject> gameObjects;
		private frmDeveloperConsole developerConsole;
		private Point renderResolution;
		private IRenderer renderer;

		public void DisableCheat()
		{
			isEnableCheat = false;
		}

		public Point Resolution
        {
            get { return renderer.Resoultion; }
        }

		public List<GameObject> GameObjects { get { return gameObjects; } }
        //public event Action CanvasClicked;
        public static int WinHeight { get { return winHeight; } }
        public static int WinWidth { get { return winWidth; } }
		public bool ConsoleVisible { get { return developerConsole.Visible; } }
		public bool CheatEnabled { get { return isEnableCheat; } }

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

        public IRenderer Renderer { get { return renderer; } }

        public Engine()
		{
			lastEnterGameObject = null;
		}

        public void Init(GameConfig config)
        {
            script = config.CurrentSelectedScript;
			LocateTableManager.Instance.Init(config.CurrentSelectedLocate);

			renderResolution = new Point();
			string[] tokens = config.Resolution.Split('x');
			renderResolution.X = int.Parse(tokens[0]);
			renderResolution.Y = int.Parse(tokens[1]);

			renderer = new GDIRenderer();
			renderer.ChangeResolution(renderResolution);

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
			developerConsole = new frmDeveloperConsole(this, script);
			ConsoleCommandManager.Instance.AddConsoleCommand(new ListAvaliabeCommandsConsoleCommand());
		}

		public void EnableCheat()
		{
			isEnableCheat = true;
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

		public void Render(Graphics g)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Render(g, renderer);
			}
            script.Render(g, renderer);
		}

		public void Update()
        {

        }

		public void MouseClicked(int x, int y)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				if(gameObjects[i].CheckEnterArea(x, y, this))
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
				if (currentGameObject.CheckEnterArea(x, y, this))
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

		public void ShowConsole()
		{
			developerConsole.Show();
			developerConsole.BringToFront();
		}

		public void HideConsole()
		{
			developerConsole.Hide();
		}
	}
}
