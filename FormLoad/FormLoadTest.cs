using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLoad
{
    public partial class FormLoadTest : Form
    {


        public FormLoadTest()
        {
            InitializeComponent();
        }

        private async void FormLoadTest_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                //Thread.Sleep(100);
                await Task.Delay(100);
            }

            this.Show();
        }

        private void FormLoadTest_Shown(object sender, EventArgs e)
        {
            int x = 122;
            this.Hide();
            this.Visible = true;
        }


    }
}
