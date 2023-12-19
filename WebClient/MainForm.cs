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
using WebClient.Classes;
using WebClient.Forms;

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
        bool gridUpdateRequired = false;
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
            StatusGridView.DoubleClick += StatusGridView_DoubleClick;
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

            //Verify database existance
            if (!csSQLHelper.Exist())
            {
                if (!csSQLHelper.CreateDataBase(out sMessage))
                {
                    messageHelper.Info(sMessage);
                    return;
                }
            }

           


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

                //Check time interval
                var interval = DateTime.Now - csAPIHelper.LastAttempt;
                if (interval < new TimeSpan(0, 0, 0, 0, csConfigureHelper.config.CheckInverval * 1000))
                {
                    continue;
                }

                try
                {

                    //Check login
                    if (!await csAPIHelper.Login()) continue;
 
                    for (int i = 0; i < csConfigureHelper.config.GTINs.Count; i++)
                    {
                        var gtin = csConfigureHelper.config.GTINs[i];

                        //Check number of ready codes
                        if (!csSQLHelper.CheckGTINStorage(gtin, out string sMessage))
                        {
                            Debug.WriteLine("Error");
                            gridUpdateRequired = true;
                            continue;
                        }

                        //Check current
                        if (gtin.QueueAmount < 1) continue;
            
                        if (string.IsNullOrWhiteSpace(gtin.JobID))
                        {
                            await csAPIHelper.RequestCode(gtin);
                        }
                        else
                        {
                            await csAPIHelper.CheckCodeReady(gtin);
                        }
                        //Notify ui update
                        gridUpdateRequired = true;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ProcessOperation:\r\n" + ex.Message);
                }


            }

            Debug.WriteLine("ProcessOperation.End");
        }



        private void SettingsButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SettingsXtraForm settings = new SettingsXtraForm())
            {
                settings.ShowDialog();
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

                if (gridUpdateRequired)
                {
                    StatusGridControl.RefreshDataSource();
                    gridUpdateRequired = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("timer1_Tick:\r\n" + ex.Message);
            }


            timer1.Enabled = true;
        }



        private void AddButtonItem_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            using (GTINEditForm gtinEdit = new GTINEditForm(null))
            {
                if (gtinEdit.ShowDialog() == DialogResult.OK)
                {
                    //Verify duplication
                    var duplicatedGTIN = csConfigureHelper.config.GTINs.FirstOrDefault(g => g.IsGTINEqual(gtinEdit.GTINInfo.GTIN));
                    if (duplicatedGTIN == null)
                    {
                        csConfigureHelper.config.GTINs.Add(gtinEdit.GTINInfo);
                    }
                    else
                    {
                        messageHelper.Info("Deuplicated GTIN.");
                    }

                }
            }
        }

        private void DeleteButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void StatusGridView_DoubleClick(object sender, EventArgs e)
        {
            EditGTINAction(showMessage: false);
        }



        private void EditButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditGTINAction(showMessage:true);
        }

        private void EditGTINAction(bool showMessage)
        {
            int iHandle = StatusGridView.FocusedRowHandle;

            if (iHandle < 0 )
            {
                if (showMessage) messageHelper.Info("Please select a valid record.");
                return;
            }

            int iSourceIndex = StatusGridView.GetDataSourceRowIndex(iHandle);
            var targetGTIN = csConfigureHelper.config.GTINs[iSourceIndex];

            using (GTINEditForm gtinEdit = new GTINEditForm(targetGTIN))
            {
                if (gtinEdit.ShowDialog() == DialogResult.OK)
                {
                    //Check whether gtin changed
                    if (gtinEdit.GTINInfo.IsGTINEqual(targetGTIN.GTIN))
                    {//Unchanged, directly apply
                        targetGTIN.CopyValues(gtinEdit.GTINInfo);
                    }
                    else
                    {//GTIN changed, must verify duplication
                        var duplicatedGTIN = csConfigureHelper.config.GTINs.FirstOrDefault(g => g.IsGTINEqual(gtinEdit.GTINInfo.GTIN));
                        if (duplicatedGTIN == null)
                        {//Load edited value
                            targetGTIN.CopyValues(gtinEdit.GTINInfo);
                        }
                        else
                        {
                            messageHelper.Info("Deuplicated GTIN.");
                        }
                    }
                }
            }
        }
    }
}