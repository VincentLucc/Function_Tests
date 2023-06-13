using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Class_Copy
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Test1 abc=new Test1();
            Test2 abc1 = new Test2() {
                A01 = "123",
                A02= "123",
                A03= "123",
                A04= "123"
            };
            abc1.Sub1 = new Sub2 { A03="a03",ABC="abc"};

           abc.CopyPropertyValues(abc1);
        }
    }
}
