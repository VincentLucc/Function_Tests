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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            //Valued tracker bar
            valueTrackerBarUserControl1.LoadConfig(0,100,30,"Test Value:");
            valueTrackerBarUserControl1.ValueChanged += ValueTrackerBarUserControl1_ValueChanged;

        }

        private void ValueTrackerBarUserControl1_ValueChanged()
        {
            Debug.WriteLine("Value changed:"+ valueTrackerBarUserControl1.iCurrentValue);
        }
    }
}
