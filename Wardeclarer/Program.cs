using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wardeclarer.Forms;
using Wardeclarer.Script;

namespace Wardeclarer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ScriptManager.Instance.InitScripts();
            frmScriptSelector scriptSelector = new frmScriptSelector();
            if (scriptSelector.ShowDialog() == DialogResult.OK)
            {
                int counter = 0;
                while (counter < 100)
                {
                    counter++;
                    System.Threading.Thread.Sleep(10);
                }
                frmRenderPanel mainWindow = new frmRenderPanel(scriptSelector.SelectedScript);
                Application.Run(mainWindow);
            }
        }
    }
}
