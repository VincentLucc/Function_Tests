using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DllImportHelper
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

#if DEBUG
            Application.Run(new MainForm()); // Run with window
#else
            var form = new MainForm();
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Minimized;
            form.Show(); // Can remove to hide completely
            Application.Run(); // Run without window
#endif

        }
    }
}
