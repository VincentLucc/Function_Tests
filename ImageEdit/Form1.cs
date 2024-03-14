using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageEdit
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
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

            pictureEdit1.Properties.Caption.Alignment= ContentAlignment.MiddleCenter;
            pictureEdit1.Properties.Caption.Text = "Test";



            LoadImages();
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
    }
}
