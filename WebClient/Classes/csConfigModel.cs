using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebClient
{
    public class csConfigModel
    {

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gap of each attempt in second
        /// </summary>
        public int CheckInverval { get; set; }

        public BindingList<csGTINConfig> GTINs { get; set; }

        public csConfigModel()
        {
            GTINs = new BindingList<csGTINConfig>();
        }
    }

    [XmlType("GTIN")]
    public class csGTINConfig
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Number of gtin
        /// </summary>
        public string GTIN { get; set; }

        /// <summary>
        /// Automatic receive the GTIN
        /// </summary>
        public bool AutoFetch { get; set; }

        /// <summary>
        /// Number of the code for each request
        /// </summary>
        [Browsable(false)]
        public int NumberPerRequest { get; set; }
        /// <summary>
        /// Number of the code to request
        /// </summary>

        public int ReserveAmount { get; set; }

        /// <summary>
        /// Memory usage only
        /// </summary>
        [XmlIgnore]
        public _codeStatus Status { get; set; }


        public bool IsGTINEqual(string NewGTIN)
        {
            if (string.IsNullOrWhiteSpace(NewGTIN))
            {
                return NewGTIN == GTIN;
            }
            else
            {//Ignore case
                return NewGTIN.ToUpper() == GTIN.ToUpper();
            }

        }
    }

    public enum _codeStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Standby = 0,
        Requesting = 10,
        Requested = 11,
        Receiving = 20,
        Received = 21,
        Recorded = 30
    }

}
