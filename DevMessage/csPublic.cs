using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace DevMessage
{
    class csPublic
    {
        public static Form1 formMain;
    }

    public class UIHelper
    {
        /// <summary>
        /// Some cases the SplashScreenManager.ShowDefaultWaitForm() won't show message, use this wrapper to show message instead 
        /// </summary>
        /// <param name="sMessage"></param>
        public static void ShowMainLoading(string sMessage,string sCaptain="Loading...")
        {
            var ParentForm = csPublic.formMain;
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, sCaptain, sMessage);
        }

        public static void ShowMainLoading()
        {
            var ParentForm = csPublic.formMain;
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, "Loading...", "Please wait.");
        }

        public static void CloseLoadingForm()
        {
            SplashScreenManager.CloseForm(false);
        }

        public static void ShowInfo(string text, string caption)
        {
            XtraMessageBox.Show(text,caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowInfo2(string text, string caption)
        {
            XtraMessageBox.Show(csPublic.formMain, text, caption, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
