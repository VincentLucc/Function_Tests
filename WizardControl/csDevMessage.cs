using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardControl
{
    public class csDevMessage
    {
        public Form ParentForm;

        public csDevMessage(Form _parentForm)
        {
            ParentForm = _parentForm;
        }

        /// <summary>
        /// Some cases the SplashScreenManager.ShowDefaultWaitForm() won't show message, use this wrapper to show message instead 
        /// </summary>
        /// <param name="sMessage"></param>
        public void ShowMainLoading(string sCaptain = null, string sDescription = null)
        {
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, sCaptain, sDescription);
        }

        public void ShowMainLoading()
        {
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, "Loading...", "Please wait.");
        }
        public void CloseLoadingForm()
        {
            SplashScreenManager.CloseForm(false);
        }


        public void Error(string text, string caption = "Error")
        {
            XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ErrorConfirmOK(string text, string caption = "Error")
        {
            return XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public DialogResult ErrorConfirmYes(string text, string caption = "Error")
        {
            return XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        public DialogResult ErrorConfirmOK(string text)
        {
            return XtraMessageBox.Show(ParentForm, text, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public void Warning(string text, string caption = "Warning")
        {
            XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult WarningConfirmOK(string text, string caption = "Warning")
        {
            return XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public void Info(string text, string caption = "Info")
        {
            XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public DialogResult InfoConfirmOK(string text, string caption = "Info")
        {
            return XtraMessageBox.Show(ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
 
    }
}
