using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTests
{


    public class csDevMessage
    {
        public Form ParentForm;

        public UserLookAndFeel lookAndFeel;

        /// <summary>
        /// Indicate whether message box exist in current folder
        /// </summary>
        public bool IsMessageBoxExist { get; set; }

        public IOverlaySplashScreenHandle OverlayHandle;

        public csDevMessage(Form _parentForm)
        {
            ParentForm = _parentForm;
            lookAndFeel = UserLookAndFeel.Default;
        }

        public csDevMessage(XtraForm _parentForm)
        {
            ParentForm = _parentForm;
            lookAndFeel = _parentForm.LookAndFeel;
        }

        public csDevMessage(Form _parentForm, UserLookAndFeel _lookAndFeel)
        {
            ParentForm = _parentForm;
            lookAndFeel = _lookAndFeel;
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

        /// <summary>
        /// Splash screen or wait form
        /// </summary>
        public void CloseSplashForm()
        {
            SplashScreenManager.CloseForm(false);
        }

        /// <summary>
        /// Custom overlay form
        /// </summary>
        public void CloseOverlayForm()
        {
            if (OverlayHandle == null) return;
            SplashScreenManager.CloseOverlayForm(OverlayHandle);
        }

        public void CloseForm()
        {
            CloseSplashForm();
            CloseOverlayForm();
        }

        public void Error(string text, string caption = "Error")
        {
            CloseForm();
            IsMessageBoxExist = true;
            XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            IsMessageBoxExist = false;
        }

        public DialogResult ErrorConfirmOK(string text, string caption = "Error")
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            IsMessageBoxExist = false;
            return result;
        }

        public DialogResult ErrorConfirmYes(string text, string caption = "Error")
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            IsMessageBoxExist = false;
            return result;
        }

        public DialogResult ErrorConfirmOK(string text)
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            IsMessageBoxExist = false;
            return result;
        }

        public void Warning(string text, string caption = "Warning")
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            IsMessageBoxExist = false;
        }

        public DialogResult WarningConfirmOK(string text, string caption = "Warning")
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            IsMessageBoxExist = false;
            return result;
        }

        public void Info(string text, string caption = "Info")
        {
            CloseForm();
            IsMessageBoxExist = true;
            XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsMessageBoxExist = false;
        }

        /// <summary>
        /// Show message only once and won't affect current loop
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        public void InfoAsyncNoRepeat(string text, string caption = "Info")
        {

            if (IsMessageBoxExist) return;

            Task.Run(() =>
            {
                ParentForm.Invoke(new Action(() =>
                {
                    CloseForm();
                    IsMessageBoxExist = true;
                    XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsMessageBoxExist = false;
                }));
            });
        }


        /// <summary>
        /// Show message only once and won't affect current loop
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        public void ErrorAsyncNoRepeat(string text, string caption = "Error")
        {

            if (IsMessageBoxExist) return;

            Task.Run(() =>
            {
                ParentForm.Invoke(new Action(() =>
                {
                    CloseForm();
                    IsMessageBoxExist = true;
                    XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsMessageBoxExist = false;
                }));
            });
        }


        public DialogResult InfoConfirmOK(string text, string caption = "Info")
        {
            CloseForm();
            IsMessageBoxExist = true;
            var result = XtraMessageBox.Show(lookAndFeel, ParentForm, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            IsMessageBoxExist = false;
            return result;
        }



    }
}
