using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUserControls
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }



        

        private void MainForm_Load(object sender, EventArgs e)
        {

            InitLookUpControl();

        }

        private void InitLookUpControl()
        {
            List<csUserControlItem> Items = new List<csUserControlItem>();

            //Item1
            var view01 = new View01UserControl();
            Items.Add(new csUserControlItem(view01, "Test01"));

            //Item2
            var view02 = new View01UserControl();
            Items.Add(new csUserControlItem(view02, "Inherit Layouts"));



            lookUpEdit1.Properties.DisplayMember = nameof(csUserControlItem.DisplayName);
            lookUpEdit1.Properties.ValueMember = nameof(csUserControlItem.UserControl);
            lookUpEdit1.Properties.DataSource = Items;


        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (!(lookUpEdit1.EditValue is XtraUserControl)) return;
            ContentPanelControl.Controls.Clear();
            var userControl = lookUpEdit1.EditValue as XtraUserControl;
            userControl.Dock = DockStyle.Fill;
            ContentPanelControl.Controls.Add(userControl);

        }
    }
}
