using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Configure;
using WDC.Forms;
using WDC.Script;

namespace WDC
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GameConfig config = null;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			ScriptManager.Instance.InitScripts();

			Dictionary<string, string> arugments = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    arugments[args[i].Substring(1)] = args[i + 1];
                }
            }

            bool isStartConfigureWin = false;
            if (arugments.ContainsKey("script"))
            {
                string scriptName = arugments["script"];
                if(ScriptManager.Instance.scripts.ContainsKey(scriptName))
                {
                    config = GameConfig.Load("setting.xml");
                    config.CurrentSelectedScript = ScriptManager.Instance.scripts[scriptName];
                }
                else
                {
                    isStartConfigureWin = true;
                }
            }
            else
            {
                isStartConfigureWin = true;
            }

            if (isStartConfigureWin)
            {
                frmConfigure configureForm = new frmConfigure();
                if (configureForm.ShowDialog() == DialogResult.OK)
                {
                    config = configureForm.Config;
                }
            }

            if (config != null)
            {
                frmRenderPanel mainWindow = new frmRenderPanel(config);
                Application.Run(mainWindow);
            }
        }
    }
}
