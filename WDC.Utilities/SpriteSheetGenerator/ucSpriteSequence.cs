using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetGenerator
{
    public partial class ucSpriteSequence : UserControl
    {
        public int Start { get { return int.Parse(txtSequenceStart.Text); } }
        public bool IsLoop { get { return chkIsLoop.Checked; } }
        public ImageList.ImageCollection Images { get { return imageList.Images; } }

        public ucSpriteSequence()
        {
            InitializeComponent();
        }

        private void btnSpriteAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image File|*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = "sprite - " + imageList.Images.Count.ToString();
                string key = Guid.NewGuid().ToString();
                ListViewItem item = new ListViewItem();
                item.Text = name;
                imageList.Images.Add(key, new Bitmap(dialog.FileName));
                item.ImageKey = key;
                spriteList.Items.Add(item);
            }
        }

        private void btnSpriteDelete_Click(object sender, EventArgs e)
        {
            if (spriteList.SelectedIndices.Count > 0)
            {
                int index = spriteList.SelectedIndices[0];
                spriteList.Items.RemoveAt(index);
                imageList.Images.RemoveAt(index);
            }
        }

        private void txtSequenceStart_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSequenceStart.Text, out _))
            {
                txtSequenceStart.Text = "0";
            }
        }
    }
}
