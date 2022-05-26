using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprintCode
{
    public partial class FormMain : XtraForm
    {


        public byte[] DataBuffer;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        private void bReadFIle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string sPath = fileDialog.FileName;
                tePath.Text = sPath;
                DataBuffer = File.ReadAllBytes(sPath);

                //Debug info
                string sMessage = Encoding.UTF8.GetString(DataBuffer);
                Debug.WriteLine("Raw data:" + sMessage);

                //Result
                var inkInfo = csAprintOperation.DecodeInkData(DataBuffer);
                ShowInkInfo(inkInfo);
            }
        }

        private void bProcess_Click(object sender, EventArgs e)
        {
            //Init variable
            InkInfo inkData = new InkInfo();


            //Get new volume
            if (!UInt64.TryParse(teVolume.Text,out ulong lVolume))
            {
                MessageBox.Show("Invalid volume.");
                return;
            }
            inkData.VolumeRaw = lVolume;

            //Get new dongle ID
            if (!UInt32.TryParse(teDongleID.Text,out UInt32 iID))
            {
                MessageBox.Show("Invalid dongleID.");
                return;
            }
            inkData.DongleID = iID;


            try
            {
                var rawData = csAprintOperation.EncodeInkData(inkData);

                File.WriteAllBytes(tePath.Text, rawData);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message);
                return;
            }

            //Pass all steps
            MessageBox.Show(this,"Success!");
        }


       private void ShowInkInfo(InkInfo inkData)
        {
            if (inkData==null)
            {
                teDongleID.Text = "N/A";
                teVolume.Text = "N/A";
            }
            else
            {
                teDongleID.Text = inkData.DongleID.ToString();
                teVolume.Text = inkData.VolumeRaw.ToString();
            }
        }


    }
}
