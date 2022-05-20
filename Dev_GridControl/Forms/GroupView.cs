using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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

namespace Dev_GridControl
{
    public partial class GroupView : Form
    {
        public GroupView()
        {
            InitializeComponent();
        }


        public static List<Student> ViewData;

        private List<Student> GenerateData()
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Student s = new Student() { Age = j + 1, Name = $"Class_{i}_ID_{j+1}",Class = $"Class{i}"};
                    s.DescriptionInfo = "TestAbc";
                    students.Add(s);
                }
            }
            return students;
        }

        private void GroupView_Load(object sender, EventArgs e)
        {
            ViewData = GenerateData();
            gridControl1.DataSource = ViewData;

            //Avoid auto spacing for column captains
            foreach (GridColumn column in gridView1.Columns)
            {
                column.Caption = column.FieldName;
            }


            //Init view with default settings
            csPublic.InitGridviewWithDefaultSettings(gridView1);

            //Set grid control customized settings
            gridView1.GroupRowHeight = 50;

            //Create group summary
            gridView1.Columns[nameof(Student.Class)].Group();

            //Set group extra column value
            gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = nameof(Student.Age), //Value name
                SummaryType = SummaryItemType.Sum,
                ShowInGroupColumnFooter = gridView1.Columns[nameof(Student.Name)] //Display location
            }) ;

            //Set group row value
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;

            //Start a update timer
            Timer t1 = new Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void GridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo groupInfo = e.Info as GridGroupRowInfo;
            groupInfo.GroupText += ":Test Text TEst";

        }

        private void T1_Tick(object sender, EventArgs e)
        {
            ViewData[0].Age += 1;
            var list= ViewData.ToList();
            list[0].Name = $"haha{ ViewData[0].Age}";
            ViewData = list;
            gridControl1.RefreshDataSource();
        }
    }
}
