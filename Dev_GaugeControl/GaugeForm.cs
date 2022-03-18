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

namespace Dev_GaugeControl
{
    public partial class GaugeForm : DevExpress.XtraEditors.XtraForm
    {
        public GaugeForm()
        {
            InitializeComponent();
            this.Load += GaugeForm_Load;
        }

        private void GaugeForm_Load(object sender, EventArgs e)
        {
            documentManager1.View.Documents.Clear();
            ucGauge1 gauge1 = new ucGauge1();
            var docGauge1=documentManager1.View.AddDocument(gauge1);
            docGauge1.Caption = "Test Name";
        
        }
    }
}