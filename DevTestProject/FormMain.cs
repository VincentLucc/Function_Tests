using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestProject
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public List<MailSample> Mails { get; set; }


        public FormMain()
        {
            InitializeComponent();
            ClassPublic.winMain = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateData(); // create sample data
        }


        /// <summary>
        /// create sample data
        /// </summary>
        private void GenerateData()
        {
            Mails = new List<MailSample>();

            for (int i = 0; i < 100; i++)
            {
                var tempMail = new MailSample();
                tempMail.MailID = i;
                tempMail.Title = $"Mail ID {i+1}";
                tempMail.Sender = "abc";
                tempMail.Content = "sdfdsfjhsdkfhksdjhfksdalfhlaksdfafhashdfkashdfksadhfksahdfkahsdfkhasdkfhaskdfhskadfhsadkf";
                Mails.Add(tempMail);
            }

            gridControl1.DataSource = Mails;
            
        }

        private void bSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DisplayForm.Test();
        }
    }
}
