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
    public partial class TCPServerXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        csTCPServer server;
        public TCPServerXtraUserControl()
        {
            InitializeComponent();
        }

        public void LoadConfig(csTCPServer tcpServer)
        {
            server = tcpServer;
        }

    }

}

