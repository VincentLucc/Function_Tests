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
    public partial class CustomColumns : DevExpress.XtraEditors.XtraForm
    {
        public CustomColumns()
        {
            InitializeComponent();
        }

        private void CustomColumns_Load(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridView1.Columns.AddVisible(nameof(Student.Name));
            gridView1.Columns.AddField("123"); //Not visible
            gridView1.Columns.AddVisible("abc"); //Visible

            var data = csPublic.CreateStudents();
            gridControl1.DataSource = data;
        }
    }
}