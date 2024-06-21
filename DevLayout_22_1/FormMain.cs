using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevLayout.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevLayout_22_1
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void CancelButtonControl_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set tabPane navigation button image location
            foreach (IBaseButton button in this.tabPane1.ButtonsPanel.Buttons)
            {
                button.Properties.ImageLocation = DevExpress.XtraEditors.ButtonPanel.ImageLocation.AboveText;
            }
        }

        private void bFluent_Click(object sender, EventArgs e)
        {

        }

        private void bGeneratedForm_Click(object sender, EventArgs e)
        {

        }

        private void CustomFormButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomFormTitleButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var customForm = new CustomizedXtraForm();
            customForm.ShowDialog();
        }

        private void FluentFormBarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FluentDesignForm form1 = new FluentDesignForm();
            form1.Show();
        }

        private void GeneratedFormButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GeneratedForm formGenerated = new GeneratedForm();
            formGenerated.StartPosition = FormStartPosition.CenterScreen;
            formGenerated.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            layoutControlItem11.Visibility = layoutControlItem11.Visibility == 
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always ? 
                DevExpress.XtraLayout.Utils.LayoutVisibility.Never : 
                DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
    }
}
