using DevExpress.XtraEditors;
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
    public partial class UnBoundForm : DevExpress.XtraEditors.XtraForm
    {
        List<Student> students;

        public UnBoundForm()
        {
            InitializeComponent();
        }

        private void UnBoundForm_Load(object sender, EventArgs e)
        {
            InitTreeList();
            InitStudents();
            LoadUnBoundData();
        }

        private void InitTreeList()
        {
            treeList1.Columns.AddVisible(nameof(Student.name));
            treeList1.Columns.AddVisible(nameof(Student.id));
            treeList1.Columns.AddVisible(nameof(Student.age));
            var colEnable= treeList1.Columns.AddVisible(nameof(Student.Enable));
            colEnable.UnboundDataType = typeof(bool);

            treeList1.CellValueChanged += TreeList1_CellValueChanged;
            treeList1.CellValueChanging += TreeList1_CellValueChanging;
        }

        private void TreeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            Debug.WriteLine("TreeList1_CellValueChanging");

            //Directly push value to source to avoid value lose when column visible index changed           
            //Checkbox data won't be saved to source until lose focus, this will cause data lose when update column index
            //Set other type such as text edit will trigger edit reload, this will interupt user input 
            if (e.Value is bool)
            {
                e.Node.SetValue(e.Column, e.Value);
            }
        }

        /// <summary>
        /// Only update column
        /// </summary>
        private void UpdateColumnVisibleIndex()
        {
            foreach (var col in treeList1.Columns)
            {
                if (col.FieldName == nameof(Student.Enable))
                {
                    col.VisibleIndex = 3;
                }
            }
        }

        private void TreeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            Debug.WriteLine("TreeList1_CellValueChanged");
            UpdateColumnVisibleIndex();
        }

        private void LoadUnBoundData()
        {
            for (int i = 0; i < students.Count; i++)
            {
                var node = GetNodeData(students[i]);
                treeList1.AppendNode(node, null);
            }
        }

        /// <summary>
        /// Prepare treelistnode data for creating a new node
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        private object[] GetNodeData(Student stu)
        {
            object[] value;

            //Reference
            value = new object[] { stu.name, stu.id, stu.age, stu.Enable };


            return value;
        }

        private void InitStudents()
        {
            students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                var stu = new Student()
                {
                    id = i,
                    age = i,
                    name = "Stu" + i.ToString("D3"),
                };
                students.Add(stu);
            }
        }
    }
}