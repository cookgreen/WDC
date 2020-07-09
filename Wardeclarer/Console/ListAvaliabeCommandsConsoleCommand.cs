using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Core;
using Wardeclarer.Forms;
using Wardeclarer.Script;

namespace Wardeclarer.Console
{
	public class ListAvaliabeCommandsConsoleCommand : IConsoleCommand
	{
		public string Name
		{
			get { return "list"; }
		}

		public void Execute(Engine engine, WDCScript currentScript, frmDeveloperConsole console, object arg)
		{
			foreach (var kpl in ConsoleCommandManager.Instance.AvaiableConsoleCommands)
			{
				console.Print(kpl.Key);
			}
		}
	}
}
