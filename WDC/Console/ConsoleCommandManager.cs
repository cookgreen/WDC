using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Console
{
	public class ConsoleCommandManager
	{
		private Dictionary<string, IConsoleCommand> avaiableConsoleCommands;
		public Dictionary<string, IConsoleCommand> AvaiableConsoleCommands
		{
			get { return avaiableConsoleCommands; }
		}

		private static ConsoleCommandManager instance;
		public static ConsoleCommandManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ConsoleCommandManager();
				}
				return instance;
			}
		}

		public ConsoleCommandManager()
		{
			avaiableConsoleCommands = new Dictionary<string, IConsoleCommand>();
		}

		public void AddConsoleCommand(IConsoleCommand command)
		{
			avaiableConsoleCommands.Add(command.Name, command);
		}

		public IConsoleCommand GetConsoleCommand(string name)
		{
			if (avaiableConsoleCommands.ContainsKey(name))
			{
				return avaiableConsoleCommands[name];
			}
			return null;
		}
	}
}
