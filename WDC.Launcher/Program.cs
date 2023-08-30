using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WDC.Forms;
using WDC.Script;

namespace WDC
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
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

            if (arugments.ContainsKey("script"))
            {
                string scriptName = arugments["script"];
            }

            frmConfigure configureForm = new frmConfigure();
            if (configureForm.ShowDialog() == DialogResult.OK)
            {
                int counter = 0;
                while (counter < 100)
                {
                    counter++;
                    System.Threading.Thread.Sleep(10);
                }
                frmRenderPanel mainWindow = new frmRenderPanel(configureForm.Config);
                Application.Run(mainWindow);
            }
        }
    }
}
