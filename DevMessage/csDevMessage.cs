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

namespace DevMessage
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

        public IOverlaySplashScreenHandle ShowCustomOverLay(string sMessage)
        {
            var handle = SplashScreenManager.ShowOverlayForm(ParentForm, customPainter: new CustomOverlayPainter(sMessage));
            return handle;
        }
    }

    public class CustomOverlayPainter : OverlayWindowPainterBase
    {
        // Defines the string’s font.
        private Font drawFont;
        string sMessage;

        public CustomOverlayPainter(string sInput)
        {
            sMessage = sInput;
            drawFont = new Font("Tahoma", 18);
        }

        protected override void Draw(OverlayWindowCustomDrawContext context)
        {

            //Specify the string that will be drawn on the Overlay Form instead of the wait indicator.
            String drawString = sMessage;
            string sLongLine = LongestLine(drawString);

            //Get the system's black brush.
            Brush drawBrush = Brushes.Black;

            //Overlapped control bounds. 
            Rectangle bounds = context.DrawArgs.Bounds;

            //Provides access to the drawing surface. 
            GraphicsCache cache = context.DrawArgs.Cache;

            //Calculate the size of the message string.
            SizeF textSize = cache.CalcTextSize(sLongLine, drawFont);

            //A point that specifies the upper-left corner of the rectangle where the string will be drawn.
            PointF drawPoint = new PointF(
                bounds.Left + bounds.Width / 2 - textSize.Width / 2,
                bounds.Top + bounds.Height / 2 - textSize.Height / 2 + 80
                );
            //Draw the string on the screen.
            cache.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }

        private string LongestLine(string sInput)
        {

            var sParts = sMessage.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int iMaxIndex = 0;
            int iMaxCount = 0;

            for (int i = 0; i < sParts.Length; i++)
            {
                string sLine = sParts[i];

                if (sLine.Length == 0) continue;
                if (sLine.Length > iMaxCount)
                {
                    iMaxIndex = i;
                }
            }


            //Get result
            if (sParts != null && sParts.Length > 0)
            {
                return sParts[iMaxIndex];
            }
            else
            {
                return "";
            }

        }
    }
}
