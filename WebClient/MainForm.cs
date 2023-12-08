using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebClient
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        csDevMessage messageHelper;
        
        public MainForm()
        {
            InitializeComponent();

            messageHelper = new csDevMessage(this);
        }

        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //WebRequest_Post(null,null,out string sData,out string sMsg);

            if (!await csAPIHelper.Login())
            {
                messageHelper.Info("Login Fail.");
            }
       
        }

        private async void RequestButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!await csAPIHelper.RequestCode())
            {
                messageHelper.Info("Request Fail.");
            }
        }
    }
}