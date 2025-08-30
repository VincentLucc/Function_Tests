using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListBox
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bDevListBox_Click(object sender, EventArgs e)
        {
            DevListBoxAutoToolTip winListBox=new DevListBoxAutoToolTip();
            winListBox.ShowDialog(this);
            
            //This is a test
     
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevListBoxManualToolTip winListBox = new DevListBoxManualToolTip();
            winListBox.ShowDialog(this);
        }

        private void bWinListBox_Click(object sender, EventArgs e)
        {
            WinListBox winListBox = new WinListBox();
            winListBox.ShowDialog(this);
        }

        private void bDevListBoxAlignment_Click(object sender, EventArgs e)
        {
            DevListBoxAlignment winAlignment = new DevListBoxAlignment();
            winAlignment.ShowDialog(this);
        }
    }
}
