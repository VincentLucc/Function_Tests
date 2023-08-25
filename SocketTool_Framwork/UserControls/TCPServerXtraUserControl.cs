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
    public partial class TCPServerXtraUserControl : XtraUserControl
    {

        public csTCPServer server;
        bool bUpdateRecivedMessage;

        public TCPServerXtraUserControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(csTCPServer tcpServer)
        {
            server = tcpServer;
            //Load the port
            PortLabelControl.Text = server.Port.ToString();
            IPv4LabelControl.Text = server.IPv4;

            //Force to load the data
            ReceivedGridControl.DataSource = server.ReceivedMessages;
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
            server?.BroadCastTCP(SendMemoEdit.Text);

        }


        public void UpdateUI()
        {
            if (bUpdateRecivedMessage)
            {
                ReceivedGridControl.RefreshDataSource();
                bUpdateRecivedMessage = false;
            }

            
            if (server.IsRunning)
            {
                StartButton.Enabled = false;
                StopButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
            }
        }

 

        private async void StartButton_Click(object sender, EventArgs e)
        {

            if (!server.StartTCPServer(this, out string sMessage))
            {
                csPublic.messageHelper.Info("Server start error.\r\n" + sMessage);
                await server.StopTCPServer();
                return;
            }
            server.ClientRequestReceived -= TcpServer_ClientRequestReceived;
            server.ClientRequestReceived += TcpServer_ClientRequestReceived;
        }

        private async void StopButton_Click(object sender, EventArgs e)
        {
            await server.StopTCPServer();
        }

        private void TcpServer_ClientRequestReceived(csTCPServer tcpServer, csTCPOperation operation)
        {
            //Notice to update the view
            bUpdateRecivedMessage = true;

        }
    }

}

