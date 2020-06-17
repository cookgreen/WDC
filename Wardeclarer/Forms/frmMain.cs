using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Core;
using Wardeclarer.Interface;
using Wardeclarer.Properties;
using Wardeclarer.Script;

namespace Wardeclarer
{
    public partial class frmRenderPanel : Form
    {
        private bool isEditMode;
        private Timer timer = new Timer();
        private WDCScript currentScript;
        private int mouseX;
        private int mouseY;
        private Bitmap worldmap;
        private Engine engine;
        public Engine Engine
		{
			get { return engine; }
		}
        public frmRenderPanel(WDCScript currentScript)
        {
            InitializeComponent();
            isEditMode = false;
            this.currentScript = currentScript;
            currentScript.BeforeRunScript();
            engine = new Engine();
            engine.StartNewGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //TODO: Loop play the music
            currentScript.Init(Width, Height, engine);
            currentScript.SetRenderPanel(this);
            if ((currentScript as INotifyMessageWhenShutdown) != null)
            {
                ((INotifyMessageWhenShutdown)currentScript).ShutdownShowMessage += WardeclarerRender_ShutdownShowMessage;
            }
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void WardeclarerRender_ShutdownShowMessage(string message, string title)
        {
            Hide();
            if(MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawImage(worldmap, 0, 0, Width, Height);
            if (isEditMode)
            {
                Font font = new Font("Baskerville Old Face", 50);
                e.Graphics.DrawString(string.Format("Mouse X: {0}, Mouse Y: {1}", mouseX, mouseY), font, Brushes.White, 0, 0);
            }
            //Execute run script
            engine.Update(e.Graphics);
            currentScript.Update(e.Graphics);
            g.Flush();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isEditMode = !isEditMode;
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
        }

		public void SetWorldMap(Bitmap worldmap)
		{
            this.worldmap = worldmap;
		}
	}
}
