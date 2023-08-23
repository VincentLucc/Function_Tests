using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocketTool_Framework
{
    public class csModel
    {
    }

    public class csGroup
    {
        public const string TCPServer = "TCP Server";
        public const string TCPClient = "TCP Client";

        public static _itemType GetType(string sName)
        {
            if (sName== TCPServer)
            {
                return _itemType.TCPServer;
            }
            else if (sName== TCPClient)
            {
                return _itemType.TCPClient;
            }
            else
            {
                return _itemType.None;
            }
        }

    }

    public enum _itemType
    {
        [XmlEnum(Name = "-1")]
        None,
        [XmlEnum(Name = "0")]
        TCPServer,
        [XmlEnum(Name = "1")]
        TCPClient
    }
}
