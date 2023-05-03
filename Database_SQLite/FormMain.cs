using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database_SQLite
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bCreateDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            csSqlHelper.InitDataBase();
        }
    }
}
