using DevExpress.XtraEditors.Frames;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Drawing.Imaging;

namespace OpenCV_Sharp4
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        public static string DefaultView = "DisplayPort";

        public int iRotate = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init window

            //var cbBox= (repositoryItemComboBox1)cbRotate.Edit;


            repositoryItemComboBox1.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(new List<int> { 0, 90, 180, 270 });
            cbRotate.EditValueChanged += RepositoryItemComboBox1_EditValueChanged;

        }

        private void RepositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            if (cbRotate.EditValue is int)
            {
                iRotate = (int)cbRotate.EditValue;
            }
        }

        private void bOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string sFile = dialog.FileName;
                    var imageRead = Cv2.ImRead(sFile, ImreadModes.AnyColor);


                    Mat imageRotate = RotateImage(imageRead, iRotate);

                    // mat 转 bitmap
                    Bitmap bitmap = BitmapConverter.ToBitmap(imageRotate);
                    pictureBox1.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }


        private Mat RotateImage(Mat sourceImage, int iDegree)
        {
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
                return sourceImage;
            }

            Mat outPut = sourceImage.Clone();
            Cv2.Rotate(sourceImage, outPut, rotateFlag);
            sourceImage.Dispose();
            return outPut;
        }

        private void bScreenShot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ScreenCaptureHelper
            try
            {
                var mainScreen = Screen.AllScreens.FirstOrDefault(a => a.Primary);
                var bounds = mainScreen.Bounds;
                Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }

 
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = bitmap;
                bitmap.Save("Test.jpg");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); ;
            }

        }
    }
}
