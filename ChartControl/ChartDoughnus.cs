using DevExpress.XtraCharts;
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
using DevExpress.Utils;

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
            chartControl1.AutoLayout = false; //Allow user to see the values when minimized
            chartControl1.SizeChanged += ChartControl1_SizeChanged;
        }

  
        private void ChartControl1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("ChartControl1_SizeChanged:" + chartControl1.Size);
                if (chartControl1.Series.Count == 0) return;
                UpdateLabelVisibility();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private void UpdateLabelVisibility()
        {
            var chartSerial = chartControl1.Series[0];
            var chartView = chartSerial.View as PieSeriesView;

            //Set total label
            if (chartControl1.Size.Width < 200 || chartControl1.Size.Height < 150)
            {
                chartSerial.LabelsVisibility = DefaultBoolean.False;//Set normal label
                chartView.TotalLabel.Visible = false; //Set total label
            }
            else
            {
                chartView.TotalLabel.Visible = true;//Set total label
                chartSerial.LabelsVisibility = DefaultBoolean.True;//Set normal label
            }
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