using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMessage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            csPublic.formMain = this;
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
            UIHelper.ShowInfo("Info1","Info");
        }

        private void bShowInfoDefault_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info default");
        }
    }
}
