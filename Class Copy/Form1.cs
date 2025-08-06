using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        }

        private void StartCopySimpleButton_Click(object sender, EventArgs e)
        {
            StartCopyAction();
        }

        private void StartCopyAction()
        {
            Test1 instance1 = new Test1();
            Test2 instance2 = new Test2()
            {
                Property01 = "123",
                Property02 = "123",
                Field01 = "123",
                A04 = "123"
            };
            instance2.SubItem = new Sub2 { A03 = "a03", ABC = "abc" };
            instance2.ListString = new List<string>() { "a", "b", "c", "d" };
            instance2.Test01 = EnumTest.Level2;
            instance2.ListSubItem = new List<Sub2>() { new Sub2(), new Sub2() };

            instance1.CopyInstanceValues(instance2);

            Debug.WriteLine("Test");
        }
    }
}
