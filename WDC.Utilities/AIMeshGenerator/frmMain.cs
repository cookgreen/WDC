namespace AIMeshGenerator
{
    public partial class frmMain : Form
    {
        private List<TextBox> textBoxes;

        public frmMain()
        {
            InitializeComponent();
            textBoxes = new List<TextBox>();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML File|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                GameAIMesh gameAIMesh = new GameAIMesh();
                Point startPos = new Point(int.Parse(txtStartPosX.Text), int.Parse(txtStartPosY.Text));
                Size aimeshSize = new Size(int.Parse(txtAIMeshSizeWidth.Text), int.Parse(txtAIMeshSizeHeight.Text));
                int number = int.Parse(txtNumber.Text);

                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < int.Parse(textBoxes[i].Text); j++)
                    {
                        GameAIMeshBlock block = new GameAIMeshBlock();
                        block.size = string.Format("{0}, {1}", txtAIMeshSizeWidth.Text, txtAIMeshSizeHeight.Text);
                        block.location = string.Format("{0}, {1}", 
                            startPos.X + aimeshSize.Width * j, 
                            startPos.Y + aimeshSize.Height * i);
                        gameAIMesh.AIMeshList.Add(block);
                    }
                }

                gameAIMesh.Save(dialog.FileName);
            }
        }

        private void TextFixChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(!int.TryParse(textBox.Text, out _))
            {
                textBox.Text = "0";
            }
        }

        private void txtRowNumber_TextChanged(object sender, EventArgs e)
        {
            int rowNum;
            if (int.TryParse(txtNumber.Text, out rowNum))
            {
                generateRows(rowNum);
            }
        }

        private void generateRows(int rowNum)
        {
            Point startPos = new Point(19, 20);
            Point startPos2 = new Point(98, 20);
            Point startPos3 = new Point(147, 17);

            Size textSize = new Size(178, 27);

            textBoxes.Clear();
            rowPanel.Controls.Clear();
            if (rowNum <= 0)
            {
                return;
            }

            for (int i = 0; i < rowNum; i++)
            {
                Label label = new Label();
                label.Text = "Row #" + (i + 1).ToString() + " - ";
                label.AutoSize = true;
                label.Location = startPos;
                rowPanel.Controls.Add(label);

                Label label2 = new Label();
                label2.Text = "Num:";
                label2.AutoSize = true;
                label2.Location = startPos2;
                rowPanel.Controls.Add(label2);

                TextBox textBox = new TextBox();
                textBox.Location = startPos3;
                textBox.Size = textSize;
                textBox.Text = "0";
                textBox.TextChanged += TextFixChanged;
                rowPanel.Controls.Add(textBox);
                textBoxes.Add(textBox);

                startPos = new Point(startPos.X, 20 + ((textSize.Height + 10) * (i + 1)));
                startPos2 = new Point(startPos2.X, 20 + (textSize.Height + 10) * (i + 1));
                startPos3 = new Point(startPos3.X, 17 + (textSize.Height + 10) * (i + 1));
            }
        }
    }
}