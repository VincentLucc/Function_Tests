using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsageLog.UserControls;

namespace UsageLog
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {


        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RecordsUserControl recordControl=new RecordsUserControl();
   
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(recordControl);

        }


     


    }
}