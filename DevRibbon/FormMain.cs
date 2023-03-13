using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevRibbon
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            barButtonItem1.ItemClick += BarButtonItem1_ItemClick;

            //Ribbon control
            ribbonControl1.ShowToolbarCustomizeItem = false; //Hide customizing button
            ribbonControl1.ShowApplicationButton = DefaultBoolean.False; //Hide menu button
            ribbonControl1.Minimized = true; //Hide ribbon control;
            //ribbonControl1.Pages[0].Visible = false;
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}
