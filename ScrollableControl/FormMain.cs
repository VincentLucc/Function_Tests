using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollableControl
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xtraScrollableControl1.Scroll += XtraScrollableControl1_Scroll;
        }

        private void XtraScrollableControl1_Scroll(object sender, XtraScrollEventArgs e)
        {
            Debug.WriteLine($"XtraScrollableControl1_Scroll:{e.NewValue}");
            

        }
    }
}
