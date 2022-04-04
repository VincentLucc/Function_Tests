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

namespace Docking
{
    public partial class DockManagerDocking : XtraForm
    {
        public DockManagerDocking()
        {
            InitializeComponent();
            // Handling the QueryControl event that will populate all automatically generated Documents
            this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        private void DockManagerDocking_Load(object sender, EventArgs e)
        {
            tabbedView1.DocumentGroupProperties.ShowTabHeader = false; //Hide header
            dockManager2.DockingOptions.ShowCaptionOnMouseHover = true; //hide captain, only display when mouse over
        }

        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (e.Document == ucCenterDocument)
                e.Control = new Docking.Controls.ucCenter();
            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }
    }
}
