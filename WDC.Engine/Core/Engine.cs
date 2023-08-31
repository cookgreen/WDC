using Microsoft.VisualBasic.Devices;
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
using WDC.UI;

namespace WDC.Core
{
	public class Engine
	{
        private static int winHeight;
        private static int winWidth;
        private WDCScript script;
		private GameObject lastEnterGameObject;
		private bool isEnableCheat;
		private List<GameObject> gameObjects;
		private Point renderResolution;
		private IRenderer renderer;
		private bool isDebug;

		public bool IsDebug
		{ 
			get { return isDebug; } 
		}

		private FormManager formManager = new FormManager();

		public Point Resolution
        {
            get { return renderer.Resoultion; }
        }

		public List<GameObject> GameObjects { get { return gameObjects; } }
        //public event Action CanvasClicked;
        public static int WinHeight { get { return winHeight; } }
        public static int WinWidth { get { return winWidth; } }
		public bool ConsoleVisible { get { return formManager.DeveloperConsole.Visible; } }
		public bool CheatEnabled { get { return isEnableCheat; } }

		public event Action<int, int> MouseUpEvent;

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
			instance = this;
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

        public void MainFormLoaded(RenderForm mainForm)
        {
            winWidth = mainForm.Width;
            winHeight = mainForm.Height;
            script.Init(this);
            if ((script as INotifyMessageWhenShutdown) != null)
            {
                ((INotifyMessageWhenShutdown)script).ShutdownShowMessage += Render_ShutdownShowMessage;
            }
			ConsoleCommandManager.Instance.AddConsoleCommand(new ListAvaliabeCommandsConsoleCommand());
		}

        public void ChangeBackground(Bitmap worldmap)
        {
			formManager.RenderPanel.WorldMap = worldmap;
        }

        public void EnableCheat()
		{
			isEnableCheat = true;
		}

		public void DisableCheat()
		{
			isEnableCheat = false;
		}

		public void EnterDebugMode()
		{
			isDebug = true;
		}

		public void LeaveDebugMode()
		{
			isDebug = false;
		}

		public void RegisterMainForm(RenderForm frmRenderPanel)
		{
			formManager.RenderPanel = frmRenderPanel;
		}

		public void RegisterConsoleForm(DeveloperConsoleForm frmRenderPanel)
		{
			formManager.DeveloperConsole = frmRenderPanel;
		}

		private void Render_ShutdownShowMessage(string message, string title)
        {
            formManager.RenderPanel.Hide();
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
			//if (IsDebug)
			//{
			//	Font font = new Font("Baskerville Old Face", 50);
			//	g.DrawString(string.Format("Mouse X: {0}, Mouse Y: {1}", mouseX, mouseY), font, Brushes.White, 0, 0);
			//}
			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Render(g, renderer);
			}

            script.Render(g, renderer);
			UIManager.Instance.Render(g, renderer);
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
			script.MouseClicked(x, y);
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

			script.MouseMoved(x, y);
		}

		public void MouseUp(int x, int y)
		{
			MouseUpEvent?.Invoke(x, y);
		}

		public void ShowConsole()
		{
			formManager.DeveloperConsole.Show();
			formManager.DeveloperConsole.BringToFront();
		}

		public void HideConsole()
		{
			formManager.DeveloperConsole.Hide();
		}
	}
}
