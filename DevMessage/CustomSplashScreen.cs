using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DevMessage
{
    public partial class CustomSplashScreen : SplashScreen
    {
        public CustomSplashScreen()
        {
            InitializeComponent();
            this.Load += CustomSplashScreen_Load;
        }

        private void CustomSplashScreen_Load(object sender, EventArgs e)
        {
            UIHelper.InitGridview(gridView1);
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}