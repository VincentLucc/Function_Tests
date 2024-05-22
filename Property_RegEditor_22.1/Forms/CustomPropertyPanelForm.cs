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

namespace Property_RegEditor_22._1.Forms
{
    public partial class CustomPropertyPanelForm : DevExpress.XtraEditors.XtraForm
    {
        csPropertyHelper propertyHelper;
        public CustomPropertyPanelForm()
        {
            InitializeComponent();
            InitMainEvents();
        }

        private void InitMainEvents()
        {
            this.Load += CustomPropertyPanelForm_Load;
        }

        private void CustomPropertyPanelForm_Load(object sender, EventArgs e)
        {
            //Init grid control
            propertyHelper = new csPropertyHelper(propertyGridControl1);
            
        }

        public void UpdateSelection(object selection)
        {


            propertyHelper.propertyGrid.SelectedObject = selection;
        }
    }
}