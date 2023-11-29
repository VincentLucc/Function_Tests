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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public static string DefaultView = "DisplayPort";

        public cvWindow cvWidnow;

        public csDevMessage messageHelper;

        public FormMain()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Load configuration
            if (!csConfigureHelper.SaveConfig(out string sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init variables
            messageHelper = new csDevMessage(this);
            cvWidnow = new cvWindow(pictureBox1);

            //Load configuration
            if (!csConfigureHelper.LoadOrCreateConfig(out string sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }

            //var cbBox= (repositoryItemComboBox1)cbRotate.Edit;
            repositoryItemComboBox1.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(new List<int> { 0, 90, 180, 270 });
            cbRotate.EditValueChanged += RepositoryItemComboBox1_EditValueChanged;
            cbRotate.EditValue = csConfigureHelper.Inspection.Rotate;

        }

        private void RepositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            if (cbRotate.EditValue is int)
            {
                csConfigureHelper.Inspection.Rotate = (int)cbRotate.EditValue;
                var imageRotate = cvWidnow.RotateImage(csConfigureHelper.Inspection.sourceImage, csConfigureHelper.Inspection.Rotate);
                cvWidnow.DisplayImage(imageRotate);
            }
        }

        private void bOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenImageAction();
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

 
        private void OpenBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenImageAction();
        }

        private void OpenImageAction()
        {
            string sMesage = "";
            try
            {
                var image = cvWidnow.OpenImage(out sMesage);
                if (image == null)
                {
                    if (sMesage != null) messageHelper.Info(sMesage);
                    return;
                }

                //Save source image
                messageHelper.ShowMainLoading();
                csConfigureHelper.Inspection.SetSourceImage(image);

                //Rotate image
                messageHelper.ShowMainLoading("Rotate Image...");
                var imageRotate = cvWidnow.RotateImage(image, csConfigureHelper.Inspection.Rotate);

                //Runs operations
                messageHelper.ShowMainLoading("Process Image...");
                csConfigureHelper.Inspection.RunProduction(imageRotate);

                //Inspection view will be re-created again when run operations
                cvWidnow.View = csConfigureHelper.Inspection.View;

                messageHelper.ShowMainLoading("Display Image...");
                cvWidnow.DisplayView();

                //Clean up
                image?.Dispose();
                imageRotate?.Dispose();
                messageHelper.CloseForm();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                messageHelper.Info(ex.Message);
            }
        }

        private void CloseBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BarCodeBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SettingsForm settings=new SettingsForm(csConfigureHelper.Inspection.Barcode))
            {
                settings.Text = "Barcode Settings";
                settings.ShowDialog();
            }
        }

        private void RerunBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rotate image
            var imageRotate = cvWidnow.RotateImage(csConfigureHelper.Inspection.sourceImage, 
                csConfigureHelper.Inspection.Rotate);

            //Runs operations
            messageHelper.ShowMainLoading("Process Image...");
            csConfigureHelper.Inspection.RunProduction(imageRotate);

            messageHelper.ShowMainLoading("Display Image...");
            cvWidnow.View= csConfigureHelper.Inspection.View;
            cvWidnow.DisplayView();

            //Finish up
            messageHelper.CloseForm();
        }
    }
}
