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

namespace Dev_GridControl_19_1
{
    public partial class RejectReasonsForm : Form
    {
        public RejectReasonsForm()
        {
            InitializeComponent();
        }

        private void RejectReasonsForm_Load(object sender, EventArgs e)
        {
            csPublic.InitGridviewWithDefaultSettings(gridView1);

            var sampleData = CreateSampleData();
            gridControl1.DataSource = sampleData;

            gridView1.OptionsBehavior.Editable = false; //Dsiable user active editor
            gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.False;//Display the summary in column lane
            gridView1.OptionsBehavior.AllowPartialGroups = DefaultBoolean.False; //Hide the group column
            gridView1.Appearance.GroupFooter.TextOptions.HAlignment = HorzAlignment.Center;//Center the display

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false; //Hide row header
            gridView1.OptionsView.ShowFooter = false;

            gridView1.Appearance.GroupFooter.TextOptions.HAlignment = HorzAlignment.Center;//Center the display
            gridView1.Appearance.GroupFooter.Font = new Font(gridView1.Appearance.GroupFooter.Font, FontStyle.Bold);//Set to bold
            gridView1.GroupRowHeight = 20;

            //Create group
            var deviceColumn = gridView1.Columns[nameof(AuxInfoView.DeviceName)];
            deviceColumn.Group();
            deviceColumn.Visible = false;

            //Set common properties
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
            {
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }

            //Set group row value
            gridView1.CustomDrawGroupRow += GridView1_CustomDrawGroupRow;
            gridView1.SelectionChanged += GridView1_SelectionChanged;
        }

        private void GridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridView1.ClearSelection();
        }


        private void GridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo groupInfo = e.Info as GridGroupRowInfo;

            //Get summary
            string sDevice = groupInfo.EditValue.ToString();
            List<AuxInfoView> sampleData = (List<AuxInfoView>)gridControl1.DataSource;
            int iSummary = sampleData.Where(i => i.DeviceName == sDevice).Sum(i => i.NumberOfTaggedProducts);

            //Set text
            groupInfo.GroupText = $"{sDevice}  ({iSummary})";
        }

        private List<AuxInfoView> CreateSampleData()
        {
            List<AuxInfoView> infoList = new List<AuxInfoView>();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
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
