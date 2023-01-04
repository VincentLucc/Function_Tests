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
    public partial class WidgetView : DevExpress.XtraEditors.XtraForm
    {
        uc1 uc01 = new DocumentManager.uc1();
        uc2 uc02 = new DocumentManager.uc2();
        UC3 uc03 = new DocumentManager.UC3();

        public WidgetView()
        {
            InitializeComponent();

            // Handling the QueryControl event that will populate all automatically generated Documents
            this.widgetView1.QueryControl += widgetView1_QueryControl;
        }



        private void WidgetView_Load(object sender, EventArgs e)
        {

        }

        // Assigning a required content for each auto generated Document
        void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {


            bool bUseNew = true;

            if (bUseNew)
            {
                if (e.Document == uc1Document)
                    e.Control = new DocumentManager.uc1();

                if (e.Document == uc2Document)
                    e.Control = new DocumentManager.uc2();

                if (e.Document == uC3Document)
                    e.Control = new DocumentManager.UC3();
            }
            else
            {
                if (e.Document == uc1Document)
                    e.Control = uc01;

                if (e.Document == uc2Document)
                    e.Control = uc02;

                if (e.Document == uC3Document)
                    e.Control = uc03;
            }

            if (e.Control == null)
                e.Control = new System.Windows.Forms.Control();
        }
    }
}