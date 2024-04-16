using DevExpress.Charts.Native;
using DevExpress.Data.Mask.Internal;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartControl
{
    public partial class FormMain : XtraForm
    {

        public bool EnableUpdate = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ChartDoughnus chartDoughnus = new ChartDoughnus();
            chartDoughnus.ShowDialog();
        }

        private void bHisto_Click(object sender, EventArgs e)
        {
            HistoChartControl.Series.Clear();
            //Hide legend
            HistoChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            var dataSeries = new DevExpress.XtraCharts.Series("Histogram", ViewType.Area);
            dataSeries.ArgumentScaleType = ScaleType.Numerical;
            dataSeries.ValueScaleType = ScaleType.Numerical;

            //Add data
            dataSeries.Points.AddRange(CreateFakeGrayPoints().ToArray());



            //Add to generate the diagram
            HistoChartControl.Series.Add(dataSeries);


            //Fix the range (Can still show value out side range)
            //This is just a proximate range, use custom label instead
            var xyDiagram = HistoChartControl.Diagram as XYDiagram;
            //xyDiagram.AxisX.WholeRange.MinValue = 0;
            //xyDiagram.AxisX.WholeRange.MaxValue = 255;

            //Add 
            xyDiagram.AxisX.CustomLabels.Clear();
            for (int i = 0; i <= 255; i += 15)
            {
                xyDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel(i.ToString(), i));

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (EnableUpdate)
            {
                UpdateData();
            }


            timer1.Enabled = true;
        }


        private void UpdateData()
        {
            if (HistoChartControl.Series.Count == 0) return;
            HistoChartControl.SuspendLayout();
            HistoChartControl.Series[0].Points.Clear();
            HistoChartControl.Series[0].Points.AddRange(CreateFakeGrayPoints().ToArray());
            HistoChartControl.ResumeLayout();
        }

        private List<SeriesPoint> CreateFakeGrayPoints()
        {
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

            return points;
        }

        public class csTimeValue
        {
            public DateTime Time { get; set; }

            public string TimeLabel
            {
                get { return Time.ToString("HH:mm:ss.fff"); }
            }

            public double Value { get; set; }

            public csTimeValue()
            {

            }

            public csTimeValue(DateTime Time, double Value)
            {
                this.Time = Time;
                this.Value = Value;
            }
        }

        private List<csTimeValue> CreateFakeTimePoints()
        {
            List<csTimeValue> points = new List<csTimeValue>();
            for (int i = 0; i < 100; i++)
            {
                int iValue = 0;

                using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
                {
                    byte[] bData = new byte[1];
                    provider.GetBytes(bData);
                    iValue = bData[0];
                }

                DateTime Time = DateTime.Now.AddSeconds(i).AddMilliseconds(iValue);
                points.Add(new csTimeValue(Time, iValue));
            }

            return points;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            EnableUpdate = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            EnableUpdate = false;
        }

        private void ProcessTimeChartButton_Click(object sender, EventArgs e)
        {
            TimeChartControl.Series.Clear();
            //TimeChartControl.CustomDrawAxisLabel += TimeChartControl_CustomDrawAxisLabel;

            AddSeries();
            AddSeries();
 
            //Change the text format 
            //Default: 2024-04-16 9:53:51 AM
            //Set argument
            //var xyDiagram = TimeChartControl.Diagram as XYDiagram;

            //Fix the range (Can still show value out side range)
            //This is just a proximate range, use custom label instead

            //xyDiagram.AxisX.WholeRange.MinValue = 0;
            //xyDiagram.AxisX.WholeRange.MaxValue = 255;

            //Add 
            //xyDiagram.AxisX.CustomLabels.Clear();
            ////Show only 10 labels
            //int iAcc = dataSeries.Points.Count / 10;
            //for (int i = 0; i < dataSeries.Points.Count; i += iAcc)
            //{
            //    DateTime dateTime = dataSeries.Points[i].DateTimeArgument;
            //    string sTime = dateTime.ToString("H:mm:ss.fff");
            //    xyDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel(sTime, dateTime));
            //}

            //By default: now show 1 day's entry
            ////https://supportcenter.devexpress.com/ticket/details/t701075/xtrachart-how-to-show-datetime-arguments-with-the-time-part
            //xyDiagram.AxisX.DateTimeScaleOptions.AutoGrid = false;
            //xyDiagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
            //xyDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Second;
            //xyDiagram.AxisX.DateTimeScaleOptions.GridSpacing = 1;




            //Range doesn't work well
            //xyDiagram.AxisX.WholeRange.SetMinMaxValues(fakeTimePoints[0].Time, fakeTimePoints[99].Time);
            //xyDiagram.AxisX.VisualRange.SetMinMaxValues(fakeTimePoints[0].Time, fakeTimePoints[99].Time);
        }

        private void AddSeries()
        {
            //Create series
            var dataSeries1 = new Series("Processing Time", ViewType.Bar);
            dataSeries1.Name = $"Time:{DateTime.Now}";
            
            //Set to numeric to count one by one instead of based on the time line
            dataSeries1.ArgumentScaleType = ScaleType.Qualitative;
            dataSeries1.ValueScaleType = ScaleType.Numerical; //Y Axis
            dataSeries1.Label.ResolveOverlappingMode = ResolveOverlappingMode.None;

            //Use data source
            dataSeries1.ArgumentDataMember = nameof(csTimeValue.TimeLabel);
            dataSeries1.ValueDataMembers.AddRange(new string[] { nameof(csTimeValue.Value) });
            var fakeTimePoints = CreateFakeTimePoints();
            dataSeries1.DataSource = fakeTimePoints;


            TimeChartControl.Series.Add(dataSeries1);
        }

        private void TimeChartControl_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {



            if (e.Item.AxisValue is DateTime)
            {
                var time = (DateTime)e.Item.AxisValue;
                e.Item.Text = time.ToString("HH:mm:ss:fff");
            }
        }

        private void RotateChartButton_Click(object sender, EventArgs e)
        {
            var xyDiagram = TimeChartControl.Diagram as XYDiagram;
            xyDiagram.Rotated = !xyDiagram.Rotated;
        }

        private void CameraLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
