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

namespace Camera_Parameters
{
    public partial class CalUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public CalUserControl()
        {
            InitializeComponent();
            this.Load += CalUserControl_Load;
        }

        private void CalUserControl_Load(object sender, EventArgs e)
        {
            //Resolution options            
            ResolutionOptionsLookUpEdit.Properties.DataSource = csResolution.ResolutionOptions;
            ResolutionOptionsLookUpEdit.Properties.PopupWidth = 350;
            ResolutionOptionsLookUpEdit.CustomDisplayText += ResolutionOptionsLookUpEdit_CustomDisplayText;
            CustomResolutionToggleSwitch.IsOn = csConfigureHelper.config.CustomResolution;
            CustomResolutionChangeAction();
        }

        private void ResolutionOptionsLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value is csResolution)
            {
                var resolution = e.Value as csResolution;
                e.DisplayText = $"{resolution.X}*{resolution.Y}";
            }
        }

        private void ResolutionOptionsLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ResolutionOptionsLookUpEdit.EditValue is csResolution)
            {
                var resolution = ResolutionOptionsLookUpEdit.EditValue as csResolution;
                ResolutionXSpinEdit.Value = resolution.X;
                ResolutionYSpinEdit.Value = resolution.Y;
            }
        }

        private void CustomResolutionToggleSwitch_Toggled(object sender, EventArgs e)
        {
            CustomResolutionChangeAction();
        }

        private void CustomResolutionChangeAction()
        {
            if (CustomResolutionToggleSwitch.IsOn)
            {
                ResolutionXSpinEdit.Enabled = true;
                ResolutionYSpinEdit.Enabled = true;
                ResolutionOptionsLookUpEdit.Enabled = false;
            }
            else
            {
                ResolutionXSpinEdit.Enabled = false;
                ResolutionYSpinEdit.Enabled = false;
                ResolutionOptionsLookUpEdit.Enabled = true;
            }

            csConfigureHelper.config.CustomResolution = CustomResolutionToggleSwitch.IsOn;
        }
    }
}
