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

namespace EncryptionPGP
{
    public partial class FormMain : Form
    {
        public string sMessage;

        public FormMain()
        {
            InitializeComponent();
            this.FormClosed += FormMain_FormClosed;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            csConfigHelper.Save(out string sMessage);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            csConfigHelper.LoadOrCreateConfig(out string sMessage);

            PublickKeyButtonEdit.Text = csConfigHelper.Config.PublicKeyPath;
            PrivateKeyButtonEdit.Text = csConfigHelper.Config.PrivateKeyPath;
            PasswordTextEdit.Text= csConfigHelper.Config.Password;
            KeysButtonEdit.Text= csConfigHelper.Config.KeysFolder;

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {

        }

        private void PublickKeyButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void PublickKeyButtonEdit_Click(object sender, EventArgs e)
        {

        }

        private void PrivateKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PrivateKeyButtonEdit.Text = dialog.FileName;
                }
            }
        }

        private void PublickKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PublickKeyButtonEdit.Text = dialog.FileName;
                }
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {

        }

        private void KeysButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (XtraFolderBrowserDialog dialog = new XtraFolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    KeysButtonEdit.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
