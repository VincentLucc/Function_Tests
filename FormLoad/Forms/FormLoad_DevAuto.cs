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
    public partial class FormLoad_DevAuto : FormReloadBaseDev
    {


        public FormLoad_DevAuto()
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

        }

        private void FormLoadTest_Shown(object sender, EventArgs e)
        {
            int x = 122;
            this.Hide();
            this.Visible = true;
        }


    }
}
