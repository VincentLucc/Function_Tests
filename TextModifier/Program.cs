using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TextModifier
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 命名的 Mutex 是机器范围的，它的名称需要是唯一的
            string sID = "TextModifier";
            using (Mutex uniqueMutex = new Mutex(false, sID))
            {
                //Try lock
                if (uniqueMutex.WaitOne(1000))
                {
                    MessageBox.Show("Another app instance is running.");
                    return;
                }

                //Run inside the lock, mutex still exist
                Application.Run(new FormMain());
                //Unlock or auto unlock after "using"
                uniqueMutex.ReleaseMutex();
            }

         
        }
    }
}
