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
            UIHelper.ShowMainLoading("Loading!");
            await Task.Delay(2000);
            UIHelper.CloseLoadingForm();
        }
    }
}
