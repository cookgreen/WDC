using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Console;
using WDC.Core;
using WDC.Script;

namespace WDC.Forms
{
	public partial class frmDeveloperConsole : Form
	{
		private Engine engine;
		private WDCScript currentScript;

		public frmDeveloperConsole(Engine engine, WDCScript currentScript)
		{
			InitializeComponent();
			Deactivate += FrmDeveloperConsole_Deactivate;
			this.engine = engine;
			this.currentScript = currentScript;
		}

		public void Print(string str)
		{
			txtOutput.AppendText(str + Environment.NewLine);
		}

		private void FrmDeveloperConsole_Deactivate(object sender, EventArgs e)
		{
			Hide();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			Print("> " + txtInput.Text);
			string[] tokens = txtInput.Text.Split(' ');
			IConsoleCommand command = ConsoleCommandManager.Instance.GetConsoleCommand(tokens[0]);
			if (command != null)
			{
				command.Execute(engine, currentScript, this, tokens);
			}
			else
			{
				Print("Unknown command");
			}
			txtInput.Text = null;
		}
	}
}
