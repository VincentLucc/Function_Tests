using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_SQLite_Official_Dapper
{
    public partial class ToolbarForm1 : DevExpress.XtraEditors.XtraForm
    {
        public ToolbarForm1()
        {
            InitializeComponent();
        }

        private void bCreateDataBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!csSQLHelper.CreateDataBase(out string sMessage))
            {
                MessageBox.Show(sMessage);
            }

        }

        private void bInsertData_ItemClick(object sender, ItemClickEventArgs e)
        {

            var record = new RecordRow();
            if (!csSQLHelper.AddRecord(record, out string sMessage))
            {
                MessageBox.Show(sMessage);
            }
        }

        private void bGetMAx_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!csSQLHelper.GetMaxRecord(out int? iMax, out string sMessage))
            {
                MessageBox.Show(sMessage);
            }
        }
    }
}