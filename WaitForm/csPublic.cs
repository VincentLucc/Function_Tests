using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitForm
{
    class csPublic
    {
        public static Form1 winMain { get; set; }
    }

    public class UIHelper
    {
        /// <summary>
        /// Some cases the SplashScreenManager.ShowDefaultWaitForm() won't show message, use this wrapper to show message instead 
        /// </summary>
        /// <param name="sMessage"></param>
        public static void ShowMainLoading(string sMessage)
        {
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(csPublic.winMain, true, false, sMessage, "");
        }

        public static void ShowSplash()
        {
            SplashScreenManager.ShowDefaultSplashScreen(csPublic.winMain, false, false, "Test", "123");
        }

        public static void CloseForm()
        {
            SplashScreenManager.CloseForm(false);
        }

        public static IOverlaySplashScreenHandle ShowCustomOverLay(string sMessage)
        {
            var handle = SplashScreenManager.ShowOverlayForm(csPublic.winMain, customPainter: new CustomOverlayPainter(sMessage));
            return handle;
        }


        public static void CloseOverLayForm(IOverlaySplashScreenHandle overlayHandle)
        {
            SplashScreenManager.CloseOverlayForm(overlayHandle);
        }


    }


    class CustomOverlayPainter : OverlayWindowPainterBase
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
                if (sLine.Length> iMaxCount)
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
