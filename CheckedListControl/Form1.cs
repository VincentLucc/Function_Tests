using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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

namespace CheckedListControl
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //checkedListBoxControl1.DataSource = new List<InkSystemFunctionCode> { InkSystemFunctionCode.EnableDegass, InkSystemFunctionCode.EnableDegass};
            //var x = InkSystemFunctionCode.EnableDegass;

            List<CheckedListBoxItem> itemList = new List<CheckedListBoxItem>();
            bool[] bData = new bool[16];
            for (int i = 0; i < 16; i++)
            {
                if (Enum.IsDefined(typeof(InkSystemFunctionCode), i))
                {
                    var function = (InkSystemFunctionCode)i;
                    Debug.WriteLine((InkSystemFunctionCode)i);
                    //Add item
                    var item = new CheckedListBoxItem(function.GetDisplayName(), bData[i]);
                    item.Tag = i;
                    checkedListBoxControl1.Items.Add(item);
                }
            }

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            bool[] bDate = new bool[16];//Sample existing value
            foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
            {
                int iIndex = (int)item.Tag;
                bool bResult = item.CheckState == CheckState.Checked ? true : false;
                bDate[iIndex] = bResult;
            }

            //Get current settings

        }
    }
}