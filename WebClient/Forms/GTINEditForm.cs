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
using WebClient.Classes;

namespace WebClient.Forms
{
    public partial class GTINEditForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// memory settings
        /// </summary>
        public csGTINConfig GTINInfo;
        /// <summary>
        /// Form load flag
        /// </summary>
        bool isLoad;

        csDevMessage messageHelper;
        public GTINEditForm(csGTINConfig gtin)
        {
            InitializeComponent();
            GTINInfo = new csGTINConfig();
            if (gtin != null)
            {
                GTINInfo.CopyValues(gtin);
            }
        }

        private void GTINEditForm_Load(object sender, EventArgs e)
        {
            //Init
            messageHelper = new csDevMessage(this);

            //Load memeory values
            ProductNameTextEdit.Text = GTINInfo.ProductName;
            GTINTextEdit.Text = GTINInfo.GTIN;
            DescriptionTextEdit.Text = GTINInfo.Description;
            AutoReserveToggleSwitch.IsOn = GTINInfo.AutoFetch;
            ReserveSpinEdit.Value = GTINInfo.ReserveTarget;
            LimitSpinEdit.Value = GTINInfo.LimitPerRequest;

            //finish up
            isLoad = true;
        }

        private void ReserveSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.ReserveTarget = (int)ReserveSpinEdit.Value;
        }

        private void LimitSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.LimitPerRequest = (int)LimitSpinEdit.Value;
        }

        private void AutoReserveToggleSwitch_Toggled(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.AutoFetch = AutoReserveToggleSwitch.IsOn;
        }

        private void DescriptionTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.Description = DescriptionTextEdit.Text;
        }

        private void GTINTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.GTIN = GTINTextEdit.Text;
        }

        private void ProductNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!isLoad) return;
            GTINInfo.ProductName = ProductNameTextEdit.Text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //verify the gtin
            if (string.IsNullOrWhiteSpace(GTINInfo.GTIN))
            {
                messageHelper.Info("GTIN is empty.");
                return;
            }


            this.DialogResult= DialogResult.OK;


            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}