using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevLayout
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set tabPane navigation button image location
            foreach (IBaseButton button in this.tabPane1.ButtonsPanel.Buttons)
            {
                button.Properties.ImageLocation = DevExpress.XtraEditors.ButtonPanel.ImageLocation.AboveText;
            }

            //Focus function doesn't work inside of a layout control, use select intead
            //Controls must be loaded before set focus
            tbUserWinform.Select(); //Better put in load events
        }

        private void bFluent_Click(object sender, EventArgs e)
        {
            FluentDesignForm1 form1 = new FluentDesignForm1();
            form1.Show();
        }
    }
}
