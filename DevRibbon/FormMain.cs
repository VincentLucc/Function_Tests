using DevExpress.LookAndFeel;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;

namespace DevRibbon
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        csDevMessage messageHelepr;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init variables
            messageHelepr = new csDevMessage(this);
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier);

            barButtonItem1.ItemClick += BarButtonItem1_ItemClick;

            //Ribbon control
            bool HideRibbon = false;
            if (HideRibbon)
            {
                ribbonControl1.ShowToolbarCustomizeItem = false; //Hide customizing button
                ribbonControl1.ShowApplicationButton = DefaultBoolean.False; //Hide menu button
                ribbonControl1.Minimized = true; //Hide ribbon control;
                                                 //ribbonControl1.Pages[0].Visible = false;

            }

            //this.GetCaptionHeight();
            //this.CalcCaptionHeight();
        }

        protected override int CalcCaptionHeight()
        {
            return this.FormPainter == null || this.Ribbon == null || !this.Ribbon.Visible && this.IsMdiChild || !this.Ribbon.ViewInfo.IsAllowCaption ? 0 : this.Ribbon.ViewInfo.Caption.CalcCaptionHeight();
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void bMessageBox_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            messageHelepr.Info("Test Info Message");
        }

        private void bWarning_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            messageHelepr.Warning("Test Warning Message");
        }

        private void bError_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            messageHelepr.Error("Test Error Message");
        }
    }
}
