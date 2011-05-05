using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ToolSet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
            Thread.Sleep(2000);
            Application.Run(new ToolSetManager());
        }
    }
}
