using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridLookUpEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init
            List<RowData> gridData = new List<RowData>();
            for (int i = 0; i < 3; i++)
            {
                gridData.Add(new RowData() {Value="Input_"+i});
            }

            gridLookUpEdit1.datas

        }

        public class RowData
        {
            public int iIcon { get; set; }
            public string Value { get; set; }

        }
    }
}
