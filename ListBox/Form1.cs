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
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bDevListBox_Click(object sender, EventArgs e)
        {
            DevListBoxAutoToolTip winListBox=new DevListBoxAutoToolTip();
            winListBox.ShowDialog(this);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevListBoxManualToolTip winListBox = new DevListBoxManualToolTip();
            winListBox.ShowDialog(this);
        }
    }
}
