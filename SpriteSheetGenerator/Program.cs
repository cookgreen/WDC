namespace SpriteSheetGenerator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            frmNewSheet newSheetWin = new frmNewSheet();
            if(newSheetWin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain(newSheetWin.SheetConfig, newSheetWin.DefaultSequenceName));
            }
        }
    }
}