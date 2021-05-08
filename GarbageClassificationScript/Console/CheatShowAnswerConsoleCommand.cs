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
	public class CheatShowAnswerConsoleCommand : IConsoleCommand
	{
		public string Name { get { return "cheat_show_answer"; } }

		public void Execute(Engine engine, WDCScript currentScript, frmDeveloperConsole console, object arg)
		{
			if (engine.CheatEnabled && currentScript is GarbageClassificationScript)
			{
				string[] arr = arg as string[];
				if (arr.Count() == 1)
				{
					console.Print("Invalid Parameters");
					return;
				}

				int mode = int.Parse(arr[1].ToString());
				if (mode == 0)
				{
					(currentScript as GarbageClassificationScript).HideCurrentAnswer();
				}
				else if (mode == 1)
				{
					(currentScript as GarbageClassificationScript).ShowCurrentAnswer();
				}
				console.Print("Done");
			}
			else
			{
				console.Print("You need to enable cheat mode first!");
			}
		}
	}
}
