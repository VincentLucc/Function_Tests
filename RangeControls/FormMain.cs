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
    public partial class FormMain : Form
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
            //Devexpress.RangeControl
            SetupRangeControls();

        }

        private void SetupRangeControls()
        {
            Points = new BindingList<int>();
            Points.Add(5);
            Points.Add(8);
            Points.Add(10);
            numericChartRangeControlClient1.DataProvider.DataSource = Points;
            //rangeControl1      
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
            Debug.WriteLine("Value changed:"+ valueTrackerBarUserControl1.iCurrentValue);
        }
    }
}
