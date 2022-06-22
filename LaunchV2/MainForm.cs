using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchV2
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (csPublic.IsFormValid(csPublic.winLuanch))
            {
                csPublic.winLuanch.Close();
            }
        }

        public void PreLoadProcess()
        {
            csPublic.messageHelper = new MessageHelper(this);
            csPublic.messageHelper.ShowMainLoading();
            Thread.Sleep(3000);
            csPublic.messageHelper.CloseLoadingForm();
        }
    }
}