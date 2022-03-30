using DevExpress.XtraBars.Docking2010.Views.Widget;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WidgetView widgetView = new WidgetView();

            //Add view to 
            documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager();
            documentManager1.View = widgetView;
            var uc1 = new uc1();
            widgetView.Documents.Clear();
            widgetView.AddDocument(uc1);
            var doc1 = widgetView.Documents[0] as Document;
            doc1.Caption = "Test1";
            // Handling the QueryControl event that will populate all automatically generated Documents
            //this.tabbedView1.QueryControl += tabbedView1_QueryControl;
        }

        // Assigning a required content for each auto generated Document
        void tabbedView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            //if (e.Document == uc2Document)
            //    e.Control = new DocumentManager.Controls.uc2();
            //if (e.Document == uc1Document)
            //    e.Control = new DocumentManager.Controls.uc1();
            //if (e.Control == null)
            //    e.Control = new Control();


        }
    }
}
