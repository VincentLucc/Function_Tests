using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _CommonCode_Framework;
using DllImportHelper.Classes;

namespace DllImportHelper
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CallDll1DoButton_Click(object sender, EventArgs e)
        {
            try
            {
                QuickTestHelper.TestDoSth();
            }
            catch (Exception ex)
            {
                ex.TraceException("CallDll1DoButton_Click");
            }
        }

        private void TestPlusButton_Click(object sender, EventArgs e)
        {
            try
            {
                var abc = QuickTestHelper.TestPlus(3, 5);
                $"Output:{abc}".TraceRecord();
            }
            catch (Exception ex)
            {
                ex.TraceException("CallDll1DoButton_Click");
            }
        }
    }
}
