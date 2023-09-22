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
            lock (client.lockReceivedMessages)
            {
                ReceivedGridControl.DataSource = client.ReceivedMessages;
            }         
            ReceivedGridView.PopulateColumns();
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
            if (!await client.ConnectToServer(csPublic.winMain))
            {
                csPublic.messageHelper.Info("Can't connect to server.");
                await client.Disconnect();
                return;
            }
            client.NewMessageReceived -= Client_NewMessageReceived;
            client.NewMessageReceived += Client_NewMessageReceived;
        }
    }

}

