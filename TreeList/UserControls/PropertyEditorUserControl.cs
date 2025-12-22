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
using DevExpress.XtraTreeList;
using Property_RegEditor_22._1;

namespace TreeList_Tests
{
    public partial class PropertyEditorUserControl : EditFormUserControl
    {
        csPropertyHelper propertyHelper;
        public PropertyEditorUserControl()
        {
            InitializeComponent();

            //Init grid control
            propertyHelper = new csPropertyHelper(propertyGridControl1);

            //Init Events
            this.Load += PropertyEditorUserControl_Load;
        }

        private void PropertyEditorUserControl_Load(object sender, EventArgs e)
        {

        }

        public void UpdateSelection(object selection)
        {
            propertyHelper.propertyGrid.SelectedObject = selection;
        }
    }
}
