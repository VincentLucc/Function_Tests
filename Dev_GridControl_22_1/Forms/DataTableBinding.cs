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

namespace Dev_GridControl_22_1.Forms
{
    public partial class DataTableBinding : DevExpress.XtraEditors.XtraForm
    {

        public DataTable dtData { get; set; }
        public DataTableBinding()
        {
            InitializeComponent();
        }

        private void DataTableBinding_Load(object sender, EventArgs e)
        {
            dtData=new DataTable();
            dtData.Columns.Add(new DataColumn("Test01"));
            dtData.Columns.Add(new DataColumn("Test02"));
            dtData.Columns.Add(new DataColumn("Test03"));
            dtData.Columns.Add(new DataColumn("Test04"));
            dtData.Columns.Add(new DataColumn("Test05"));

            for (int i = 0; i < 20; i++)
            {
                dtData.Rows.Add(new object[] { i, i + 1, i + 2, i + 3, i + 4 });
            }

            gridControl1.DataSource= dtData;
        }

        private void AddSample_Click(object sender, EventArgs e)
        {
            int i = dtData.Rows.Count;
            dtData.Rows.Add(new object[] { i, i + 1, i + 2, i + 3, i + 4 });
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (dtData.Rows.Count>10)
            {
                var dataRow = dtData.Rows[10];
                dataRow[2] = "12100";
            }
        }
    }
}