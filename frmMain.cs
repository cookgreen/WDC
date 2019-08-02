using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Properties;

namespace Wardeclarer
{
    public partial class frmMain : Form
    {
        private bool isEditMode;
        private Timer timer = new Timer();
        private WardeclarerRenderer wardeclarerRender;
        private int mouseX;
        private int mouseY;
        public frmMain()
        {
            InitializeComponent();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
            isEditMode = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //TODO: Loop play the music
            wardeclarerRender = new WardeclarerRenderer(Width, Height);
            wardeclarerRender.ShutdownShowMessage += WardeclarerRender_ShutdownShowMessage;
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
            g.DrawImage(Resources.worldmap, 0, 0, Width, Height);
            if (isEditMode)
            {
                Font font = new Font("Baskerville Old Face", 50);
                e.Graphics.DrawString(string.Format("Mouse X: {0}, Mouse Y: {1}", mouseX, mouseY), font, Brushes.White, 0, 0);
            }
            //Execute run script
            wardeclarerRender.Paint(e.Graphics);
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
                wardeclarerRender.MouseClicked(e.X, e.Y);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
    }
}
