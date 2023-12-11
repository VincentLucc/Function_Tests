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

namespace WebClient
{
    public partial class SettingsXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private bool isLoad = false;
        csDevMessage messageHelper;
        public SettingsXtraForm()
        {
            InitializeComponent();
            this.FormClosed += SettingsXtraForm_FormClosed;
        }

        private void SettingsXtraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!csConfigureHelper.SaveConfig(out string sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }
        }

        private void SettingsXtraForm_Load(object sender, EventArgs e)
        {
            messageHelper = new csDevMessage(this);

            ClientIDTextEdit.Text = csConfigureHelper.config.ClientID;
            ClientSecretMemoEdit.Text= csConfigureHelper.config.ClientSecret;
            CheckIntervalSpinEdit.EditValue = csConfigureHelper.config.CheckInverval;

            isLoad = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientIDTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
 
            csConfigureHelper.config.ClientID  = ClientIDTextEdit.Text;
        }

        private void ClientSecretMemoEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;

            csConfigureHelper.config.ClientSecret = ClientSecretMemoEdit.Text;
        }

        private void CheckIntervalSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;

            csConfigureHelper.config.CheckInverval = (int)CheckIntervalSpinEdit.Value;
        }
    }
}