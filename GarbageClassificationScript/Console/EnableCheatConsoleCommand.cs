using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Console;
using Wardeclarer.Core;
using Wardeclarer.Forms;
using Wardeclarer.Script;

namespace GarbageClassificationScript.Console
{
	public class EnableCheatConsoleCommand : IConsoleCommand
	{
		public string Name { get { return "enable_cheat"; } }

		public void Execute(Engine engine, WDCScript script, frmDeveloperConsole consoleForm, object arg)
		{
			int mode = int.Parse((arg as string[])[1].ToString());
			if (mode == 0)
			{
				engine.DisableCheat();
				consoleForm.Print("Cheat Disabled!");
			}
			else if (mode == 1)
			{
				engine.EnableCheat();
				consoleForm.Print("Cheat Enabled!");
			}
		}
	}
}
