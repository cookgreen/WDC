using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Console;
using WDC.Core;
using WDC.Forms;
using WDC.Script;

namespace GarbageClassificationScript.Console
{
	public class EnableCheatConsoleCommand : IConsoleCommand
	{
		public string Name { get { return "enable_cheat"; } }

		public void Execute(Engine engine, WDCScript script, frmDeveloperConsole consoleForm, object arg)
		{
			string[] arr = arg as string[];
			if (arr.Count() == 1)
			{
				consoleForm.Print("Invalid Parameters");
				return;
			}

			int mode = int.Parse(arr[1].ToString());
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
