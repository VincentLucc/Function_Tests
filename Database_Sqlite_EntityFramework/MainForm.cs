using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Sqlite_EntityFramework
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!csSqlHelper.CreateDataBase(out string sMessage))
            {
                MessageBox.Show(sMessage);
                return;
            }
        }

        private void bInitConnection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!csSqlHelper.ConnectOrCreate(createDatabase: false, out string sMessage))
            {
                MessageBox.Show(sMessage);
                return;
            }
        }
    }
}