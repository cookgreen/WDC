namespace WDC.Forms
{
	partial class frmConfigure
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gbScript = new System.Windows.Forms.GroupBox();
            this.scriptList = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbScript = new System.Windows.Forms.TabPage();
            this.tbGame = new System.Windows.Forms.TabPage();
            this.lbResolution = new System.Windows.Forms.Label();
            this.cmbResolutionList = new System.Windows.Forms.ComboBox();
            this.cmbLanguages = new System.Windows.Forms.ComboBox();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.gbScript.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbScript.SuspendLayout();
            this.tbGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScript
            // 
            this.gbScript.Controls.Add(this.scriptList);
            this.gbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScript.Location = new System.Drawing.Point(4, 5);
            this.gbScript.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScript.Name = "gbScript";
            this.gbScript.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScript.Size = new System.Drawing.Size(510, 443);
            this.gbScript.TabIndex = 0;
            this.gbScript.TabStop = false;
            this.gbScript.Text = "Select a script:";
            // 
            // scriptList
            // 
            this.scriptList.FormattingEnabled = true;
            this.scriptList.Location = new System.Drawing.Point(9, 33);
            this.scriptList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scriptList.Name = "scriptList";
            this.scriptList.Size = new System.Drawing.Size(484, 400);
            this.scriptList.TabIndex = 0;
            this.scriptList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(410, 501);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(288, 501);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 38);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbScript);
            this.tabControl1.Controls.Add(this.tbGame);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(526, 486);
            this.tabControl1.TabIndex = 1;
            // 
            // tbScript
            // 
            this.tbScript.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.tbScript.Controls.Add(this.gbScript);
            this.tbScript.Location = new System.Drawing.Point(4, 29);
            this.tbScript.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScript.Name = "tbScript";
            this.tbScript.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScript.Size = new System.Drawing.Size(518, 453);
            this.tbScript.TabIndex = 0;
            this.tbScript.Text = "Script";
            this.tbScript.UseVisualStyleBackColor = true;
            // 
            // tbGame
            // 
            this.tbGame.Controls.Add(this.lbResolution);
            this.tbGame.Controls.Add(this.cmbResolutionList);
            this.tbGame.Controls.Add(this.cmbLanguages);
            this.tbGame.Controls.Add(this.lbLanguage);
            this.tbGame.Location = new System.Drawing.Point(4, 29);
            this.tbGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGame.Name = "tbGame";
            this.tbGame.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGame.Size = new System.Drawing.Size(518, 453);
            this.tbGame.TabIndex = 1;
            this.tbGame.Text = "Game";
            this.tbGame.UseVisualStyleBackColor = true;
            // 
            // lbResolution
            // 
            this.lbResolution.AutoSize = true;
            this.lbResolution.Location = new System.Drawing.Point(9, 62);
            this.lbResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResolution.Name = "lbResolution";
            this.lbResolution.Size = new System.Drawing.Size(91, 20);
            this.lbResolution.TabIndex = 3;
            this.lbResolution.Text = "Resolution:";
            // 
            // cmbResolutionList
            // 
            this.cmbResolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolutionList.FormattingEnabled = true;
            this.cmbResolutionList.Items.AddRange(new object[] {
            "640x480",
            "800x600",
            "1024x768",
            "1280x960"});
            this.cmbResolutionList.Location = new System.Drawing.Point(124, 57);
            this.cmbResolutionList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbResolutionList.Name = "cmbResolutionList";
            this.cmbResolutionList.Size = new System.Drawing.Size(373, 28);
            this.cmbResolutionList.TabIndex = 2;
            // 
            // cmbLanguages
            // 
            this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Items.AddRange(new object[] {
            "简体中文",
            "English"});
            this.cmbLanguages.Location = new System.Drawing.Point(124, 13);
            this.cmbLanguages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.Size = new System.Drawing.Size(373, 28);
            this.cmbLanguages.TabIndex = 1;
            this.cmbLanguages.SelectedIndexChanged += new System.EventHandler(this.cmbLanguages_SelectedIndexChanged);
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Location = new System.Drawing.Point(9, 18);
            this.lbLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(84, 20);
            this.lbLanguage.TabIndex = 0;
            this.lbLanguage.Text = "Language:";
            // 
            // frmConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigure";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WDC";
            this.Load += new System.EventHandler(this.frmScriptSelector_Load);
            this.gbScript.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbScript.ResumeLayout(false);
            this.tbGame.ResumeLayout(false);
            this.tbGame.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbScript;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbScript;
		private System.Windows.Forms.TabPage tbGame;
		private System.Windows.Forms.Label lbLanguage;
		private System.Windows.Forms.ComboBox cmbLanguages;
		private System.Windows.Forms.CheckedListBox scriptList;
        private System.Windows.Forms.Label lbResolution;
        private System.Windows.Forms.ComboBox cmbResolutionList;
    }
}