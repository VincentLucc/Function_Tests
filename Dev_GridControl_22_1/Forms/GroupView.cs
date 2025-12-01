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
using DevExpress.XtraGrid.Views.Grid;

namespace Dev_GridControl_22_1
{
    public partial class GroupView : Form
    {

        const string sIDField = "N#";

        List<Student> students = new List<Student>();
        private List<GroupOperation> groupOperations = new List<GroupOperation>();

        public GroupView()
        {
            InitializeComponent();
        }




        public static List<Student> ViewData;

        private List<Student> GenerateData()
        {
            students = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                //Create group data
                groupOperations.Add(new GroupOperation()
                { GroupName = $"Class{i}", Operation = _groupOperation.And });

                for (int j = 0; j < 4; j++)
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
            csPublic.InitGridview(gridView1);

            //Set grid control customized settings
            gridView1.OptionsView.ShowGroupPanel = true; //User don't see group panel

            gridView1.RowHeight = 30;
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



            //Add row index display 
            var columnID = gridView1.Columns.AddField(sIDField);
            columnID.VisibleIndex = 0;
            columnID.Visible = true;
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;


            //Disable collapsing
            gridView1.ExpandAllGroups();
            gridView1.GroupRowCollapsing += (gridView, collapseArgs) =>
            {
                collapseArgs.Allow = false;
            };


            //Group row
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;
            gridView1.RowCellClick += GridView1_RowCellClick;
            gridView1.RowClick += GridView1_RowClick;

            //Group draw mode: 没看出什么区别
            //[GroupDrawMode.Default]
            gridView1.OptionsView.GroupDrawMode = GroupDrawMode.Office;


            //Start a update timer
            Timer t1 = new Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void GridView1_RowClick(object sender, RowClickEventArgs e)
        {
            var hitInfo = gridView1.CalcHitInfo(e.Location);
            if (hitInfo.InGroupRow)
            {
                //Get group index
                if (hitInfo.HitTest is GridHitTest.Row && hitInfo.RowInfo is GridGroupRowInfo groupRowInfo)
                {
                    var groupOperation = groupOperations.FirstOrDefault(a => a.GroupName == groupRowInfo.GroupValueText);
                    if (groupOperation != null)
                    {
                        switch (groupOperation.Operation)
                        {
                            case _groupOperation.And:
                                groupOperation.Operation = _groupOperation.Or;
                                break;
                            case _groupOperation.Or:
                                groupOperation.Operation = _groupOperation.And;
                                break;
                        }
                    }

                }
            }
        }



        /// <summary>
        /// Won't trigger by the group area click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var hitInfo = gridView1.CalcHitInfo(e.Location);
            if (hitInfo.InGroupRow)
            {
            }
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

            bool CustomPaint = true;


            if (e.Info is GridGroupRowInfo groupRowInfo)
            {
                //Init
                //Reference: {X = 1 Y = 67 Width = 781 Height = 50}
                var groupRowBounds = groupRowInfo.DataBounds; //Whole line of the group row
                //Reference: {X = 6 Y = 85 Width = 13 Height = 13}
                var expandButtonBounds = groupRowInfo.ButtonBounds; //Button Area
                //Reference: {X = 1 Y = 67 Width = 781 Height = 51} (Similar size with the data bounds)
                var textBounds = e.Bounds; //Text Area

                //Get the group operation
                string sOperation = string.Empty;
                var groupOperation = groupOperations.FirstOrDefault(a => a.GroupName == groupRowInfo.GroupValueText);
                if (groupOperation != null)
                {
                    sOperation = $"[Logic: {groupOperation.Operation.ToString()}]";
                }

                if (CustomPaint)
                {
                    //Draw text
                    groupRowInfo.Appearance.DrawString(e.Cache, $"Test {sOperation}", textBounds);

                    //Draw button
                    //expandButtonBounds.X = textBounds.X + 50;
                    //expandButtonBounds.Width = 100;//Default width is only 13, will cut text
                    //groupRowInfo.Appearance.DrawString(e.Cache, $"Test{sOperation}", expandButtonBounds);

                    //Cancel default paint
                    e.Handled = true;
                }
                else
                {//Modify with default paint

                    //Group text
                    groupRowInfo.GroupText = $"Group[{groupRowInfo.GroupValueText}]";
                }

            }

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
