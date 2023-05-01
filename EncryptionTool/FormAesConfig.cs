using _CommonCode_Framework;
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

namespace EncryptionTool
{
    public partial class FormAesConfig : DevExpress.XtraEditors.XtraForm
    {
        csConfig config;

        public FormAesConfig()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.FormClosed += FormAesConfig_FormClosed;
        }

        private void FormAesConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            config = null;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAesConfig_Load(object sender, EventArgs e)
        {
            InitVariables();
            InitControls();
        }

        private void InitVariables()
        {

        }

        private void InitControls()
        {
            InitLookupEdit(EncryptionsLookUpEdit);
            var config1ist = csConfigureHelper.Config.Encryptions.Select(a => a.Description);
            EncryptionsLookUpEdit.Properties.DataSource = config1ist;
            EncryptionsLookUpEdit.Properties.DropDownRows = config1ist.Count();
            EncryptionsLookUpEdit.EditValueChanged += EncryptionsLookUpEdit_EditValueChanged;


        }

        private void EncryptionsLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (EncryptionsLookUpEdit.ItemIndex < 0) return;
            config.SelectedIndex = EncryptionsLookUpEdit.ItemIndex;
        }

        private void InitLookupEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.ShowFooter = false; //Hide X
            lookUpEdit.Properties.NullText = ""; //Hide default null text
            lookUpEdit.CustomDisplayText += LookUpEdit_CustomDisplayText;
        }

        private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            string sDescription = "";
            if (e.Value is _TextType)
            {
                sDescription = csEnumHelper<_TextType>.GetDescription((_TextType)e.Value);
            }

            if (!string.IsNullOrWhiteSpace(sDescription))
            {
                e.DisplayText = sDescription;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string sInput = XtraInputBox.Show("Please add a description", "Add encryption", "Default");
            if (string.IsNullOrWhiteSpace(sInput)) return;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }
    }
}