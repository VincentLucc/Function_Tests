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
    public partial class ucMessage : UserControl
    {
        public ucMessage()
        {
            InitializeComponent();
        }

        private void bShowMessage_Click(object sender, EventArgs e)
        {
            UIHelper.ShowInfo("This is a test.", "Test");
        }

        private void bShowMessage2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Default Message");
        }

        private void ucMessage_Load(object sender, EventArgs e)
        {
          
         
        }


    }
}
