namespace SpriteSheetGenerator
{
    partial class frmNewSheet
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
            this.txtSheetSizeX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSheetSizeY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpriteSizeY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSpriteSizeX = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSequenceName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSheetSizeX
            // 
            this.txtSheetSizeX.Location = new System.Drawing.Point(38, 26);
            this.txtSheetSizeX.Name = "txtSheetSizeX";
            this.txtSheetSizeX.Size = new System.Drawing.Size(248, 27);
            this.txtSheetSizeX.TabIndex = 3;
            this.txtSheetSizeX.Text = "0";
            this.txtSheetSizeX.TextChanged += new System.EventHandler(this.txtSheetSizeX_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSheetSizeY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSheetSizeX);
            this.groupBox1.Location = new System.Drawing.Point(330, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sheet Size:";
            this.groupBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // txtSheetSizeY
            // 
            this.txtSheetSizeY.Location = new System.Drawing.Point(38, 59);
            this.txtSheetSizeY.Name = "txtSheetSizeY";
            this.txtSheetSizeY.Size = new System.Drawing.Size(248, 27);
            this.txtSheetSizeY.TabIndex = 6;
            this.txtSheetSizeY.Text = "0";
            this.txtSheetSizeY.TextChanged += new System.EventHandler(this.txtSheetSizeY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSpriteSizeY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSpriteSizeX);
            this.groupBox2.Location = new System.Drawing.Point(24, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 102);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sprite Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Y:";
            // 
            // txtSpriteSizeY
            // 
            this.txtSpriteSizeY.Location = new System.Drawing.Point(38, 59);
            this.txtSpriteSizeY.Name = "txtSpriteSizeY";
            this.txtSpriteSizeY.Size = new System.Drawing.Size(248, 27);
            this.txtSpriteSizeY.TabIndex = 1;
            this.txtSpriteSizeY.Text = "0";
            this.txtSpriteSizeY.TextChanged += new System.EventHandler(this.txtSpriteSizeY_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "X:";
            // 
            // txtSpriteSizeX
            // 
            this.txtSpriteSizeX.Location = new System.Drawing.Point(38, 26);
            this.txtSpriteSizeX.Name = "txtSpriteSizeX";
            this.txtSpriteSizeX.Size = new System.Drawing.Size(248, 27);
            this.txtSpriteSizeX.TabIndex = 0;
            this.txtSpriteSizeX.Text = "0";
            this.txtSpriteSizeX.TextChanged += new System.EventHandler(this.txtSpriteSizeX_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 42);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(130, 291);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 42);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbHorizontal);
            this.groupBox3.Controls.Add(this.rbVertical);
            this.groupBox3.Location = new System.Drawing.Point(24, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 105);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Orientation:";
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Checked = true;
            this.rbHorizontal.Location = new System.Drawing.Point(9, 35);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(106, 24);
            this.rbHorizontal.TabIndex = 2;
            this.rbHorizontal.TabStop = true;
            this.rbHorizontal.Text = "Horizontal";
            this.rbHorizontal.UseVisualStyleBackColor = true;
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Location = new System.Drawing.Point(9, 65);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(85, 24);
            this.rbVertical.TabIndex = 3;
            this.rbVertical.TabStop = true;
            this.rbVertical.Text = "Vertical";
            this.rbVertical.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Default Sequence:";
            // 
            // txtSequenceName
            // 
            this.txtSequenceName.Location = new System.Drawing.Point(169, 242);
            this.txtSequenceName.Name = "txtSequenceName";
            this.txtSequenceName.Size = new System.Drawing.Size(155, 27);
            this.txtSequenceName.TabIndex = 10;
            // 
            // frmNewSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 345);
            this.Controls.Add(this.txtSequenceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewSheet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Sheet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtSheetSizeX;
        private GroupBox groupBox1;
        private Label label3;
        private Label label4;
        private TextBox txtSheetSizeY;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtSpriteSizeY;
        private Label label6;
        private TextBox txtSpriteSizeX;
        private Button btnCancel;
        private Button btnOK;
        private GroupBox groupBox3;
        private RadioButton rbHorizontal;
        private RadioButton rbVertical;
        private Label label1;
        private TextBox txtSequenceName;
    }
}