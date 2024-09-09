using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Performance
{
    public partial class FormMain : XtraForm
    {
        csCPUTest cpuTest = new csCPUTest();
        public FormMain()
        {
            InitializeComponent();
        }

        private void CPUIntButton_Click(object sender, EventArgs e)
        {
            cpuTest.TestIntProcess(19999);
        }

        private void DoubleButton_Click(object sender, EventArgs e)
        {
            cpuTest.TestDoubleProcess(19999);
        }

        private void cpuOverAllButton_Click(object sender, EventArgs e)
        {
            double dResult = cpuTest.TestCPUPerSingle();
            ResultMemoEdit.AppendText($"Single:{dResult.ToString("n0")}\r\n");
        }

        private async void CPUPerMultiButton_Click(object sender, EventArgs e)
        {
            double dResult = await cpuTest.TestCPUPerMulti();
            ResultMemoEdit.AppendText($"Multiple:{dResult.ToString("n0")}\r\n");
        }

        private void FloatButton_Click(object sender, EventArgs e)
        {
            cpuTest.TestFloatAction(19999);
        }
    }
}
