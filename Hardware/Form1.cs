using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Hardware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var macList = GetMacAddress();
            cbMac.DataSource = macList.Values.ToList();
        }

        public static Dictionary<string, string> GetMacAddress()
        {
            Dictionary<string, string> sList = new Dictionary<string, string>();

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    string sName = netInterface.Name;
                    byte[] bData = netInterface.GetPhysicalAddress().GetAddressBytes();
                    string sMac = BitConverter.ToString(bData);
                    sList.Add(sName, sMac);
                }
            }

            return sList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AssemblyInfo_Click(object sender, EventArgs e)
        {
           var assembly= Assembly.GetExecutingAssembly();
            string sVersion = assembly.GetName().Version.ToString();
        }

        private void bMotherBoard_Click(object sender, EventArgs e)
        {
            //Works, some property name might not exist
            string sBrand= csHardwareHelper.Manufacturer;
            string serialNumber = csHardwareHelper.SerialNumber;
            Debug.WriteLine($"Brand:{sBrand}, S/N:{serialNumber}");
        }

        private void bHardDrive_Click(object sender, EventArgs e)
        {
            string sHDDID = csHardwareHelper.FirstHardDriveID;
            Debug.WriteLine($"Disk:{sHDDID}");
        }
    }
}
