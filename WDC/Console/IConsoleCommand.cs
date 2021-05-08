using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Forms;
using WDC.Script;

namespace WDC.Console
{
	public interface IConsoleCommand
	{
		string Name { get; }

		void Execute(Engine engine, WDCScript currentScript, frmDeveloperConsole console, object arg);
	}
}
