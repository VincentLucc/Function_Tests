using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMessage
{
    public partial class FormMain : Form
    {
        csDevMessage messageHelper;

        public FormMain()
        {
            InitializeComponent();
            csPublic.formMain = this;
            messageHelper = new csDevMessage(this);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;//user can't operate the form
            UIHelper.ShowMainLoading("Please wait.");
            await Task.Delay(2000);
            UIHelper.CloseLoadingForm();
            UIHelper.ShowInfo("abc.123", "Title 01");
            UIHelper.ShowMainLoading();

            await Task.Delay(1000);
            UIHelper.CloseLoadingForm();
            this.Enabled = true;
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

            //Block user action
            this.Enabled = false;

            await Task.Delay(2000);
            UIHelper.CloseLoadingForm();
            messageHelper.ShowMainLoading();
            await Task.Delay(1000);
            this.Enabled = true;
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
            await Task.Run(() =>
            {
                while (messageHelper.IsMessageBoxExist)
                {
                    continue;
                }
                messageHelper.InfoAsyncNoRepeat("Task test");
            });
            Debug.WriteLine("Message Shown");
        }

        private async void bSHowOverLay_Click(object sender, EventArgs e)
        {
            var overLayHandler = messageHelper.ShowCustomOverLay("Overlay Test");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 5000)
            {
                await Task.Delay(100);
                overLayHandler.customPainter.sMessage = csPublic.timeString;
            }
            overLayHandler.Close();
        }

        private async void bSplashDefault_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen1), true, false, false);
            this.Enabled = false;
            await Task.Delay(2000);
            SplashScreenManager.CloseForm();
            this.Enabled = true;
        }

        private async void bSplashCustom_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(CustomSplashScreen), true, false, false);
            this.Enabled = false;
            await Task.Delay(2000);
            SplashScreenManager.CloseForm();
            this.Enabled = true;
        }

        private void bWaitWIthBlock_Click(object sender, EventArgs e)
        {
            var task1 = Task.Delay(2000);
            WaitTaskDialog.WaitTask(task1);
            var task2 = Task.Delay(2000);
            WaitTaskDialog.WaitTask(task2, "Message is message.", "Title Area");
        }

        private void UpdateBlockedWaitingButton_Click(object sender, EventArgs e)
        {
            bool bResult = WaitTaskDialog.WaitTask(UpdateAction());
        }


        private async Task<bool> UpdateAction()
        {
            await Task.Delay(1500);
            WaitTaskDialog.UpdateMessage("This is a test.");
            for (int i = 0; i < 100000; i++)
            {
                //await Task.Delay(1);
                WaitTaskDialog.UpdateMessage(DateTime.Now.ToLongTimeString());
            }
            return true;
        }
    }
}
