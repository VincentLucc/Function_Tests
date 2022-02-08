using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void ShowMainLoading(string sMessage)
        {
            var ParentForm = csPublic.formMain;
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, sMessage, "");
        }

        public static void CloseLoadingForm()
        {
            SplashScreenManager.CloseForm(false);
        }
    }
}
