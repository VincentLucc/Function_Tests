using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartControl
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ChartDoughnus chartDoughnus = new ChartDoughnus();
            chartDoughnus.ShowDialog();
        }

        private void bHisto_Click(object sender, EventArgs e)
        {
            chartControl1.Series.Clear();
            //Hide legend
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            var dataSeries = new DevExpress.XtraCharts.Series("Histogram", ViewType.Area);
            dataSeries.ValueScaleType = ScaleType.Numerical;


            //Create fake data
            List<SeriesPoint> points = new List<SeriesPoint>();
            for (int i = 0; i < 255; i++)
            {
                int iValue = 0;

                using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
                {
                    byte[] bData = new byte[2];
                    provider.GetBytes(bData);
                    iValue = BitConverter.ToUInt16(bData, 0);
                }

                points.Add(new SeriesPoint(i, iValue));
            }

            //Add data
            dataSeries.Points.AddRange(points.ToArray());



            //Add to generate the diagram
            chartControl1.Series.Add(dataSeries);


            //Fix the range (Can still show value out side range)
            //This is just a proximate range, use custom label instead
            var xyDiagram = chartControl1.Diagram as XYDiagram;
            //xyDiagram.AxisX.WholeRange.MinValue = 0;
            //xyDiagram.AxisX.WholeRange.MaxValue = 255;

            //Add 
            xyDiagram.AxisX.CustomLabels.Clear();
            for (int i = 0; i <= 255; i += 15)
            {
                xyDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel(i.ToString(), i));

            }
        }
    }
}
