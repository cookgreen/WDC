using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Core;
using WDC.Forms;
using WDC.Script;

namespace WDC.Console
{
	public class ListAvaliabeCommandsConsoleCommand : IConsoleCommand
	{
		public string Name
		{
			get { return "list"; }
		}

		public void Execute(Engine engine, WDCScript currentScript, DeveloperConsoleForm console, object arg)
		{
			foreach (var kpl in ConsoleCommandManager.Instance.AvaiableConsoleCommands)
			{
				console.Print(kpl.Key);
			}
		}
	}
}
