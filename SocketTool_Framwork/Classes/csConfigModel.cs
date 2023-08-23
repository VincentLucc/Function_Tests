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
        public List<csTCPServerConfig> TCPServers { get; set; }
        

        public csConfigModel()
        {
            TCPServers = new List<csTCPServerConfig>();
        }
    }
}
