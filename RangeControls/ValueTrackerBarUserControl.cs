using DevExpress.XtraEditors.Repository;
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


    public partial class ValueTrackerBarUserControl : UserControl
    {
        public int iLowLimit = 0;
        public int iHighLimit = 100;
        public int iCurrentValue = 50;
            
        public delegate void ValueChangedAction();
        public event ValueChangedAction ValueChanged;

        public ValueTrackerBarUserControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(int _iMinLimit, int _iMaxLimit, int _iValue, string sValueCaption = "Value:")
        {
            //Set text
            ValueLayoutControlItem.Text = sValueCaption;

            //Set range limit
            iLowLimit = _iMinLimit;
            iHighLimit = _iMaxLimit;
            trackBarControl1.Properties.Minimum = iLowLimit;
            trackBarControl1.Properties.Maximum = iHighLimit;

            //Set range value
            iCurrentValue = _iValue;
            trackBarControl1.Value = iCurrentValue;

            //Set text box
            ValueTextEdit.Text = iCurrentValue.ToString();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (iCurrentValue == trackBarControl1.Value) return;

            iCurrentValue = trackBarControl1.Value;

            //Set text box
            ValueTextEdit.Text = iCurrentValue.ToString();

            ValueChanged?.Invoke();

        }

        private void ValueTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ValueTextEdit.Text, out int iValue))
            {
                //Check range
                if (iValue >= iLowLimit && iValue <= iHighLimit)
                {

                    if (iCurrentValue != iValue)
                    {
                        iCurrentValue = iValue;
                        trackBarControl1.Value = iCurrentValue;
                    }
                }
                else
                {
                    //Set value back
                    ValueTextEdit.Text = iCurrentValue.ToString();
                }

            }
            else
            {
                //Set value back
                ValueTextEdit.Text = iCurrentValue.ToString();
            }
        }
    }

