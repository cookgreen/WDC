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
using WDC.Localization;
using WDC.Locate;
using WDC.Script;

namespace WDC.Forms
{
	public partial class frmConfigure : Form
	{
		private localizedStringsLoader stringsLoader = new localizedStringsLoader("Localization/strings.xml");
		private string locate;
		public GameConfig Config { get; set; }

		public frmConfigure()
		{
			Config = GameConfig.Load("setting.xml");
            locate = Config.CurrentSelectedLocate;

            InitializeComponent();
			LoadAvaiableResolutions();
			cmbLanguages.SelectedItem = LocateTableManager.Instance.ConvertIDToDisplayStr(locate);
			cmbResolutionList.SelectedIndex = cmbResolutionList.Items.Count - 1;

            initLocalizedStrings();
		}

        private void initLocalizedStrings()
        {
			lbLanguage.Text = stringsLoader.FindText("str_language", locate);
			lbResolution.Text = stringsLoader.FindText("str_resolution", locate);
			tbScript.Text = stringsLoader.FindText("str_script", locate);
			tbGame.Text = stringsLoader.FindText("str_game", locate);
			gbScript.Text = stringsLoader.FindText("str_select_a_script", locate);
			btnOK.Text = stringsLoader.FindText("str_ok", locate);
			btnCancel.Text = stringsLoader.FindText("str_cancel", locate);
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
			Config.Save("setting.xml");

            DialogResult = DialogResult.OK;
			Hide();
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
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

        private void cmbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
			locate = LocateTableManager.Instance.ConvertDisplayStrToID(cmbLanguages.SelectedItem.ToString());
			initLocalizedStrings();
        }
    }
}
