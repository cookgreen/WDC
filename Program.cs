using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (MessageBox.Show("We are warning you that this is not a game\r\n\r\nAre you sure continue?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
            {
                int counter = 0;
                while (counter < 100)
                {
                    counter++;
                    System.Threading.Thread.Sleep(10);
                }
                frmMain mainWindow = new frmMain();
                Application.Run(mainWindow);
            }
        }
    }
}
