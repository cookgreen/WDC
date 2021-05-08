using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WDC.Console;

namespace WDC.Script
{
	public class ScriptManager
	{
		public Dictionary<string, WDCScript> scripts;
		private static ScriptManager instance;
		public static ScriptManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ScriptManager();
				}
				return instance;
			}
		}

		public ScriptManager()
		{
			scripts = new Dictionary<string, WDCScript>();
		}

		public void InitScripts()
		{
			string currentScriptFullPath = Path.Combine(Environment.CurrentDirectory, "Scripts");

			if (!Directory.Exists(currentScriptFullPath))
			{
				Directory.CreateDirectory(currentScriptFullPath);
			}

			DirectoryInfo di = new DirectoryInfo(currentScriptFullPath);
			var files = di.EnumerateFiles();
			foreach (var file in files)
			{
				if (file.Extension == ".dll")
				{
					Assembly assembly = Assembly.LoadFrom(file.FullName);
					var types = assembly.GetExportedTypes();
					foreach (var type in types)
					{
						var scriptType = type.GetInterface("WDCScript");
						if (scriptType != null)
						{
							WDCScript script = (WDCScript)Activator.CreateInstance(type);
							scripts.Add(Path.GetFileNameWithoutExtension(file.Name), script);
						}
					}
				}
			}
		}
	}
}
