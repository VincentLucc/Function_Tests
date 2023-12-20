using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class ContextMenuStripForm : XtraForm
    {
        public ContextMenuStripForm()
        {
            InitializeComponent();
        }

        private void FormToolTip_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                Student student = new Student() { 
                    Name = "Stu"+i.ToString("d2"),
                    Age = 10,
                    Class= i.ToString()
                };
                students.Add(student);
            }
            gridControl1.DataSource = students;
            csPublic.InitGridview(gridView1);

            //Set tooltip
            toolTipController1.GetActiveObjectInfo += ToolTipController1_GetActiveObjectInfo;
        }

        private void ToolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridControl1) return;
            ToolTipControlInfo info = null;
            //Get the view at the current mouse position
 
            //Get the view's element information that resides at the current position
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.HitTest == GridHitTest.RowCell)
            {
                object o = hitInfo.HitTest.ToString() + hitInfo.RowHandle.ToString();
                string text = gridView1.GetRowCellDisplayText(hitInfo.RowHandle, gridView1.Columns[nameof(Student.Name)]);  //       "Row " +  hi.RowHandle.ToString();
                info = new ToolTipControlInfo(o, text);
            }

            //Display tooltip
            if (info != null) e.Info = info;
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Close();
        }
    }
}
