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

namespace ChartControl
{
    public partial class ChartDoughnus : DevExpress.XtraEditors.XtraForm
    {
        public ChartDoughnus()
        {
            InitializeComponent();
        }

        private void ChartDoughnus_Load(object sender, EventArgs e)
        {
            chartControl1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True; //Show tool tip 
            chartControl1.ToolTipOptions.ShowForPoints = true; //DoughtNut will show for points mode
            chartControl1.ToolTipOptions.ShowForSeries = false; //Won't trigger when turn on
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var series = chartControl1.Series[0];
            series.Points[0].Values[0] = 0;
            series.Points[1].Values[0] = 0;
            series.Points[2].Values[0] = 100;
            series.Points[3].Values[0] = 0;
            chartControl1.RefreshData();
        }
    }
}