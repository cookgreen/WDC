using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using WDC.Xml;

namespace SpriteSheetGenerator
{
    public partial class frmSaveSpriteDialog : Form
    {
        private SpriteSheetConfig sheetConfig;
        private Dictionary<string, Tuple<int, bool, ImageList.ImageCollection>> sequences;

        public frmSaveSpriteDialog(SpriteSheetConfig sheetConfig, Dictionary<string, Tuple<int, bool, ImageList.ImageCollection>> sequences)
        {
            InitializeComponent();
            this.sheetConfig = sheetConfig;
            this.sequences = sequences;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSpriteName.Text))
            {
                MessageBox.Show("Plase input a valid sprite name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                MessageBox.Show("Plase input a valid save path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int width = 0;
            int height = 0;
            
            int countMax = 0;
            foreach(var pair in sequences)
            {
                if(countMax < pair.Value.Item3.Count)
                {
                    countMax = pair.Value.Item3.Count;
                }
            }
            
            switch (sheetConfig.Orientation)
            {
                
                case SpriteSheetOrientation.Horizontal:
                    width = sheetConfig.SpriteSize.Width * countMax;
                    height = sheetConfig.SpriteSize.Height * sequences.Count;
                    break;
                case SpriteSheetOrientation.Vertical:
                    width = sheetConfig.SpriteSize.Width * sequences.Count;
                    height = sheetConfig.SpriteSize.Height * countMax;
                    break;
            }
            Bitmap bitmap = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(bitmap);

            AnimatedSpriteInfoList animatedSpriteInfoList = new AnimatedSpriteInfoList();
            AnimatedSpriteInfo animatedSpriteInfo = new AnimatedSpriteInfo();
            animatedSpriteInfo.Name = txtSpriteName.Text;

            int index = 0;
            foreach (var pair in sequences)
            {
                AnimatedSpriteSequence sequence = new AnimatedSpriteSequence();
                sequence.Name = pair.Key;
                sequence.Start = pair.Value.Item1;
                sequence.Loop = pair.Value.Item2;
                sequence.Length = pair.Value.Item3.Count;


                Point point;
                switch (sheetConfig.Orientation)
                {
                    case SpriteSheetOrientation.Horizontal:
                        point = new Point(0, index * sheetConfig.SpriteSize.Height);
                        break;
                    case SpriteSheetOrientation.Vertical:
                        point = new Point(index * sheetConfig.SpriteSize.Width, 0);
                        break;
                    default:
                        point = new Point(0, 0);
                        break;
                }

                foreach (Image image in pair.Value.Item3)
                {
                    AnimatedSpriteSequenceRegion region = new AnimatedSpriteSequenceRegion();
                    region.Width = sheetConfig.SpriteSize.Width;
                    region.Height = sheetConfig.SpriteSize.Height;
                    region.OffsetX = point.X;
                    region.OffsetY = point.Y;

                    graphics.DrawImage(
                        image, point.X, point.Y,
                        sheetConfig.SpriteSize.Width,
                        sheetConfig.SpriteSize.Height);

                    switch (sheetConfig.Orientation)
                    {
                        case SpriteSheetOrientation.Horizontal:
                            point = new Point(point.X + sheetConfig.SpriteSize.Width, point.Y);
                            break;
                        case SpriteSheetOrientation.Vertical:
                            point = new Point(point.X, point.Y + sheetConfig.SpriteSize.Height);
                            break;
                    }

                    sequence.Regions.Add(region);
                    index++;
                }
                animatedSpriteInfo.AnimatedSpriteSequences.Add(sequence);
            }
            animatedSpriteInfoList.AnimatedSprites.Add(animatedSpriteInfo);

            graphics.Flush();
            graphics.Dispose();

            animatedSpriteInfoList.Save(Path.Combine(txtSavePath.Text, txtSpriteName.Text + ".xml"));
            bitmap.Save(Path.Combine(txtSavePath.Text, txtSpriteName.Text + ".png"));
            bitmap.Dispose();

            MessageBox.Show("Finished!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = dialog.SelectedPath;
            }
        }
    }
}
