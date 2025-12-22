using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
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

namespace TreeList_Tests.Forms
{
    public partial class TreeListCustomEditor : DevExpress.XtraEditors.XtraForm
    {

        BindingList<Student> sDataSource = new BindingList<Student>();

        public TreeListCustomEditor()
        {
            InitializeComponent();
        }

        private void TreeListCustomEditor_Load(object sender, EventArgs e)
        {
            csUIHelper.InitTreeList(treeList1);
            treeList1.Columns.Clear();
            treeList1.Nodes.Clear();
            treeList1.DataSource = sDataSource;
            treeList1.PopulateColumns();

            //New item row [Default:TreeListNewItemRowPosition.None]
            treeList1.OptionsView.NewItemRowPosition = TreeListNewItemRowPosition.Bottom;


            //Set column editors
            foreach (var col in treeList1.Columns)
            {
                if (col.FieldName == nameof(Student.age))
                {
                    col.ColumnEdit = new RepositoryItemSpinEdit();
                }
                else if (col.FieldName == nameof(Student.image))
                {
                    RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
                    pictureEdit.NullText = " ";//Must leave a space to take effect!!!
                    col.ColumnEdit = pictureEdit;
                }
            }

            //treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;

            //Prepare data
            AddRecords(100);
        }

        private void TreeList1_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            //if (e.Column.FieldName==nameof(Student.age))
            //{
            //    e.Column.ColumnEdit = treelistSpinEdit;
            //}
        }

        private void AddRecords(int iCount)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Restart();
            int iStart = treeList1.Nodes.Count;
            int iEnd = iStart + iCount;

            //Freeze UI
            treeList1.BeginUpdate();

            for (int i = iStart; i < iEnd; i++)
            {
                var student = new Student()
                {
                    name = $"stu_{i}",
                    age = i + 100,
                    id = i + 1000,
                };

                //Set image
                if (i % 2 == 0)
                {
                    student.image = Properties.Resources.AddItem_32x32;
                }
                else if (i % 3 == 0)
                {
                    student.image = Properties.Resources.AddFile_32x32;
                }
                else
                {
                    student.image = null;
                }
 
                sDataSource.Add(student);
            }

            treeList1.MoveLast();
            treeList1.EndUpdate();

            watch.Stop();

            string sMessage = $"Add {iCount},{watch.ElapsedMilliseconds}ms";
            Debug.WriteLine(sMessage);

        }
    }
}