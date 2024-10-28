namespace AIMeshGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAIMeshSizeHeight = new System.Windows.Forms.TextBox();
            this.txtAIMeshSizeWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartPosY = new System.Windows.Forms.TextBox();
            this.txtStartPosX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rowPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAIMeshSizeHeight);
            this.groupBox1.Controls.Add(this.txtAIMeshSizeWidth);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AIMeshSize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // txtAIMeshSizeHeight
            // 
            this.txtAIMeshSizeHeight.Location = new System.Drawing.Point(83, 59);
            this.txtAIMeshSizeHeight.Name = "txtAIMeshSizeHeight";
            this.txtAIMeshSizeHeight.Size = new System.Drawing.Size(249, 27);
            this.txtAIMeshSizeHeight.TabIndex = 1;
            this.txtAIMeshSizeHeight.Text = "0";
            this.txtAIMeshSizeHeight.TextChanged += new System.EventHandler(this.TextFixChanged);
            // 
            // txtAIMeshSizeWidth
            // 
            this.txtAIMeshSizeWidth.Location = new System.Drawing.Point(83, 26);
            this.txtAIMeshSizeWidth.Name = "txtAIMeshSizeWidth";
            this.txtAIMeshSizeWidth.Size = new System.Drawing.Size(249, 27);
            this.txtAIMeshSizeWidth.TabIndex = 0;
            this.txtAIMeshSizeWidth.Text = "0";
            this.txtAIMeshSizeWidth.TextChanged += new System.EventHandler(this.TextFixChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Rows:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(91, 217);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(253, 27);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.Text = "0";
            this.txtNumber.TextChanged += new System.EventHandler(this.txtRowNumber_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "X:";
            // 
            // txtStartPosY
            // 
            this.txtStartPosY.Location = new System.Drawing.Point(83, 59);
            this.txtStartPosY.Name = "txtStartPosY";
            this.txtStartPosY.Size = new System.Drawing.Size(48, 27);
            this.txtStartPosY.TabIndex = 5;
            this.txtStartPosY.Text = "0";
            this.txtStartPosY.TextChanged += new System.EventHandler(this.TextFixChanged);
            // 
            // txtStartPosX
            // 
            this.txtStartPosX.Location = new System.Drawing.Point(83, 26);
            this.txtStartPosX.Name = "txtStartPosX";
            this.txtStartPosX.Size = new System.Drawing.Size(48, 27);
            this.txtStartPosX.TabIndex = 4;
            this.txtStartPosX.Text = "0";
            this.txtStartPosX.TextChanged += new System.EventHandler(this.TextFixChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtStartPosY);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtStartPosX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 99);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "StartPosition";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(249, 384);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(124, 53);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rowPanel
            // 
            this.rowPanel.AutoScroll = true;
            this.rowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rowPanel.Location = new System.Drawing.Point(17, 253);
            this.rowPanel.Name = "rowPanel";
            this.rowPanel.Size = new System.Drawing.Size(356, 125);
            this.rowPanel.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 449);
            this.Controls.Add(this.rowPanel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Mesh Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtAIMeshSizeHeight;
        private TextBox txtAIMeshSizeWidth;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtNumber;
        private Label label4;
        private Label label5;
        private TextBox txtStartPosY;
        private TextBox txtStartPosX;
        private GroupBox groupBox2;
        private Button btnGenerate;
        private Panel rowPanel;
    }
}