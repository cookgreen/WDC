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
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ScriptManager.Instance.InitScripts();
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
