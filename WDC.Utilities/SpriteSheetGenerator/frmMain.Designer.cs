namespace SpriteSheetGenerator
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnGenerate = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditNewSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDeleteSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceList = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucSpriteSequence = new SpriteSheetGenerator.ucSpriteSequence();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu.SuspendLayout();
            this.sequenceList.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(420, 536);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(169, 67);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(605, 28);
            this.mainMenu.TabIndex = 4;
            this.mainMenu.Text = "mainMenu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 24);
            this.mnuFile.Text = "File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(118, 26);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditNewSequence,
            this.mnuEditDeleteSequence});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(51, 24);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuEditNewSequence
            // 
            this.mnuEditNewSequence.Name = "mnuEditNewSequence";
            this.mnuEditNewSequence.Size = new System.Drawing.Size(216, 26);
            this.mnuEditNewSequence.Text = "New Sequence";
            this.mnuEditNewSequence.Click += new System.EventHandler(this.mnuEditNewSequence_Click);
            // 
            // mnuEditDeleteSequence
            // 
            this.mnuEditDeleteSequence.Name = "mnuEditDeleteSequence";
            this.mnuEditDeleteSequence.Size = new System.Drawing.Size(216, 26);
            this.mnuEditDeleteSequence.Text = "Delete Sequence";
            // 
            // sequenceList
            // 
            this.sequenceList.Controls.Add(this.tabPage1);
            this.sequenceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.sequenceList.Location = new System.Drawing.Point(0, 28);
            this.sequenceList.Name = "sequenceList";
            this.sequenceList.SelectedIndex = 0;
            this.sequenceList.Size = new System.Drawing.Size(605, 502);
            this.sequenceList.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucSpriteSequence);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucSpriteSequence
            // 
            this.ucSpriteSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSpriteSequence.Location = new System.Drawing.Point(3, 3);
            this.ucSpriteSequence.Name = "ucSpriteSequence";
            this.ucSpriteSequence.Size = new System.Drawing.Size(591, 463);
            this.ucSpriteSequence.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 610);
            this.Controls.Add(this.sequenceList);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite Sheet Generator";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.sequenceList.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnGenerate;
        private MenuStrip mainMenu;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuFileExit;
        private ImageList imageList;
        private TabControl sequenceList;
        private ToolStripMenuItem mnuEdit;
        private ToolStripMenuItem mnuEditNewSequence;
        private TabPage tabPage1;
        private ToolStripMenuItem mnuEditDeleteSequence;
        private System.Windows.Forms.Timer timer;
        private ucSpriteSequence ucSpriteSequence;
    }
}