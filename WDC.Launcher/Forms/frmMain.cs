using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Configure;
using WDC.Core;
using WDC.Forms;
using WDC.Interface;
using WDC.Script;

namespace WDC
{
    public partial class frmRenderPanel : RenderForm
    {
        private GameConfig config;
        private Point resolution;
        private bool isEditMode;
        private Timer timer = new Timer();
        private int mouseX;
        private int mouseY;
        private Engine engine;

        public Engine Engine
		{
			get { return engine; }
		}
        

        public frmRenderPanel(GameConfig config)
        {
            InitializeComponent();

            this.config = config;
            isEditMode = false;

            engine = new Engine();
            engine.Init(config);
            config.CurrentSelectedScript.BeforeRunScript();
            engine.StartNewGame();

            string iconFile = config.CurrentSelectedScript.Icon;
            if (File.Exists(iconFile))
            {
                Icon = new Icon(iconFile);
            }

            resolution = engine.Resolution;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //TODO: Loop play the music
            engine.RegisterMainForm(this);
            engine.MainFormLoaded(this);

            frmDeveloperConsole developerConsoleForm = new frmDeveloperConsole(engine, config.CurrentSelectedScript);
            engine.RegisterConsoleForm(developerConsoleForm);
            
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

			int renderX = (Screen.PrimaryScreen.Bounds.Width - resolution.X) / 2;
			int renderY = 0;
			int renderWidth = resolution.X;

			if (WorldMap != null)
			{
				g.DrawImage(WorldMap, renderX, renderY, renderWidth, Height);
				if (isEditMode)
				{
					Font font = new Font("Baskerville Old Face", 50);
					e.Graphics.DrawString(string.Format("Mouse X: {0}, Mouse Y: {1}", mouseX, mouseY), font, Brushes.White, 0, 0);
				}
			}

			engine.Render(e.Graphics);
            engine.Update();
            g.Flush();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isEditMode = !isEditMode;
                if (isEditMode)
                {
                    engine.EnterDebugMode();
                }
                else
                {
                    engine.LeaveDebugMode();
                }
            }
            else
            {
                engine.MouseClicked(e.X, e.Y);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            engine.MouseMoved(e.X, e.Y);
		}

		private void canvas_MouseUp(object sender, MouseEventArgs e)
		{
            engine.MouseUp(e.X, e.Y);
		}

		private void frmRenderPanel_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.I)
            {
                if (!engine.ConsoleVisible)
                {
                    engine.ShowConsole();
                }
				else
				{
                    engine.HideConsole();
				}
            }
		}
	}
}
