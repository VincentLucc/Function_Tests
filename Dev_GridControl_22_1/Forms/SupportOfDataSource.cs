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
    public partial class SupportOfDataSource : DevExpress.XtraEditors.XtraForm
    {
        public SupportOfDataSource()
        {
            InitializeComponent();
        }

        private void ValueTupleButton_Click(object sender, EventArgs e)
        {
            //不能直接绑定！！！
            List<(int ID, string Name, string Description)> list=new List<(int ID, string Name, string Description)>();
            for (int i = 0; i < 10; i++)
            {
                list.Add((i+1,$"Name_{i+1}",$"Description_{i+1}"));
            }

            var type=typeof((int ID, string Name, string Description));
            gridView1.Columns.Clear();
            gridView1.Columns.AddVisible("ID");
            gridView1.Columns.AddVisible("Name");
            gridView1.Columns.AddVisible("Description");
            gridControl1.DataSource= list;
        }
    }
}