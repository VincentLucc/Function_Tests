using DevExpress.XtraBars.Docking2010.Views.Widget;
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
    public partial class WidgetViewDynamic : DevExpress.XtraEditors.XtraForm
    {
        public WidgetViewDynamic()
        {
            InitializeComponent();
        }



        private void WidgetView_Load(object sender, EventArgs e)
        {
            //Base settings
            widgetView1.DocumentProperties.ShowCloseButton = false;


            //Prepare documents
            for (int i = 0; i < 6; i++)
            {
                var doc = CreateDocument(i); //Set document location
                widgetView1.Documents.Add(doc);
            }


            // Handling the QueryControl event that will populate all automatically generated Documents
            this.widgetView1.QueryControl += widgetView1_QueryControl;
        }


        private Document CreateDocument(int iIndex)
        {
            //Init variables
            Document doc = new Document();

            //Init document info
            doc.Caption = $"Device {iIndex+1}";
            doc.RowSpan = 2;
            doc.ColumnSpan = 2;


            //Row total
            int iTotal = (widgetView1.Rows.Count / 2) * (widgetView1.Columns.Count / 2);

            //Set row, column location
            if (iIndex < iTotal)
            {
                doc.ColumnIndex = (iIndex % 4) * 2;
                doc.RowIndex = (iIndex / 4) * 2;
            }

            return doc;
        }

        // Assigning a required content for each auto generated Document
        void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            this.SuspendLayout();

            if (e.Document == widgetView1.Documents[0])
                e.Control = new uc1();

            if (e.Document == widgetView1.Documents[1])
                e.Control = new uc2();

            if (e.Document == widgetView1.Documents[2])
                e.Control = new UC3();

            if (e.Document == widgetView1.Documents[3])
                e.Control = new uc1();

            if (e.Document == widgetView1.Documents[4])
                e.Control = new uc2();

            if (e.Document == widgetView1.Documents[5])
                e.Control = new UC3();

            if (e.Control == null)
                e.Control = new Control();

            this.ResumeLayout();
        }
    }
}