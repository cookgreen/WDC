using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Configure;
using Wardeclarer.Locate;
using Wardeclarer.Script;

namespace Wardeclarer.Forms
{
	public partial class frmConfigure : Form
	{
		public GameConfig Config { get; set; }

		public frmConfigure()
		{
			InitializeComponent();
			cmbLanguages.SelectedIndex = 0;
		}

		private void frmScriptSelector_Load(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			for (int i = 0; i < ScriptManager.Instance.scripts.Count; i++)
			{
				listBox1.Items.Add(ScriptManager.Instance.scripts.ElementAt(i).Key);
			}
			if (listBox1.Items.Count > 0)
			{
				listBox1.SelectedIndex = 0;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1)
			{
				WDCScript selectedScript = ScriptManager.Instance.scripts[listBox1.SelectedItem.ToString()];

				Config = new GameConfig();
				Config.currentSelectedScript = selectedScript;
				Config.currentSelectedLocate = LocateTableManager.Instance.ConvertDisplayStrToID(cmbLanguages.SelectedItem.ToString());

				DialogResult = DialogResult.OK;
				Hide();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
