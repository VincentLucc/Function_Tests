using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketTool_Framework.Classes
{
    public class csTreeListItem
    {
        /// <summary>
        /// Display Name
        /// </summary>
        public string Name { get; set; }
        public object Tag { get; set; }
        public List<csTreeListItem> SubItems { get; set; }

        public csTreeListItem()
        {
            SubItems = new List<csTreeListItem>();
        }
    }
}
