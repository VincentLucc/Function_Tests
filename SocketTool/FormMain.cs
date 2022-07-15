using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocketTool
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.LookAndFeel.SetSkinStyle(SkinStyle.WXI);
        }
    }
}