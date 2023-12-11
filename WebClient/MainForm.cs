using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebClient
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        csDevMessage messageHelper;
        bool isUIExit => this == null || this.Disposing || this.IsDisposed || !this.Visible;

        /// <summary>
        /// Preload the images
        /// </summary>
        Image iconRed = Properties.Resources.iconsetredtoblack4_16x16;
        Image iconGreen = Properties.Resources.iconsettrafficlights3_16x16;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;

        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            //Init variables
            string sMessage = "";
            messageHelper = new csDevMessage(this);

            if (!csConfigureHelper.LoadOrCreateConfig(out sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }

            //Load the current GTIN
            StatusGridControl.DataSource = csConfigureHelper.config.GTINs;
            StatusGridView.PopulateColumns();


            //UI Update
            timer1.Start();

            //Start operation thread
            Thread tOperation = new Thread(ProcessOperation);
            tOperation.IsBackground = true;
            tOperation.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!csConfigureHelper.SaveConfig(out string sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }
        }

        public async void ProcessOperation()
        {

            while (!isUIExit)
            {
                Thread.Sleep(100);

                try
                {

                    //Check login
                    if (!await csAPIHelper.Login())
                    {
                        continue;
                    }


                    for (int i = 0; i < csConfigureHelper.config.GTINs.Count; i++)
                    {
                        var gtin = csConfigureHelper.config.GTINs[i];
                        await csAPIHelper.RequestCode(gtin.GTIN, gtin.NumberOfCodes);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ProcessOperation:\r\n" + ex.Message);
                }


            }

            Debug.WriteLine("ProcessOperation.End");
        }

        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //WebRequest_Post(null,null,out string sData,out string sMsg);

            if (!await csAPIHelper.Login())
            {
                messageHelper.Info("Login Fail.");
            }

        }

        private async void RequestButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!await csAPIHelper.RequestCode("00726587397509", 100))
            {
                messageHelper.Info("Request Fail.");
            }
        }

        private async void bCheckReady_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!await csAPIHelper.CheckCodeReady())
            {
                messageHelper.Info("Not Ready.");
            }

        }

        private void SettingsButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsXtraForm settings = new SettingsXtraForm())
            {
                settings.ShowDialog();
            }
        }

        private void GtinManagerButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (GtinManager gtinManager = new GtinManager())
            {
                gtinManager.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            try
            {
                //Show login status
                if (csAPIHelper.loginInfo == null || !csAPIHelper.loginInfo.IsValid)
                {
                    StatusButtonItem.ImageOptions.Image = iconRed;
                }
                else
                {
                    StatusButtonItem.ImageOptions.Image = iconGreen;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("timer1_Tick:\r\n" + ex.Message);
            }


            timer1.Enabled = true;
        }

        private void AddButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}