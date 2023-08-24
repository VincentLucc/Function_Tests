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
        public TCPServerXtraUserControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(csTCPServer tcpServer)
        {
            server = tcpServer;
            //Load the port
            PortSpinEdit.EditValue = server.Port;
            IPAddressTextEdit.Text = server.IPv4;

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

        private void IPAddressTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            server.IPv4 = IPAddressTextEdit.Text;
        }

        private void PortSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            server.Port = Convert.ToInt32(PortSpinEdit.EditValue);
        }

        public void UpdateReceivedBox()
        {
            ReceivedGridControl.RefreshDataSource();
        }
    }

}

