namespace Wardeclarer
{
    partial class frmRenderPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenderPanel));
			this.canvas = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// canvas
			// 
			this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.canvas.Image = ((System.Drawing.Image)(resources.GetObject("canvas.Image")));
			this.canvas.Location = new System.Drawing.Point(0, 0);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(1024, 768);
			this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.canvas.TabIndex = 0;
			this.canvas.TabStop = false;
			this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
			this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
			this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
			// 
			// frmRenderPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 768);
			this.Controls.Add(this.canvas);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "frmRenderPanel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRenderPanel_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
    }
}

