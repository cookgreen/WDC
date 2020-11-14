namespace Wardeclarer.Forms
{
	partial class frmDeveloperConsole
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
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(12, 12);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(448, 376);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.Text = "";
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(12, 394);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(367, 21);
			this.txtInput.TabIndex = 1;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(385, 394);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// frmDeveloperConsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 427);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.txtOutput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeveloperConsole";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Developer Console";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtOutput;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Button btnSend;
	}
}