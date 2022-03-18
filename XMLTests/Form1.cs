using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace XMLTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create config file
            InkSysConfig inkSys = new InkSysConfig();
            inkSys.COMPortName = "COM5";
            inkSys.CommInterface = _commInterfaces.Serial;
            

            //Devices
            var deviceNames = new List<string> {"Yellow","Magenta","Cyan","Black" };

            //Create devices
            for (int i = 0; i < 4; i++)
            {
                InkDeviceConfig device = new InkDeviceConfig();
                device.Name = deviceNames[i];
                device.NetworkID = i + 1;
                device.HeaterFuntion = true;
                device.DegassFuntion = false;
                if (i<2)
                {
                    device.Type = _inkSysType.Regular;
                }
                else
                {
                    device.Type = _inkSysType.Recirculating;
                }
                
                inkSys.DeviceCollection.Add(device);
            }

            csXML.WriteXML(inkSys, typeof(InkSysConfig),csPublic.FilePath+@"\ink.xml");
        }
    }
}
