using DevExpress.Charts.Native;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RangeControls
{
    public partial class RangeUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public int iLowLimit { get; set; }
        public int iHighLimit { get; set; }

        public int iMinValue { get; set; }
        public int iMaxValue { get; set; }

        public delegate void ValueChangedAction();
        public event ValueChangedAction ValueChanged;



        public RangeUserControl()
        {
            InitializeComponent();
        }

        public RangeUserControl(int _iMinLimit, int _iMaxLimit, int _iMinValue, int _iHighValue)
        {
            InitializeComponent();
            LoadConfig(_iMinLimit, _iMaxLimit, _iMinValue, _iHighValue);
        }

        public void LoadConfig(int _iMinLimit, int _iMaxLimit, int _iMinValue, int _iHighValue)
        {
            //Set range limit
            iLowLimit = _iMinLimit;
            rangeTrackBarControl1.Properties.Minimum = iLowLimit;
            iHighLimit = _iMaxLimit;
            rangeTrackBarControl1.Properties.Maximum = iHighLimit;

            //Set range value
            iMinValue = _iMinValue;
            iMaxValue = _iHighValue;
            rangeTrackBarControl1.Value = new TrackBarRange(iMinValue, iMaxValue);

            //Set text box
            MinTextEdit.Text = _iMinValue.ToString();
            MaxTextEdit.Text = _iHighValue.ToString();
        }

        public void CreateLabels(int iCount)
        {
            rangeTrackBarControl1.Properties.Labels.Clear();
            int iRange = iHighLimit - iLowLimit;
            float fInterval = iRange / (iCount-1);
            rangeTrackBarControl1.Properties.TickFrequency = (int)fInterval; 

            for (int i = 0; i < iCount; i++)
            {
                int iValue = (int)(iLowLimit + i * fInterval);
                if (i==(iCount-1)) iValue = iHighLimit; //Make sure last one always right
 
                var label = new TrackBarLabel();
                label.Label = iValue.ToString();
                label.Value = iValue;
                rangeTrackBarControl1.Properties.Labels.Add(label);
            }
        }

        private void RangeUserControl_Load(object sender, EventArgs e)
        {
            rangeTrackBarControl1.ValueChanged += RangeTrackBarControl1_ValueChanged;
        }

        private void RangeTrackBarControl1_ValueChanged(object sender, EventArgs e)
        {
            iMinValue = rangeTrackBarControl1.Value.Minimum;
            iMaxValue = rangeTrackBarControl1.Value.Maximum;

            //Don't allow equal
            if (iMinValue == iMaxValue)
            {
                //Set value again
                if (iMinValue > iLowLimit)
                {
                    iMinValue -= 1;
                    rangeTrackBarControl1.Value = new TrackBarRange(iMinValue, iMaxValue);
                }
                else
                {
                    iMaxValue += 1;
                    rangeTrackBarControl1.Value = new TrackBarRange(iMinValue, iMaxValue);
                }

                return;
            }

            //Set text box
            MinTextEdit.Text = iMinValue.ToString();
            MaxTextEdit.Text = iMaxValue.ToString();

            ValueChanged?.Invoke();
        }

        private void MinTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(MinTextEdit.Text, out int iValue))
            {
                //Check range
                if (iValue >= iLowLimit && iValue < iMaxValue)
                {

                    if (iMinValue != iValue)
                    {
                        iMinValue = iValue;
                        rangeTrackBarControl1.Value = new TrackBarRange(iMinValue, iMaxValue);
                    }
                }
                else
                {
                    //Set value back
                    MinTextEdit.Text = iMinValue.ToString();
                }

            }
            else
            {
                //Set value back
                MinTextEdit.Text = iMinValue.ToString();
            }
        }

        private void MaxTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(MaxTextEdit.Text, out int iValue))
            {
                //Check range
                if (iValue <= iHighLimit && iValue > iMinValue)
                {
                    if (iMaxValue != iValue)
                    {
                        iMaxValue = iValue;
                        rangeTrackBarControl1.Value = new TrackBarRange(iMinValue, iMaxValue);
                    }

                }
                else
                {
                    //Set value back
                    MaxTextEdit.Text = iMaxValue.ToString();
                }

            }
            else
            {
                //Set value back
                MaxTextEdit.Text = iMaxValue.ToString();
            }
        }
    }
}
