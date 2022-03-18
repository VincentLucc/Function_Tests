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

namespace Dev_GaugeControl
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bShowGauge_Click(object sender, EventArgs e)
        {
            GaugeForm gaugeForm = new GaugeForm();
            gaugeForm.ShowDialog();
        }
    }
}
