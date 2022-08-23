using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMessage
{
    public partial class Form1 : Form
    {
        csDevMessage messageHelper;

        public Form1()
        {
            InitializeComponent();
            csPublic.formMain = this;
            messageHelper = new csDevMessage(this);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UIHelper.ShowMainLoading("Please wait.");
            await Task.Delay(2000);
            UIHelper.CloseLoadingForm();
            UIHelper.ShowMainLoading();
            await Task.Delay(1000);
            UIHelper.CloseLoadingForm();
        }

        private void bShowInfo2_Click(object sender, EventArgs e)
        {
            UIHelper.ShowInfo2("Info2", "Info");
        }

        private void bShowInfo1_Click(object sender, EventArgs e)
        {
            UIHelper.ShowInfo("Info1", "Info");
        }

        private void bShowInfoDefault_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info default");
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            messageHelper.ShowMainLoading("Please wait.");
            await Task.Delay(2000);
            UIHelper.CloseLoadingForm();
            messageHelper.ShowMainLoading();
            await Task.Delay(1000);
            messageHelper.CloseLoadingForm();
        }

        private void ucMessage1_Load(object sender, EventArgs e)
        {

        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            messageHelper.InfoAsyncNoRepeat("Async Test 1");
            await Task.Delay(500);//wait for message box
            messageHelper.InfoAsyncNoRepeat("Async Test 2");
            Debug.WriteLine("Message Shown");
            Task.Run(() =>
            {
                while (messageHelper.IsMessageBoxExist)
                {
                    continue;
                }
                messageHelper.InfoAsyncNoRepeat("Task test");
            });
            Debug.WriteLine("Message Shown");

        }
    }
}
