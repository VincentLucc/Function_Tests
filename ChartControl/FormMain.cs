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

namespace ChartControl
{
    public partial class FormMain: XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ChartDoughnus chartDoughnus = new ChartDoughnus();
            chartDoughnus.ShowDialog();
        }
    }
}
