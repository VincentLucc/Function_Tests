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

        const string sIDField = "N#";

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
                    Student s = new Student() { Age = j + 1, Name = $"Class_{i}_ID_{j + 1}", Class = $"Class{i}" };
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
            gridView1.OptionsView.ShowGroupPanel = true; //User don't see group panel
            gridView1.GroupRowHeight = 50;
            //gridView1.OptionsDetail.EnableMasterViewMode = true;
            //gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.False;//Display the summary in column lane,Key settings to hide the groupped column
            gridView1.OptionsBehavior.AllowPartialGroups = DefaultBoolean.False; //Hide device name

            //Create group summary
            var classColumn = gridView1.Columns[nameof(Student.Class)];
            classColumn.Group();
            classColumn.Visible = false;
 
            //Set group extra column value
            //gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            //{
            //    FieldName = nameof(Student.Age), //Value name
            //    SummaryType = SummaryItemType.Sum,
            //    ShowInGroupColumnFooter = gridView1.Columns[nameof(Student.Name)] //Display location
            //});

            //Set group row value
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;

            //Add row index display 
            var columnID = gridView1.Columns.AddField(sIDField);
            columnID.VisibleIndex = 0;
            columnID.Visible = true;
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;


            //Start a update timer
            Timer t1 = new Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == sIDField)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }



        private void GridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo groupInfo = e.Info as GridGroupRowInfo;
            groupInfo.GroupText += ":Test Text TEst";

        }

        private void T1_Tick(object sender, EventArgs e)
        {
            ViewData[0].Age += 1;
            var list = ViewData.ToList();
            list[0].Name = $"haha{ ViewData[0].Age}";
            ViewData = list;
            gridControl1.RefreshDataSource();
        }
    }
}
