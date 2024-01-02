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

        csDevMessage messageHelper;

        private bool isLoad;
        public FormMain()
        {
            InitializeComponent();
            this.FormClosed += FormMain_FormClosed;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLoad)
            {
                if (!csConfigHelper.Save(out string sMessage))
                {
                    messageHelper.Info(sMessage);
                }
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init
            messageHelper = new csDevMessage(this);

            if (!csConfigHelper.LoadOrCreateConfig(out string sMessage))
            {
                messageHelper.Info(sMessage);
                this.Close();
                return;
            }

            //Decryption page
            PublickKeyButtonEdit.Text = csConfigHelper.Config.PublicKeyPath;
            PrivateKeyButtonEdit.Text = csConfigHelper.Config.PrivateKeyPath;
            PasswordTextEdit.Text = csConfigHelper.Config.PasswordDecryption;
            DecreptFilePathButtonEdit.Text = csConfigHelper.Config.DecryptFilePath;

            //Encryption page
            KeysButtonEdit.Text = csConfigHelper.Config.NewKeysFolder;
            EncrptionPassTextEdit.Text = csConfigHelper.Config.PasswordEncryption;
            DecryptionFileButtonEdit.Text = csConfigHelper.Config.DecryptFilePath;

            //Finish
            isLoad = true;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            string sFile = csConfigHelper.Config.DecryptFilePath;
            var decResult = csPGPHelper.DecryptFile(sFile);
            int iLengthLimit = 9999;

            if (!decResult.IsSuccess)
            {
                memoEdit1.Text = "";
                messageHelper.Info(decResult.Message);
                return;
            }

            //Load result
            if (csPGPHelper.PlainText == null)
            {
                memoEdit1.Text = "";
            }
            else
            {
                if (csPGPHelper.PlainText.Length > iLengthLimit)
                    memoEdit1.Text = csPGPHelper.PlainText.Substring(0, iLengthLimit);
                else
                    memoEdit1.Text = csPGPHelper.PlainText;
            }


        }

        private void PublickKeyButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.PublicKeyPath = PublickKeyButtonEdit.Text;
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

        private void PrivateKeyButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.PrivateKeyPath = PrivateKeyButtonEdit.Text;
        }

        private void PasswordTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.PasswordDecryption = PasswordTextEdit.Text;
        }


        private void FilePathButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DecreptFilePathButtonEdit.Text = dialog.FileName;
                }
            }
        }

        private void FilePathButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.DecryptFilePath = DecreptFilePathButtonEdit.Text;
        }

        private void KeysButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.NewKeysFolder = KeysButtonEdit.Text;
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            //Save file
            var result = csPGPHelper.EncryptFile(csConfigHelper.Config);
            if (result.IsSuccess)
            {
                messageHelper.Info("Success.");
            }
            else
            {
                messageHelper.Info(result.Message);
            }


        }

        private void SavePassTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.PasswordEncryption = EncrptionPassTextEdit.Text;
        }

        private void DecryptionFileButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            csConfigHelper.Config.DecryptFilePath = DecryptionFileButtonEdit.Text;
        }

        private void DecryptionFileButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DecryptionFileButtonEdit.Text = dialog.FileName;
                }
            }
        }
    }
}
