using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocketTool_Framework
{
    [XmlRoot("Config")]
    public class csConfigModel
    {
        public List<csTCPServer> TCPServers { get; set; }
        public List<csTCPClient> TCPClients { get; set; }

        public csConfigModel()
        {
            TCPServers = new List<csTCPServer>();
            TCPClients = new List<csTCPClient>();
        }
    }
}
