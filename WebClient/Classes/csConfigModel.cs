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

        /// <summary>
        /// Memory usage only, used to get response from server
        /// 
        /// </summary>
        [Browsable(false)]
        public string JobID { get; set; }

        /// <summary>
        /// Store the response message of current job
        /// </summary>
        [Browsable(false)]
        public csCheckJob_Response Job_Response { get; set; }

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
        /// Task not running
        /// </summary>
        Standby = 0,
        /// <summary>
        /// Sending code request
        /// </summary>
        Requesting = 11,
        /// <summary>
        /// Code request sent
        /// </summary>
        Requested = 12,
        /// <summary>
        /// Checking to see whether code is ready
        /// </summary>
        Checking = 21,
        /// <summary>
        /// Indicate remote server is processing
        /// </summary>
        Processing = 22,
        /// <summary>
        /// Receiving data from server
        /// </summary>
        Receiving = 31,
        /// <summary>
        /// Data is received successfuling
        /// </summary>
        Received = 32,
        /// <summary>
        /// Recording data to disk
        /// </summary>
        Recording = 41,
        /// <summary>
        /// Data recorded to disk
        /// </summary>
        Recorded = 42
    }

}
