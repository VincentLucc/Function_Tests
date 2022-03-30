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

namespace DocumentManager
{
    public partial class TabbedView : DevExpress.XtraEditors.XtraForm
    {
        public TabbedView()
        {
            InitializeComponent();

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

    
        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == uc2Document)
                e.Control = new DocumentManager.uc2();
            if (e.Document == uC3Document)
                e.Control = new DocumentManager.UC3();
            if (e.Document == uc1Document)
                e.Control = new DocumentManager.uc1();
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }
    }
}