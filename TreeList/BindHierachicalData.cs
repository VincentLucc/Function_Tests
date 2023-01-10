using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeList
{
    public partial class BindHierachicalData : DevExpress.XtraEditors.XtraForm
    {

        public BindingList<Student4Tree> Classes = new BindingList<Student4Tree>();

        public BindHierachicalData()
        {
            InitializeComponent();
        }

        private void PartialModification_Load(object sender, EventArgs e)
        {
            treeList1.KeyFieldName = nameof(StudentTree.TreeID);
            treeList1.ParentFieldName = nameof(StudentTree.TreeParentID);

            for (int i = 0; i < 3; i++)
            {
                var sItem = new Student4Tree();
                sItem.Name = $"Main_{i}";

                for (int j = 0; j < 3; j++)
                {
                    var stu = new Student4Tree()
                    {
                        Name = $"S_{i}"
                    };

                    sItem.students.Add(stu);
                }

                Classes.Add(sItem);
            }

            treeList1.ChildListFieldName = nameof(Student4Tree.students);
            treeList1.DataSource = Classes;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            //if (treeList1.FocusedNode != null)
            //{
            //    //Get node parent
            //    var parentID = (int)treeList1.FocusedNode.GetValue(nameof(StudentTree.TreeID));

            //    var newItem = new StudentTree()
            //    {
            //        TreeID = students.Count,
            //        TreeParentID = parentID,
            //        Icon = imageCollection1.Images[0],
            //        name = $"Add_{students.Count}"
            //    };

            //    //Directly add
            //    students.Add(newItem);
            //    treeList1.RefreshDataSource();
            //}


        }

        private void GetValidID()
        {

        }

        private void AddNode_Click(object sender, EventArgs e)
        {
            //if (treeList1.FocusedNode != null)
            //{
            //    //Get node parent
            //    var parentID = (int)treeList1.FocusedNode.GetValue(nameof(StudentTree.TreeID));

            //    var newItem = new StudentTree()
            //    {
            //        TreeID = students.Count,
            //        TreeParentID = parentID,
            //        Icon = imageCollection1.Images[0],
            //        name = $"Add_{students.Count}"
            //    };

            //    //Directly add
            //    //treeList1.FocusedNode.Nodes.Add(newItem);
            //    var nodeValues = new object[] { newItem.TreeID, newItem.TreeParentID, newItem.Icon, newItem.name, newItem.id, newItem.age }; //Tree node only accept this
            //    //treeList1.AppendNode(nodeValues, treeList1.FocusedNode);//Same effects
            //    treeList1.FocusedNode.Nodes.Add(nodeValues);
            //}

        }
    }


    /// <summary>
    /// Must define a class like this to directly show the structure
    /// </summary>
    public class Student4Tree
    {

        public string Name { get; set; }

        public List<Student4Tree> students { get; set; }

        public Student4Tree()
        {
            students = new List<Student4Tree>();
        }
    }
}