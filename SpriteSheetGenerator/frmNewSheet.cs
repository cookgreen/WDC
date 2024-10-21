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
    public partial class frmNewSheet : Form
    {
        private SpriteSheetConfig sheetConfig;
        public SpriteSheetConfig SheetConfig { get { return sheetConfig; } }
        public string DefaultSequenceName { get { return txtSequenceName.Text; } }

        public frmNewSheet()
        {
            InitializeComponent();
        }

        private void txtSheetSizeX_TextChanged(object sender, EventArgs e)
        {
            int _;
            if(!int.TryParse(txtSheetSizeX.Text, out _))
            {
                txtSheetSizeX.Text = "0";
            }
        }

        private void txtSheetSizeY_TextChanged(object sender, EventArgs e)
        {
            int _;
            if (!int.TryParse(txtSheetSizeY.Text, out _))
            {
                txtSheetSizeY.Text = "0";
            }
        }

        private void txtSpriteSizeX_TextChanged(object sender, EventArgs e)
        {
            int _;
            if (!int.TryParse(txtSpriteSizeX.Text, out _))
            {
                txtSpriteSizeX.Text = "0";
            }
        }

        private void txtSpriteSizeY_TextChanged(object sender, EventArgs e)
        {
            int _;
            if (!int.TryParse(txtSpriteSizeY.Text, out _))
            {
                txtSpriteSizeY.Text = "0";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtSpriteSizeX.Text == "0" || txtSpriteSizeY.Text == "0")
            {
                MessageBox.Show("Please input a valid sprite size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtSequenceName.Text))
            {
                MessageBox.Show("Please input a valid sequence name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Size size1 = new Size(int.Parse(txtSheetSizeX.Text), int.Parse(txtSheetSizeY.Text));
            Size size2 = new Size(int.Parse(txtSpriteSizeX.Text), int.Parse(txtSpriteSizeY.Text));
            SpriteSheetOrientation orientation;
            if(rbHorizontal.Checked)
            {
                orientation = SpriteSheetOrientation.Horizontal;
            }
            else
            {
                orientation = SpriteSheetOrientation.Vertical;
            }
            sheetConfig = new SpriteSheetConfig(orientation, size2);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
