using _CommonCode_Framework;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptionTool
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public csDevMessage messageHelper { get; set; }

        public byte[] SourceBytes { get; set; }

        public csConfig config { get; set; }

        public FormMain()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.FormClosed += FormMain_FormClosed;

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (csConfigureHelper.IsLoad)
            {
                if (!csConfigureHelper.SaveConfig(out string sMessage))
                {
                    messageHelper.Error(sMessage);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!InitVariables())
            {
                this.Close();
                return;
            }

            InitControls();
        }

        private bool InitVariables()
        {
            string sMessage = "";
            messageHelper = new csDevMessage(this);

            //Manual create config

            //csConfigureHelper.Config = new csConfig();
            //csConfigureHelper.Config.Encryptions.Add(csConfigureHelper.Config.Encryption);
            //csConfigureHelper.Config.Encryptions.Add(csConfigureHelper.Config.Encryption);
            //csConfigureHelper.SaveConfig(out sMessage);


            if (!csConfigureHelper.LoadConfig(out sMessage))
            {
                messageHelper.Error(sMessage);
                return false;
            }
            config = csConfigureHelper.Config;

            //Pass all steps
            return true;
        }

        private void InitControls()
        {
            //Input/output
            var typeList = Enum.GetValues(typeof(_TextType));
            InitLookupEdit(InputLookUpEdit);
            InputLookUpEdit.Properties.DataSource = typeList;
            InputLookUpEdit.Properties.DropDownRows = typeList.Length; //Limit rows
            InputLookUpEdit.EditValue = csConfigureHelper.Config.InputType;
            InputLookUpEdit.EditValueChanged += InputLookUpEdit_EditValueChanged;

            InitLookupEdit(EncryptionListLookUpEdit);
            var itemList = csConfigureHelper.Config.Encryptions.Select(a => a.Description).ToList();
            EncryptionListLookUpEdit.Properties.DataSource = itemList;
            EncryptionListLookUpEdit.Properties.DropDownRows = itemList.Count(); //Limit rows
            EncryptionListLookUpEdit.EditValue = itemList[0];

        }


        private void InputLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (InputLookUpEdit.EditValue is _TextType)
            {
                csConfigureHelper.Config.InputType = (_TextType)InputLookUpEdit.EditValue;
                string sDIsplay = GetDisplayString(SourceBytes, csConfigureHelper.Config.InputType);
                InputMemoEdit.Text = sDIsplay;
            }
        }

        private void UpdateFileStreamMode(bool isFileStream)
        {
            if (isFileStream)
            {
                InputMemoEdit.ReadOnly = true;
            }
            else
            {
                InputMemoEdit.ReadOnly = false;
            }
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

        private void bENcrypt_Click(object sender, EventArgs e)
        {
            if (!TryGetInputBytes()) return;
            var encryption = csConfigureHelper.Config.SelectedEncryption;
            string sInput = Encoding.UTF8.GetString(SourceBytes);
            string sResult = encryption.EncryptToAesString(sInput);
            OutputMemoEdit.Text = sResult;
        }

        private void bConvert_Click(object sender, EventArgs e)
        {
            if (!TryGetInputBytes()) return;
            var encryption = csConfigureHelper.Config.SelectedEncryption;
            string sResult = encryption.DecryptFromAesByte(SourceBytes);

            OutputMemoEdit.Text = sResult;
        }



        private bool TryGetInputBytes()
        {
            string sInput = InputMemoEdit.Text;

            if (string.IsNullOrWhiteSpace(sInput))
            {
                MessageBox.Show("Empty inputs");
                return false;
            }

            if (csConfigureHelper.Config.InputType == _TextType.Hex)
            {
                if (!csHex.IsHexString(sInput))
                {
                    messageHelper.Info("Input is not valid hex string.");
                    return false;
                }

                SourceBytes = csHex.HexStringToHexByte(sInput);

            }
            else if (csConfigureHelper.Config.InputType == _TextType.String)
            {
                SourceBytes = Encoding.UTF8.GetBytes(sInput);
            }
            else if (csConfigureHelper.Config.InputType == _TextType.Base64String)
            {
                if (!csHex.IsBase64String(sInput))
                {
                    messageHelper.Info("Input is not valid base-64 string.");
                    return false;
                }
                SourceBytes = Convert.FromBase64String(sInput);
            }

            //Pass all steps
            return true;
        }

        private void bLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string sPath = dialog.FileName;
                    SourceBytes = File.ReadAllBytes(sPath);
                    string sDisplay = GetDisplayString(SourceBytes, config.InputType);
                    InputMemoEdit.Text = sDisplay;

                    var encryption = config.SelectedEncryption;
                    if (encryption == null)
                    {
                        messageHelper.Info("No encryption config found.");
                        return;
                    }
                    string sResult = encryption.DecryptFromAesByte(SourceBytes);
                    OutputMemoEdit.Text = sResult;
                }
            }
        }

        private string GetDisplayString(byte[] bSource, _TextType textType)
        {
            string sOutput = "";
            if (bSource == null || bSource.Length == 0) return string.Empty;

            switch (textType)
            {
                case _TextType.String:
                    sOutput = Encoding.UTF8.GetString(bSource);
                    break;
                case _TextType.Hex:
                    sOutput = BitConverter.ToString(bSource).Replace("-", " ");
                    break;
                case _TextType.Base64String:
                    sOutput = Convert.ToBase64String(bSource);
                    break;
                default:
                    break;
            }

            return sOutput;
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            FormAesConfig winConfig = new FormAesConfig();
            winConfig.StartPosition = FormStartPosition.CenterParent;
            winConfig.ShowDialog();
        }

        private void bEncryptToFile_Click(object sender, EventArgs e)
        {
            var encryption = config.SelectedEncryption;
            if (encryption == null)
            {
                messageHelper.Info("No encryption config found.");
                return;
            }

            //Check input
            if (!TryGetInputBytes())
            {
                messageHelper.Info("Enmpty input.");
                return;
            }

            //Encryption
            string sINput = Encoding.UTF8.GetString(SourceBytes);
            var encrptedData = encryption.EncryptToAesByte(sINput);

            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sPath = fileDialog.FileName;

                    using (FileStream steram=new FileStream(sPath,FileMode.Create,
                        FileAccess.Write,FileShare.None,8196,FileOptions.WriteThrough))
                    {
                        steram.Write(encrptedData,0, encrptedData.Length);
                    }
                }
            }
        }
    }
}
