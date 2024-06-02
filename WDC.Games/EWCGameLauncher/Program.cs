using System.Diagnostics;

namespace EWCGameLauncher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process.Start("WDC.Launcher.exe -Scripts EWCGameScript");
        }
    }
}