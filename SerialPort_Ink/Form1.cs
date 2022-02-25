using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SerialPort_Ink
{
    public partial class Form1 : XtraForm
    {
        //变量
        SerialPort port1 = new SerialPort();//实例化串口类
        csConfig config = new csConfig();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupLayout(); //add pre set values
            ReadXMLConfig();//read xml to load previous config
        }

        private void SetupLayout()
        {
            LoadSerialPorts(); //Get local serial ports

            //baud rate
            cbPortRate.Properties.Items.Clear();
            cbPortRate.Properties.Items.Add(2400);
            cbPortRate.Properties.Items.Add(4800);
            cbPortRate.Properties.Items.Add(9600);
            cbPortRate.Properties.Items.Add(11520);
            cbPortRate.Properties.Items.Add(19200);
            cbPortRate.Properties.Items.Add(38400);
            cbPortRate.SelectedIndex = 2;

            //data bits 
            cb_Bits.Properties.Items.Clear();
            cb_Bits.Properties.Items.Add(6);
            cb_Bits.Properties.Items.Add(7);
            cb_Bits.Properties.Items.Add(8);
            //stop bits
            cbStopBits.Properties.Items.Clear();
            //cbStopBits.Items.Add("None");//Stop bits none should never be used, will cause error
            cbStopBits.Properties.Items.Add("1");
            cbStopBits.Properties.Items.Add("1.5");
            cbStopBits.Properties.Items.Add("2");
            //verification
            cbVerify.Properties.Items.Clear();
            cbVerify.Properties.Items.Add("None");
            cbVerify.Properties.Items.Add("Odd");
            cbVerify.Properties.Items.Add("Even");
            //Data format
            var serialTypeList=Enum.GetNames(typeof(SerialDataType));
            lueSendFormat.Properties.DataSource = serialTypeList;
            lueSendFormat.EditValue = config.SendFormat;
            lueSendFormat.Properties.ShowFooter = false;//remove the X button in bottom
            lueReceiveFormat.Properties.DataSource = serialTypeList;         
            lueReceiveFormat.EditValue = config.ReceiveFormat;
            


        }

        private void LoadSerialPorts()
        {
            //Get local serial ports
            string[] sPorts = SerialPort.GetPortNames();

            //Check result
            if (sPorts.Length < 1)
            {
                cbPortNumber.Properties.Items.Clear();
                cbPortNumber.Properties.Items.Add("N/A");
                return;
            }

            //Add ports
            cbPortNumber.Properties.Items.Clear();
            for (int i = 0; i < sPorts.Length; i++)
            {
                cbPortNumber.Properties.Items.Add(sPorts[i]);
            }

            //Select first port
            cbPortNumber.SelectedIndex = 0;
        }

        private void ReadXMLConfig()
        {
            var xmlconfig = new object();

            if (csXML.ReadXML(typeof(csConfig),csConfig.DefaultPath,out xmlconfig))
            {
                //Get config
                config =(csConfig) xmlconfig;

                //Apply settings
                try
                {
                    //read port nums
                    if (config.Port.PortName < (cbPortNumber.Properties.Items.Count - 1))
                    {//make sure previous selected port not bigger than current computer's com status
                        cbPortNumber.SelectedIndex = config.Port.PortName;
                    }
                    cbPortRate.SelectedIndex = config.Port.BaudRate;
                    cbStopBits.SelectedIndex = config.Port.StopBits;
                    cb_Bits.SelectedIndex = config.Port.DataBits;
                    cbVerify.SelectedIndex = config.Port.Parity;
                    lueSendFormat.EditValue = config.SendFormat;
                    lueReceiveFormat.EditValue = config.ReceiveFormat;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in apply settings!\r\n"+e.Message);
                }

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            csXML.WriteXML(config,typeof(csConfig),csConfig.DefaultPath);
        }

        private void cbPortNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.PortName = cbPortNumber.SelectedIndex;
        }

        private void cbPortRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.BaudRate = cbPortRate.SelectedIndex;
        }

        private void cb_Bits_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.DataBits = cb_Bits.SelectedIndex;
        }

        private void cbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.StopBits = cb_Bits.SelectedIndex;
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            LoadSerialPorts();
        }


    }
}
