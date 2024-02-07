using DevExpress.XtraEditors;
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
    public partial class TCPServerXtraUserControl : XtraUserControl
    {

        public csTCPServer server;
        bool bUpdateRecivedMessage;

        public TCPServerXtraUserControl()
        {
            InitializeComponent();
            Disposed += TCPServerXtraUserControl_Disposed;
        }

        private void TCPServerXtraUserControl_Disposed(object sender, EventArgs e)
        {
            server.ClientRequestReceived -= TcpServer_ClientRequestReceived;
            server = null;
        }

        public void LoadConfig(csTCPServer tcpServer)
        {
            server = tcpServer;
            //Load the port
            PortLabelControl.Text = server.Port.ToString();
            IPv4LabelControl.Text = server.IPv4;

            //Force to load the data
            ReceivedGridView.Columns.Clear();
            var colRec = ReceivedGridView.Columns.AddField(nameof(csRecClinetMessage.RecTime));
            colRec.Width = 80;
            var colClient = ReceivedGridView.Columns.AddField(nameof(csRecClinetMessage.Client));
            colClient.Width = 100;
            var colMessage = ReceivedGridView.Columns.AddField(nameof(csRecClinetMessage.Message));
            ReceivedGridControl.DataSource = server.RequestHistory;
            ReceivedGridView.CustomColumnDisplayText += ReceivedGridView_CustomColumnDisplayText;

            //Reload the events
            server.ClientRequestReceived -= TcpServer_ClientRequestReceived;
            server.ClientRequestReceived += TcpServer_ClientRequestReceived;
        }

        private void ReceivedGridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is DateTime)
            {
                var time = (DateTime)e.Value;
                e.DisplayText = time.ToString(csPublic.TimeStringFormat);
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
            server?.BroadCastTCP(SendMemoEdit.Text);

        }


        public void UpdateUI()
        {
            if (bUpdateRecivedMessage)
            {
                Debug.WriteLine("Update Grid");
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
        }

        private async void StopButton_Click(object sender, EventArgs e)
        {
            await server.StopTCPServer();
        }

        private void TcpServer_ClientRequestReceived(csTCPServer tcpServer, csTCPOperation operation)
        {
            //Notice to update the view
            bUpdateRecivedMessage = true;
            Debug.WriteLine("bUpdateRecivedMessage:True");

        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }
    }

}

