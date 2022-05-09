using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init variables
            csPublic.winMain = this;
        }

        private async void bLoading_Click(object sender, EventArgs e)
        {
            UIHelper.ShowMainLoading("Test");
            await Task.Delay(5000);
            UIHelper.CloseForm();
        }

        private async void bSplash_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultSplashScreen();
            await Task.Delay(5000);
            UIHelper.CloseForm();
        }

        private async void bOverLap_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowOverlayForm(this);
            var handle = UIHelper.ShowCustomOverLay("Doing Sth:\r\n"+"dfsdfsdfsd");
            await Task.Delay(5000);
            UIHelper.CloseOverLayForm(handle);
        }
    }


}
