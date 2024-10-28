namespace SpriteSheetGenerator
{
    partial class ucSpriteSequence
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSpriteAdd = new System.Windows.Forms.Button();
            this.btnSpriteDelete = new System.Windows.Forms.Button();
            this.spriteList = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsLoop = new System.Windows.Forms.CheckBox();
            this.txtSequenceStart = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.spriteList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 477);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSpriteAdd);
            this.panel1.Controls.Add(this.btnSpriteDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 371);
            this.panel1.TabIndex = 0;
            // 
            // btnSpriteAdd
            // 
            this.btnSpriteAdd.Location = new System.Drawing.Point(7, 5);
            this.btnSpriteAdd.Name = "btnSpriteAdd";
            this.btnSpriteAdd.Size = new System.Drawing.Size(100, 100);
            this.btnSpriteAdd.TabIndex = 3;
            this.btnSpriteAdd.Text = "+";
            this.btnSpriteAdd.UseVisualStyleBackColor = true;
            this.btnSpriteAdd.Click += new System.EventHandler(this.btnSpriteAdd_Click);
            // 
            // btnSpriteDelete
            // 
            this.btnSpriteDelete.Location = new System.Drawing.Point(7, 124);
            this.btnSpriteDelete.Name = "btnSpriteDelete";
            this.btnSpriteDelete.Size = new System.Drawing.Size(100, 100);
            this.btnSpriteDelete.TabIndex = 4;
            this.btnSpriteDelete.Text = "-";
            this.btnSpriteDelete.UseVisualStyleBackColor = true;
            this.btnSpriteDelete.Click += new System.EventHandler(this.btnSpriteDelete_Click);
            // 
            // spriteList
            // 
            this.spriteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteList.LargeImageList = this.imageList;
            this.spriteList.Location = new System.Drawing.Point(123, 3);
            this.spriteList.MultiSelect = false;
            this.spriteList.Name = "spriteList";
            this.spriteList.Size = new System.Drawing.Size(342, 371);
            this.spriteList.TabIndex = 1;
            this.spriteList.UseCompatibleStateImageBehavior = false;
            this.spriteList.View = System.Windows.Forms.View.Tile;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 94);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start:";
            // 
            // chkIsLoop
            // 
            this.chkIsLoop.AutoSize = true;
            this.chkIsLoop.Checked = true;
            this.chkIsLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsLoop.Location = new System.Drawing.Point(63, 64);
            this.chkIsLoop.Name = "chkIsLoop";
            this.chkIsLoop.Size = new System.Drawing.Size(69, 24);
            this.chkIsLoop.TabIndex = 1;
            this.chkIsLoop.Text = "Loop";
            this.chkIsLoop.UseVisualStyleBackColor = true;
            // 
            // txtSequenceStart
            // 
            this.txtSequenceStart.Location = new System.Drawing.Point(63, 26);
            this.txtSequenceStart.Name = "txtSequenceStart";
            this.txtSequenceStart.Size = new System.Drawing.Size(261, 27);
            this.txtSequenceStart.TabIndex = 2;
            this.txtSequenceStart.Text = "0";
            this.txtSequenceStart.TextChanged += new System.EventHandler(this.txtSequenceStart_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSequenceStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkIsLoop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting:";
            // 
            // ucSpriteSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucSpriteSequence";
            this.Size = new System.Drawing.Size(468, 477);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnSpriteAdd;
        private Button btnSpriteDelete;
        private ListView spriteList;
        private ImageList imageList;
        private Panel panel2;
        private Label label1;
        private TextBox txtSequenceStart;
        private CheckBox chkIsLoop;
        private GroupBox groupBox1;
    }
}
