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

namespace Dev_GridControl_22_1.Forms
{
    public partial class CollectionSourceForm : Form
    {
        public Stopwatch watch;


        public CollectionSourceForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void CollectionSourceForm_Load(object sender, EventArgs e)
        {
            watch = new Stopwatch();
            watch.Restart();
            this.Disposed += CollectionSourceForm_Disposed;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;

        }

        private void CollectionSourceForm_Disposed(object sender, EventArgs e)
        {
            this.Disposed -= CollectionSourceForm_Disposed;
            this.bDataTableSource.Click -= new System.EventHandler(this.bDataTableSource_Click);
            this.bLoadSamples.Click -= new System.EventHandler(this.bLoadSamples_Click);

            //dt1?.Dispose();
            if (dt1 != null) //Only manual clear works
            {
                dt1.Rows.Clear();
                dt1.Columns.Clear();
                dt1.Dispose();
            }

            gridControl1?.Dispose();
            GC.Collect();
        }

        List<List<string>> stringListRows = new List<List<string>>();
        List<string> stringHeaders = new List<string>();
        private void bLoadSamples_Click(object sender, EventArgs e)
        {
            //Clean up
            stringListRows.Clear();
            stringHeaders.Clear();
            gridControl1.DataSource = null;
  
            //Create header
            for (int i = 0; i < 32; i++)
            {
                stringHeaders.Add($"Column{i.ToString("d2")}");
            }

            //Create list data 
            for (int i = 0; i < 100000; i++)
            {
                List<string> LineFields = new List<string>();
                for (int j = 1; j <= 32; j++)
                {
                    LineFields.Add($"Line:{i.ToString("d8")},Field:{j.ToString("d2")}");
                }

                stringListRows.Add(LineFields);
            }

            csDataGridStringDataSource stringDataSource = new csDataGridStringDataSource(stringListRows, stringHeaders);
            gridControl1.DataSource = stringDataSource;
            gridView1.PopulateColumns();
        }

        public DataTable dt1 = new DataTable();

        private void bDataTableSource_Click(object sender, EventArgs e)
        {
            //Clean up
            dt1.Clear();
            dt1.Columns.Clear();
            gridControl1.DataSource = null;

            for (int i = 1; i <= 32; i++)
            {
                dt1.Columns.Add($"Column{i.ToString("d2")}");
            }

            for (int i = 0; i < 100000; i++)
            {
                var dataRow = dt1.NewRow();
                for (int j = 0; j < 32; j++)
                {
                    dataRow[j] = $"Line_{i.ToString("D8")},Field_{j.ToString("D2")}";
                }

                dt1.Rows.Add(dataRow);
            }

            int iCount = dt1.Rows.Count;
            
            gridControl1.DataSource = dt1;
            gridView1.PopulateColumns();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {

        }


        //public class SampleDataSource
        //{
        //    public string Value0 { get; set; }
        //    public string Value1 { get; set; }
        //    public string Value2 { get; set; }
        //    public string Value3 { get; set; }
        //    public string Value4 { get; set; }
        //    public string Value5 { get; set; }
        //    public string Value6 { get; set; }
        //    public string Value7 { get; set; }
        //    public string Value8 { get; set; }
        //    public string Value9 { get; set; }
        //    public string Value10 { get; set; }
        //    public string Value11{ get; set; }
        //    public string Value12 { get; set; }
        //    public string Value13 { get; set; }
        //    public string Value14 { get; set; }
        //    public string Value15 { get; set; }
        //    public string Value16 { get; set; }
        //    public string Value17 { get; set; }
        //    public string Value18 { get; set; }
        //    public string Value19 { get; set; }
        //    public string Value20 { get; set; }
        //    public string Value21{ get; set; }
        //    public string Value22 { get; set; }
        //    public string Value23{ get; set; }
        //    public string Value24{ get; set; }
        //    public string Value25{ get; set; }
        //    public string Value26{ get; set; }
        //    public string Value27{ get; set; }
        //    public string Value28{ get; set; }
        //    public string Value29{ get; set; }
        //    public string Value30{ get; set; }
        //    public string Value31{ get; set; }
        //    public string Value32{ get; set; }
        //    public string Value33{ get; set; }
        //    public string Value34{ get; set; }
        //    public string Value35{ get; set; }
        //    public string Value36{ get; set; }
        //    public string Value37{ get; set; }
        //    public string Value38{ get; set; }
        //    public string Value39{ get; set; }
        //    public string Value40{ get; set; }
        //    public string Value41{ get; set; }
        //    public string Value42{ get; set; }
        //    public string Value43{ get; set; }
        //    public string Value44{ get; set; }
        //    public string Value45{ get; set; }
        //    public string Value46{ get; set; }
        //    public string Value47{ get; set; }
        //    public string Value48{ get; set; }
        //    public string Value49{ get; set; }
        //    public string Value50{ get; set; }
        //    public string Value51{ get; set; }
        //    public string Value52{ get; set; }
        //    public string Value53{ get; set; }
        //    public string Value54{ get; set; }
        //    public string Value55{ get; set; }
        //    public string Value56{ get; set; }
        //    public string Value57{ get; set; }
        //    public string Value58{ get; set; }
        //    public string Value59{ get; set; }
        //    public string Value60{ get; set; }
        //    public string Value61{ get; set; }
        //    public string Value62{ get; set; }
        //    public string Value63{ get; set; }
        //    public string Value64{ get; set; }
        //    public string Value65{ get; set; }
        //    public string Value66{ get; set; }
        //    public string Value67{ get; set; }
        //    public string Value68{ get; set; }
        //    public string Value69{ get; set; }
        //    public string Value70{ get; set; }

        //    public const string DefaultError = "DefaultError";
        //    public string this[int index]
        //    {
        //        get { return name[index]; }
        //        set { name[index] = value; }
        //    }

        //    private string GetValue(int iIndex)
        //    {
        //        if (iIndex < 0 || iIndex > 70) return DefaultError;

        //        this.GetType().GetProperty("Value"+ iIndex).getin

        //    }
        //}

    }
}
