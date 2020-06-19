namespace Wardeclarer.Forms
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbLanguages = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(337, 306);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select a script:";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(3, 17);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(331, 286);
			this.listBox1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(272, 347);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(191, 347);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(351, 338);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(343, 312);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Script";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.cmbLanguages);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(343, 312);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Game";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Language:";
			// 
			// cmbLanguages
			// 
			this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguages.FormattingEnabled = true;
			this.cmbLanguages.Items.AddRange(new object[] {
			"简体中文",
			"English"});
			this.cmbLanguages.Location = new System.Drawing.Point(71, 8);
			this.cmbLanguages.Name = "cmbLanguages";
			this.cmbLanguages.Size = new System.Drawing.Size(262, 20);
			this.cmbLanguages.TabIndex = 1;
			// 
			// frmScriptSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 382);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmScriptSelector";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configure";
			this.Load += new System.EventHandler(this.frmScriptSelector_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbLanguages;
	}
}