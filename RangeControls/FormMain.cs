using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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

namespace RangeControls
{
    public partial class FormMain : XtraForm
    {
        BindingList<int> Points;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupRangeTrackerBars();
            SetupValueTrackerBars();
        }



        private void SetupValueTrackerBars()
        {
            //Valued tracker bar
            valueTrackerBarUserControl1.LoadConfig(0, 100, 30, "Test Value:");
            valueTrackerBarUserControl1.ValueChanged += ValueTrackerBarUserControl1_ValueChanged;

        }

        private void SetupRangeTrackerBars()
        {
            rangeUserControl1.LoadConfig(0, 100, 20, 50);
            rangeUserControl1.CreateLabels(5);
            //Set labels
            //var rangeControl = rangeUserControl1.rangeTrackBarControl1;
            //rangeControl.Properties.TickFrequency = 10;
            //rangeControl.Properties.ShowLabels = true;
            //rangeControl.Properties.Labels.Clear();
            //for (int i = 0; i <= 10; i++)
            //{
            //    int iValue = i * 10;
            //    var label = new TrackBarLabel(iValue.ToString(), iValue);
            //    rangeControl.Properties.Labels.Add(label);
            //}
            //rangeControl.RefreshLabels();
        }

        private void ValueTrackerBarUserControl1_ValueChanged()
        {
            Debug.WriteLine("Value changed:" + valueTrackerBarUserControl1.iCurrentValue);
        }

        private void bInitRangeControl_Click(object sender, EventArgs e)
        {
            InitRangeControls();
        }


        private void InitRangeControls()
        {
            // Assign a date-time chart client to the Range control. 
            ChartRangeControl.Client = dateTimeChartRangeControlClient1;
            ChartRangeControl.Paint -= ChartRangeControl_Paint;
            ChartRangeControl.Paint += ChartRangeControl_Paint;

            //Create data
            var timePoints = new BindingList<csRangeTimeItem>();
            for (int i = 0; i < 10; i++)
            {
                var rangeItem1 = new csRangeTimeItem(DateTime.Now.AddMinutes(i), i, 0);
                timePoints.Add(rangeItem1);

                //Add series two
                var rangeItem2 = new csRangeTimeItem(DateTime.Now, i + 0.5, 1);
                timePoints.Add(rangeItem2);
            }

            AreaChartRangeControlClientView dateTimeAreaView = new AreaChartRangeControlClientView();

            //Create view, default is line view
            //Specify the chart range control client view.
            dateTimeAreaView.ShowMarkers = true;//Must have
            dateTimeAreaView.AreaOpacity = 0;//Hide area
            dateTimeAreaView.Color = Color.Transparent;//Hide chart line
            dateTimeAreaView.MarkerSize = 10;
            dateTimeAreaView.MarkerColor = Color.Red;
            dateTimeChartRangeControlClient1.DataProvider.TemplateView = dateTimeAreaView;


            //Set data member. 
            dateTimeChartRangeControlClient1.DataProvider.ArgumentDataMember = nameof(csRangeTimeItem.XAxisTime);
            dateTimeChartRangeControlClient1.DataProvider.ValueDataMember = nameof(csRangeTimeItem.YAxisValue);
            dateTimeChartRangeControlClient1.DataProvider.SeriesDataMember = nameof(csRangeTimeItem.SeriesIndex);
            //Ref:https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
            dateTimeChartRangeControlClient1.GridOptions.LabelFormat = "HH':'mm':'ss";

            //Must assign before custom series
            dateTimeChartRangeControlClient1.DataProvider.DataSource = timePoints;

            //Force range
            dateTimeChartRangeControlClient1.Range.Auto = false;
            dateTimeChartRangeControlClient1.Range.Max = DateTime.Now.AddMinutes(10);
            dateTimeChartRangeControlClient1.Range.Min = DateTime.Now.AddMinutes(-10);
            dateTimeChartRangeControlClient1.CustomizeSeries -= DateTimeChartRangeControlClient1_CustomizeSeries;
            dateTimeChartRangeControlClient1.CustomizeSeries += DateTimeChartRangeControlClient1_CustomizeSeries;
        }



        private void DateTimeChartRangeControlClient1_CustomizeSeries(object sender, ClientDataSourceProviderCustomizeSeriesEventArgs e)
        {
            if (e.View is AreaChartRangeControlClientView)
            {
                var dateTimeAreaView = e.View as AreaChartRangeControlClientView;
                // Change the Area series color.  
                if (e.DataSourceValue.ToString() == "0")
                {
                    dateTimeAreaView.MarkerColor = Color.Red;
                    dateTimeAreaView.Color = Color.Transparent;
                }
                else if (e.DataSourceValue.ToString() == "1")
                {
                    dateTimeAreaView.MarkerColor = Color.Blue;
                    dateTimeAreaView.Color = Color.Transparent;
                }
            }


        }

        private void ChartRangeControl_Paint(object sender, PaintEventArgs e)
        {

        }

        public class csRangeTimeItem
        {
            /// <summary>
            /// ArgumentDataMember 
            /// NumericChartRangeControlClient:Double
            /// DateTimeChartRangeControlClient:Datetime
            /// </summary>
            public DateTime XAxisTime { get; set; }
            /// <summary>
            /// ValueDataMember 
            /// </summary>
            public double YAxisValue { get; set; }
            /// <summary>
            /// SeriesDataMember 
            /// </summary>
            public int SeriesIndex { get; set; }

            public csRangeTimeItem(DateTime _axisX, double _axisY, int _series)
            {
                XAxisTime = _axisX;
                YAxisValue = _axisY;
                SeriesIndex = _series;
            }
        }
    }
}
