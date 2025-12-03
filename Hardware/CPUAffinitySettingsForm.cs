using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace Hardware
{
    public partial class CPUAffinitySettingsForm : DevExpress.XtraEditors.XtraForm
    {
        private csDevMessage messageHelper;
        private List<csCoreSetting> coreSettings = new List<csCoreSetting>();
        private int iCoreCount = -1;


        public CPUAffinitySettingsForm()
        {
            InitializeComponent();
        }

        public CPUAffinitySettingsForm(bool[] bSettings)
        {
            InitializeComponent();
            LoadSettings(bSettings);
        }



        private void CPU_Affinity_Settings_Load(object sender, EventArgs e)
        {
            //Init
            messageHelper = new csDevMessage(this);


            //Get number of the CPU cores
            iCoreCount = csCPUHelper.GetPhysicalCoreCount();
            if (iCoreCount < 2)
            {
                messageHelper.Info("Minimum 2 cores are required for affinity settings.");
                this.Close();
                return;
            }

            //Grid
            csPublic.InitGridview(gridView1, true);
            csPublic.SetGridViewAlignment(gridView1, HorzAlignment.Center, HorzAlignment.Near);
            gridControl1.DataSource = coreSettings;
            //Columns
            gridView1.PopulateColumns();
            foreach (GridColumn gridCOlumn in gridView1.Columns)
            {
                if (gridCOlumn.FieldName == nameof(csCoreSetting.Name))
                {
                    gridCOlumn.OptionsColumn.AllowEdit = false;
                }
            }

            gridView1.CustomRowFilter += GridView1_CustomRowFilter;
        }

        private void LoadSettings(bool[] bSettings)
        {
            //Create core settings
            coreSettings.Clear();
            for (int i = 0; i < bSettings.Length; i++)
            {
                coreSettings.Add(new csCoreSetting()
                {
                    Name = $"Core {(i + 1).ToString("d2")}",
                    Enable = bSettings[i]
                });
            }
        }

        private void GridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            if (e.ListSourceRow >= iCoreCount)
            {
                e.Visible = false;
                e.Handled = true; // Mark as handled
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            //Verification
            var enabledCores = coreSettings.Where((v, i) => (v.Enable && i < iCoreCount)).ToList();
            if (enabledCores.Count < 2)
            {
                messageHelper.Info("Minimum 2 cores are required for affinity settings.");
                return;
            }

            //Apply settings
            var standardSettings = ConvertToStardardCoreSettings();
            if (!csCPUHelper.SetProcessAffinity(standardSettings, out string sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }


            this.Close();
        }


        public bool[] ConvertToStardardCoreSettings()
        {
            bool[] bSettings = new bool[64];

            for (int i = 0; i < coreSettings.Count; i++)
            {
                if (i > bSettings.Length - 1) break;
                bSettings[i] = coreSettings[i].Enable;
            }

            return bSettings;
        }




        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (var coreSetting in coreSettings)
            {
                coreSetting.Enable = true;
            }

            gridControl1.RefreshDataSource();
        }

        private void SelectMiniumButton_Click(object sender, EventArgs e)
        {
            var enabled = coreSettings.Where(a => a.Enable).ToList();
            if (enabled.Count >= 2)
            {//Only enable 2 cores
                for (int i = 0; i < enabled.Count; i++)
                {
                    var coreSetting = enabled[i];
                    coreSetting.Enable = i < 2;
                }
            }
            else
            {//Enable first two cores
                for (int i = 0; i < coreSettings.Count; i++)
                {
                    var coreSetting = coreSettings[i];
                    coreSetting.Enable = i < 2;
                }
            }

            gridControl1.RefreshDataSource();
        }


    }

    public class csCoreSetting
    {
        public string Name { get; set; }
        public bool Enable { get; set; }
    }
}