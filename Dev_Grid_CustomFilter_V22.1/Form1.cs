using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Dev_Grid_CustomFilter_V22._1
{
    public partial class Form1 : Form
    {

        Configuration config;

        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Load filter string
            config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);


            InitFilterEditorWithGridControl();
            InitStandaloneFilterEditor();

        }

        private void InitStandaloneFilterEditor()
        {   //Tab Page 2, try to get value without the grid control
            filterEditorControlNull.ApplyFilter();
            //Allow to set right as column
            filterEditorControlNull.FilterControl.ShowOperandTypeIcon = true;//Allow to set right value area as column

            //Create columns
            CreateFilterColumns(FilterColumnClauseClass.String, "Name");
            CreateFilterColumns(FilterColumnClauseClass.Lookup, "Age");

            filterEditorControlNull.FilterControl.InitNode += FilterControl_InitNode;
            filterEditorControlNull.FilterControl.PopupMenuShowing += FilterControl_PopupMenuShowing;
            //Only set the value type not the column type
            filterEditorControlNull.FilterControl.CustomValueEditor += FilterControl_CustomValueEditor;
            filterEditorControlNull.FilterControl.ItemClick += FilterControl_ItemClick;
        }

        private void FilterControl_ItemClick(object sender, DevExpress.Utils.Frames.LabelInfoItemClickEventArgs e)
        {
            Debug.WriteLine("FilterControl_ItemClick:" + e.InfoText);


        }

        /// <summary>
        /// Don't trigger when value type is column 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterControl_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            //   e.RepositoryItem = new RepositoryItemSpinEdit();
            Debug.WriteLine("FilterControl_CustomValueEditor:\r\n" + e.PropertyName);
        }

        private void CreateFilterColumns(FilterColumnClauseClass dataType, string sCaptain, string sFieldName = null)
        {
            if (string.IsNullOrWhiteSpace(sFieldName))
                sFieldName = sCaptain;
            //Can customize the editor
            //new RepositoryItemSpinEdit()
            //filterEditorControlNull.FilterColumns.Add(new UnboundFilterColumn("Age", "Field2", typeof(int), new RepositoryItemSpinEdit(), FilterColumnClauseClass.Generic));
            filterEditorControlNull.FilterColumns.Add(new UnboundFilterColumn(sCaptain, sFieldName, typeof(int), null, dataType));
        }

        private void FilterControl_InitNode(object sender, DevExpress.XtraEditors.Filtering.InitNodeEventArgs e)
        {
            //Force to set the new type
            e.SetOperation(ClauseType.Equals);
            //Debug
            Debug.WriteLine($"InitNode:{e.PropertyType}.{e.PropertyName}");
        }

        private void FilterControl_PopupMenuShowing(object sender, DevExpress.XtraEditors.Filtering.PopupMenuShowingEventArgs e)
        {
            //Limit the number of popup menus
            //See reference
            //https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.FilterControl.PopupMenuShowing

            //Group operator menu (And, or...)
            if (e.MenuType == FilterControlMenuType.Group)
            {
                e.Menu.Hide(GroupType.NotAnd);
                e.Menu.Hide(GroupType.NotOr);
            }
            //Group command menu (Add condition, add group)
            else if (e.MenuType == FilterControlMenuType.NodeAction)
            {

            }
            //Field (column) menu 
            else if (e.MenuType == FilterControlMenuType.Column)
            {
                e.Cancel = true;

                //Hide column selection
                //Show customize options instead
                contextMenuStrip1.Show(filterEditorControlNull, new Point());

            }
            //Column operator
            else if (e.MenuType == FilterControlMenuType.Clause)
            {
                //Select allowed options
                List<ClauseType> visibleClause = new List<ClauseType>();
                visibleClause.Add(ClauseType.Equals);
                visibleClause.Add(ClauseType.Greater);
                visibleClause.Add(ClauseType.Less);

                //Hide irrelevent options
                var allClause = Enum.GetValues(typeof(ClauseType));
                foreach (ClauseType item in allClause)
                {
                    if (!visibleClause.Contains(item))
                    {
                        e.Menu.Hide(item);
                    }
                }

            }

        }

        private void InitFilterEditorWithGridControl()
        {
            //Tab page 1
            filterEditorControl1.SourceControl = gridControl1;
            filterEditorControl1.ViewMode = FilterEditorViewMode.VisualAndText;
            filterEditorControl1.AllowAggregateEditing = FilterControlAllowAggregateEditing.AggregateWithCondition;

            //Create a fake table
            DataTable table = new DataTable();
            table.Columns.Add("Tool Name");
            table.Columns.Add("Value 1");
            table.Columns.Add("Value 2");
            table.Columns.Add("Value 3");
            table.Columns.Add("Value 4");
            table.Columns.Add("Value 5");
            table.Columns.Add("List");

            //Must have value to make sure the syntax works
            table.Rows.Add(new object[] { 0, 1, 2, 3, 4, 5, new List<string>() { "a", "b", "c" } });
            gridView1.Columns.Clear();
            gridControl1.DataSource = table;
            string sValue = config.AppSettings.Settings["FilterString"].Value;
            filterEditorControl1.FilterString = sValue;
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sValue = filterEditorControl1.FilterString;
            SaveFilter(sValue);
        }

        private void SaveFilter(string sValue)
        {
            //Save settings
            config.AppSettings.Settings["FilterString"].Value = sValue;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            var col = gridView1.Columns["Tool Name"];

            gridView1.FilterEditorCreated -= GridView1_FilterEditorCreated;
            gridView1.FilterEditorCreated += GridView1_FilterEditorCreated;
            gridView1.ShowFilterEditor(col);
        }

        private void GridView1_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
            e.FilterBuilder.Text = "Edit Logic";//Set title

        }

        private void GetResultButton_Click(object sender, EventArgs e)
        {
            string sValue = filterEditorControl1.FilterString;
            MessageBox.Show(sValue);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
