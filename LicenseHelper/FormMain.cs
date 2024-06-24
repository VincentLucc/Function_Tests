using DevExpress.XtraEditors;
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

namespace LicenseHelper
{
    public partial class FormMain : XtraForm
    {
        public bool isLoad;
        csLicenseHelper licenseHelper = new csLicenseHelper();
        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            licenseHelper.AppStart(20);

            isLoad = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowLicenseInfo();
        }

        private void ShowLicenseInfo()
        {
            try
            {
                if (licenseHelper.IsLicensed)
                {
                    LicenseStaticItem.Caption = "Licensed";
                }
                else
                {
                    var timeSpan = licenseHelper.GetTimeLeft();
                    if (timeSpan > TimeSpan.Zero)
                    {
                        LicenseStaticItem.ItemAppearance.Normal.ForeColor = Color.Brown;
                        LicenseStaticItem.Caption = $"Unregistered: {licenseHelper.GetTimeLeft().ToString("mm':'ss")}";
                    }
                    else
                    {
                        LicenseStaticItem.ItemAppearance.Normal.ForeColor = Color.Red;
                        LicenseStaticItem.Caption = "Unregistered";
                    }               
                }
            }
            catch (Exception ex)
            {

                Trace.WriteLine($"ShowLicenseInfo.Exception:\r\n{ex.Message}");
            }

        }

        private void CreateIDButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sDisk = csSystemInfo.FirstHardDriveID;
            licenseHelper.CreateLicense( sDisk );
        }
    }
}
