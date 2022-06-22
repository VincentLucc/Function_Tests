using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launch
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

            //Init variables
            csPublic.winMain = new Form1();
            csPublic.messageHelper = new MessageHelper(csPublic.winMain);

            var task = DosthAsync();

            //Wait for process to finish
            while (!task.IsCompleted)
            {
                Thread.Sleep(20);
                Application.DoEvents();
            }

            if (task.Result)
            {
                Application.Run(csPublic.winMain); //Start app
            }
            else
            {
                Application.Exit();
            }
        }


        private static async Task<bool> DosthAsync()
        {
            //Init variables
            csPublic.messageHelper.Info("SomeThing");
            csPublic.messageHelper.ShowMainLoading("Loading");

            await Task.Delay(3000);
            csPublic.messageHelper.CloseLoadingForm();

            //Pass all steps
            return true;
        }


    }
}
