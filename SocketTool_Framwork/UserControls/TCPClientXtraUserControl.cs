using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTool_Framework.UserControls
{
    public partial class TCPClientXtraUserControl : XtraUserControl
    {

        public csTCPClient client;
        bool bUpdateRecivedMessage;

        public TCPClientXtraUserControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(csTCPClient _tcpClient)
        {
            client = _tcpClient;
            //Load the port
            PortLabelControl.Text = client.ServerPort.ToString();
            IPv4LabelControl.Text = client.ServerIP;

            //Force to load the data
            ReceivedGridView.CustomColumnDisplayText += ReceivedGridView_CustomColumnDisplayText;
            lock (client.lockReceivedMessages)
            {
                ReceivedGridControl.DataSource = client.ReceivedMessages;
            }
            ReceivedGridView.PopulateColumns();
            foreach (GridColumn col in ReceivedGridView.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
                if (col.FieldName== nameof(csRecMessage.RecTime))
                {
                    col.Width = 80;
                    col.MaxWidth = 100;
                }
            }


        }

        private void ReceivedGridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Value is DateTime)
                {
                    var time= (DateTime)e.Value;
                    e.DisplayText = time.ToString(csPublic.TimeStringFormat);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TCPClientXtraUserControl.ReceivedGridView_CustomColumnDisplayText.Exception:\r\n{ex.Message}");
            }

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            //Broad cast to all clients
            if (string.IsNullOrWhiteSpace(SendMemoEdit.Text))
            {
                csPublic.messageHelper.Info("Please enter a valid value.");
                return;
            }

            client.SendMessage(SendMemoEdit.Text);
        }


        public void UpdateUI()
        {
            if (bUpdateRecivedMessage)
            {
                lock (client.lockReceivedMessages)
                {
                    ReceivedGridControl.RefreshDataSource();
                    ReceivedGridView.MoveLast();
                }
                bUpdateRecivedMessage = false;
            }


            if (client.IsConnected)
            {
                ConnectButton.Enabled = false;
                DisconnectButton.Enabled = true;
            }
            else
            {
                ConnectButton.Enabled = true;
                DisconnectButton.Enabled = false;
            }
        }





        private void Client_NewMessageReceived(string sMessage)
        {
            bUpdateRecivedMessage = true;
        }





        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }

        private async void DisconnectButton_Click(object sender, EventArgs e)
        {
            await client.Disconnect();
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            csPublic.messageHelper.ShowMainLoading("Connecting");

            if (!await client.ConnectToServer(csPublic.winMain))
            {
                csPublic.messageHelper.Info("Can't connect to server.");
                await client.Disconnect();
                return;
            }
            client.NewMessageReceived -= Client_NewMessageReceived;
            client.NewMessageReceived += Client_NewMessageReceived;
            csPublic.messageHelper.CloseForm();
        }
    }

}

