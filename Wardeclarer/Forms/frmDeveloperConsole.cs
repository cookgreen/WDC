using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wardeclarer.Forms
{
	public partial class frmDeveloperConsole : Form
	{
		public frmDeveloperConsole()
		{
			InitializeComponent();
			Deactivate += FrmDeveloperConsole_Deactivate;
		}

		private void FrmDeveloperConsole_Deactivate(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
