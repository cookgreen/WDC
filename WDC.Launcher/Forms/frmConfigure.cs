using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Configure;
using WDC.Locate;
using WDC.Script;

namespace WDC.Forms
{
	public partial class frmConfigure : Form
	{
		public GameConfig Config { get; set; }

		public frmConfigure()
		{
			InitializeComponent();
			LoadAvaiableResolutions();
			cmbLanguages.SelectedIndex = 0;
			cmbResolutionList.SelectedIndex = cmbResolutionList.Items.Count - 1;
		}

        private void LoadAvaiableResolutions()
        {
			var deviceResolutionWidth = Screen.PrimaryScreen.Bounds.Width;
			var deviceResolutionHeight = Screen.PrimaryScreen.Bounds.Height;

			for (int i = cmbResolutionList.Items.Count - 1; i > 0; i--)
			{
				string resolutionstr = cmbResolutionList.Items[i].ToString();
				string[] tokens = resolutionstr.Split('x');
				string currentWidth = tokens[0];
				string currentHeight = tokens[1];
				if ((int.Parse(currentWidth) > deviceResolutionWidth &&
					int.Parse(currentHeight) > deviceResolutionHeight) ||
					int.Parse(currentWidth) == deviceResolutionWidth &&
					int.Parse(currentHeight) == deviceResolutionHeight)
				{
					cmbResolutionList.Items.RemoveAt(i);
				}
			}
			cmbResolutionList.Items.Add(
				deviceResolutionWidth.ToString() +
				"x" + 
				deviceResolutionHeight.ToString());

		}

        private void frmScriptSelector_Load(object sender, EventArgs e)
		{
			scriptList.Items.Clear();
			for (int i = 0; i < ScriptManager.Instance.scripts.Count; i++)
			{
				scriptList.Items.Add(ScriptManager.Instance.scripts.ElementAt(i).Key);
			}
			if (scriptList.Items.Count > 0)
			{
				scriptList.SelectedIndex = 0;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (scriptList.SelectedItem == null)
			{
				MessageBox.Show("Please choose a avaiable script to launch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (cmbLanguages.SelectedItem == null)
			{
				MessageBox.Show("Please choose a avaiable language to launch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else if (cmbResolutionList.SelectedItem == null)
			{
				MessageBox.Show("Please choose a avaiable reolution to launch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			WDCScript selectedScript = ScriptManager.Instance.scripts[scriptList.SelectedItem.ToString()];

			Config = new GameConfig();
			Config.CurrentSelectedScript = selectedScript;
			Config.CurrentSelectedLocate = LocateTableManager.Instance.ConvertDisplayStrToID(cmbLanguages.SelectedItem.ToString());
			Config.Resolution = cmbResolutionList.SelectedItem.ToString();

			DialogResult = DialogResult.OK;
			Hide();
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < scriptList.Items.Count; i++)
			{
				scriptList.SetItemChecked(i, false);
			}
			if (scriptList.SelectedIndex != -1)
			{
				scriptList.SetItemChecked(scriptList.SelectedIndex, true);
			}
		}
	}
}
