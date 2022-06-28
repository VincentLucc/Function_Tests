using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using Docking.Controls;
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
    public partial class DocumentManagerWidgetViewForm : DevExpress.XtraEditors.XtraForm
    {
        public DocumentManagerWidgetViewForm()
        {
            InitializeComponent();
            this.Load += DocumentManagerWidgetViewForm_Load;
        }

        private void DocumentManagerWidgetViewForm_Load(object sender, EventArgs e)
        {
            //Set properties
            widgetView1.DocumentProperties.AllowDragging = false; //Disable dragging
            widgetView1.DocumentProperties.AllowMaximize = false; //Maximum button and click action
            widgetView1.DocumentProperties.AllowFloat = false;
            widgetView1.DocumentProperties.ShowCloseButton = false; //close button and action


            widgetView1.BeginUpdate();
            widgetView1.Columns.Clear();
            widgetView1.Rows.Clear();
           
            //Init columns/rows
            for (int i = 0; i < 3; i++)
            {
                widgetView1.Columns.AddColumn();
                widgetView1.Rows.AddRow();
            }

            //Create documents
            Document doc = new Document();
            doc.Caption = "Test1";
            doc.ColumnIndex = 1;
            doc.RowIndex = 2;
            widgetView1.Documents.Add(doc);

            widgetView1.QueryControl += WidgetView1_QueryControl;

            widgetView1.EndUpdate();
        }

        private void WidgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Document.Caption=="")
            {
                e.Control= new Control();
            }

            if (e.Control == null)
                e.Control = new ucCenter();
        }
    }
}