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
	public interface IConsoleCommand
	{
		string Name { get; }

		void Execute(Engine engine, WDCScript currentScript, frmDeveloperConsole console, object arg);
	}
}
