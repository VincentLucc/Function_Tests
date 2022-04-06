using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
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
    public partial class RejectReasonsForm : Form
    {
        public RejectReasonsForm()
        {
            InitializeComponent();
        }

        private void RejectReasonsForm_Load(object sender, EventArgs e)
        {
            var sampleData = CreateSampleData();
            gridControl1.DataSource = sampleData;


            //Create group
            var deviceColumn = gridView1.Columns[nameof(AuxInfoView.DeviceName)];
      
            deviceColumn.Group();
            deviceColumn.Visible = false;
            //gridView1.OptionsView.ShowGroupedColumns = false; //Hide groupped column
            gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.Default;//Display the summary in column lane
            gridView1.OptionsBehavior.AllowPartialGroups = DefaultBoolean.True;
            gridView1.Appearance.GroupFooter.TextOptions.HAlignment = HorzAlignment.Center;//Center the display
            

            //Set group summaries
            string sNumberColumn = nameof(AuxInfoView.NumberOfTaggedProducts);
            GridGroupSummaryItem item = new GridGroupSummaryItem()
            {
                FieldName = sNumberColumn,
                SummaryType = SummaryItemType.Sum,
                ShowInGroupColumnFooter = gridView1.Columns[sNumberColumn]  //Display location
            };
            gridView1.GroupSummary.Add(item);

            //Set group row value
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;
        }

        private void GridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo groupInfo = e.Info as GridGroupRowInfo;

            //Get summary
            string sDevice=groupInfo.EditValue.ToString();
            List<AuxInfoView> sampleData=(List<AuxInfoView>)gridControl1.DataSource;
            int iSummary= sampleData.Where(i=>i.DeviceName==sDevice).Sum(i=>i.NumberOfTaggedProducts);

            //Set text
            groupInfo.GroupText =$"{sDevice}:(count={iSummary})";
        }

        private List<AuxInfoView> CreateSampleData()
        {
            List<AuxInfoView> infoList = new List<AuxInfoView>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    AuxInfoView info = new AuxInfoView();
                    info.DeviceName = $"Device_{i}";
                    info.TagReason = $"Reason_{j}";
                    info.NumberOfTaggedProducts = i * j;
                    infoList.Add(info);
                }
            }

            return infoList;
        }
    }
}
