using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditButton
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            csButtonEditEx1.CustomClicked += CsButtonEditEx1_CustomClicked;
        }

        private void CsButtonEditEx1_CustomClicked(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e==null)
            {
                Debug.WriteLine("Text Area click");
            }
            else  
            {
                Debug.WriteLine("Button Area click");
            }
        }
    }
}
