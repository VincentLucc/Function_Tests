using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Sharp4
{
    public class cvWindow
    {

        public PictureBox DisplayWindow;

        public Mat viewImage;

        public int iRotate;

        public cvWindow(PictureBox pictureBox)
        {
            DisplayWindow = pictureBox;
        }

        public Mat OpenImage(out string sMessage)
        {
            sMessage = null;

            try
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string sFile = dialog.FileName;
                    var imageRead = Cv2.ImRead(sFile, ImreadModes.AnyColor);
                    SetViewImage(imageRead);
                    return imageRead;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
                Debug.WriteLine("OpenImage.Exception\r\n" + ex.Message);
                return null;
            }
        }

        public Mat RotateImage(Mat input, int iDegree)
        {
            try
            {
                if (input == null) return null;
                
                RotateFlags rotateFlag;
                if (iDegree == 90)
                {
                    rotateFlag = RotateFlags.Rotate90Clockwise;
                }
                else if (iDegree == 180)
                {
                    rotateFlag = RotateFlags.Rotate180;
                }
                else if (iDegree == 270)
                {
                    rotateFlag = RotateFlags.Rotate90Counterclockwise;
                }
                else
                {
                    return input.Clone();
                }
                var output = input.EmptyClone();
                Cv2.Rotate(input, output, rotateFlag);
                return output;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("RotateImage.Exception:\r\b" + ex.Message);
                return null;
            }
        }

        public void DisplayImage(Mat input)
        {
            try
            {
                if (input == null) return;
                // mat 转 bitmap
                Bitmap bitmap = BitmapConverter.ToBitmap(input);
                DisplayWindow.Image = bitmap;
                SetViewImage(input);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DisplayImage.Exception:\r\n" + ex.Message);
            }

        }

        private  void SetViewImage(Mat inputImage)
        {
            if (inputImage == null) return;
            
            if (viewImage != null)
            {
                viewImage.Dispose();
                viewImage = null;
            }
            viewImage = inputImage.Clone();
        }
    }
}
