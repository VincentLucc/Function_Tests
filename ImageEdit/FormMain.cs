using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageEdit
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        MagickImage magickImage;
        MagickFormat saveFormat = MagickFormat.Bmp;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init image edit
            imageEdit1.EditValue = Properties.Resources.About_32x32;


            //Init picture edit
            pictureEdit1.Image = Properties.Resources.About_32x32;
            pictureEdit1.CustomDisplayText += PictureEdit1_CustomDisplayText;
            pictureEdit1.Properties.PictureAlignment = ContentAlignment.MiddleLeft;

            pictureEdit1.Properties.Caption.Visible = true;

            pictureEdit1.Properties.Caption.Alignment = ContentAlignment.MiddleCenter;
            pictureEdit1.Properties.Caption.Text = "Test";

            //Magick Image
            magicKFOrmatlookUpEdit.Properties.DataSource = Enum.GetValues(typeof(MagickFormat));
            magicKFOrmatlookUpEdit.EditValue = MagickFormat.Bmp;
            magicKFOrmatlookUpEdit.Properties.ShowFooter = false;
            magicKFOrmatlookUpEdit.CustomDisplayText += MagicKFOrmatlookUpEdit_CustomDisplayText;
            magicKFOrmatlookUpEdit.EditValueChanged += MagicKFOrmatlookUpEdit_EditValueChanged;
            buttonEdit1.Click += ButtonEdit1_Click;

            LoadImages();
        }

        private void MagicKFOrmatlookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value is MagickFormat)
            {
                string sDisplay = ((MagickFormat)magicKFOrmatlookUpEdit.EditValue).ToString();
                e.DisplayText = $"*.{sDisplay}";
            }
        }

        private void MagicKFOrmatlookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (magicKFOrmatlookUpEdit.EditValue is MagickFormat)
            {
                saveFormat = (MagickFormat)magicKFOrmatlookUpEdit.EditValue;
            }
        }

        private void ButtonEdit1_Click(object sender, EventArgs e)
        {
            
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                string sFile = ofd.FileName;
                magickImage = new MagickImage(sFile);
                magickImage.Format = MagickFormat.Bmp;
                using (MemoryStream stream = new MemoryStream(magickImage.ToByteArray()))
                {
                    var bitmapImage = Bitmap.FromStream(stream);
                    pictureEdit2.Image = bitmapImage;
                }
            }
        }

        private void LoadImages()
        {
            pictureBox1.Image = csImages.About;
            pictureBox2.Image = csImages.DemoSVG32;
            pictureBox3.Image = csImages.DemoSVG64;
        }

        private void PictureEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {

        }

        private void SaveMagickButton_Click(object sender, EventArgs e)
        {
            if (magickImage == null)
            {
                MessageBox.Show("No image load.");
            }

            using (SaveFileDialog dialog=new SaveFileDialog())
            {
                //Get type
                magickImage.Format = saveFormat;

                dialog.Filter = $"{saveFormat} File|*.{saveFormat}";

                if (dialog.ShowDialog()!= DialogResult.OK) return;


                magickImage.Write(dialog.FileName);

            }


 


        }
    }
}
