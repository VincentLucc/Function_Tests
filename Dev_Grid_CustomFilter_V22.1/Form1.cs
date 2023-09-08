using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Load filter string
            config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            string sValue = config.AppSettings.Settings["FilterString"].Value;
            this.FormClosed += Form1_FormClosed;

  
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
            filterEditorControl1.FilterString = sValue;

            //Tab Page 2, try to get value without the grid control

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
    }
}
