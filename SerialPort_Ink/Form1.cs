using DevExpress.XtraEditors;
using OperationBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<int> DeviceList = new List<int>(); //Current device 
        TimerBlock OperationBlock = new TimerBlock(); //Block process operation only
        List<InkDeviceData> Devices { get; set; }

        public Form1()
        {
            InitializeComponent();
            csPublic.winMain = this; //Name the form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitVariables();
            InitControls(); //add pre set values
            ReadXMLConfig();//read xml to load previous config
            InitOperations();
        }

        private void InitVariables()
        {
            csPublic.InkSystem = new csInkSystem(config);
            Devices = new List<InkDeviceData>();
            for (int i = 0; i < 8; i++)
            {
                InkDeviceData inkDevice = new InkDeviceData();
                Devices.Add(inkDevice);
            }

            //Disable auto updating data by default
            OperationBlock.StartBlock();
        }



        private void InitControls()
        {
            RefreshSerialPorts(); //Get local serial ports

            //baud rate
            cbPortRate.Properties.Items.Clear();
            foreach (var item in PortConfig.BaudRateCollection)
            {
                cbPortRate.Properties.Items.Add(item);
            }
            cbPortRate.SelectedIndex = 4; //19200
            cbPortRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


            //data bits 
            cb_Bits.Properties.Items.Clear();
            foreach (var item in PortConfig.DataBitsCollection)
            {
                cb_Bits.Properties.Items.Add(item);
            }
            cb_Bits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            //stop bits
            cbStopBits.Properties.Items.Clear();
            foreach (var item in PortConfig.StopBitsCollection)
            {
                cbStopBits.Properties.Items.Add(item);
            }
            cbStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            //verification
            cbVerify.Properties.Items.Clear();
            foreach (var item in PortConfig.ParityCollection)
            {
                cbVerify.Properties.Items.Add(item);
            }
            cbVerify.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            //Quick commands
            foreach (var item in config.Commands)
            {
                cbCommands.Properties.Items.Add(item);
            }

            //Parameter settings
            teMeniscusPressure.ReadOnly = true;

            //Data format
            var serialTypeList = Enum.GetNames(typeof(SerialDataType));
            lueSendFormat.Properties.DataSource = serialTypeList;
            lueSendFormat.Properties.ShowFooter = false;//remove the X button in bottom
            lueReceiveFormat.Properties.DataSource = serialTypeList;
            lueReceiveFormat.Properties.ShowFooter = false;//remove the X button in bottom
            lueSendSuffix.Properties.DataSource = csConfig.EndSuffixCollection;
            lueSendSuffix.Properties.ShowFooter = false;//remove the X button in bottom
        }


        private void InitOperations()
        {
            tbReceive1.TextChanged += TbReceive1_TextChanged;

            //Start UI update timer
            System.Timers.Timer tUpdate = new System.Timers.Timer();
            tUpdate.Interval = 100;
            tUpdate.Elapsed += TUIUpdate_Elapsed;
            tUpdate.Start();
        }

        private void TbReceive1_TextChanged(object sender, EventArgs e)
        {
            //Put this in event to make sure same location reached every time

        }

        private async void TUIUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var tUpdate = (System.Timers.Timer)sender;
            tUpdate.Enabled = false; //Avoid overflow

            //Auto exit
            if (this.Disposing || this.IsDisposed)
            {
                tUpdate.Enabled = false; //Exist all
                FinishUpClosing();
                return;
            }

            //Refresh data to UI
            UpdateUI();

            //Check operation pause flag
            if (OperationBlock.Enable)
            {
                OperationBlock.IsBlocked = true;
                tUpdate.Enabled = true;
                return;
            }

            //Attempt to fetch data from ink devices
            await UpdateDeviceInfo();

            tUpdate.Enabled = true; //Avoid overflow
        }

        private void UpdateUI()
        {
            tbReceive1.Invoke(new Action(() =>
            {
                if (csPublic.InkSystem.IsConnected && !tbReceive1.Focused)
                {
                    if (tbReceive1.Text != csPublic.InkSystem.MessagesReceivedCollection.Replace("\r", ""))
                    {
                        tbReceive1.SuspendLayout();
                        tbReceive1.Clear();
                        tbReceive1.AppendText(csPublic.InkSystem.MessagesReceivedCollection);
                        tbReceive1.ScrollToCaret();
                        tbReceive1.ResumeLayout();
                    }

                }
            }));

            //Show device info
            this.Invoke(new Action(() =>
            {
                if (lbDevices.SelectedIndex > -1)
                {
                    //Get selected device
                    var device = Devices[lbDevices.SelectedIndex + 1];
                    lBackPressure.Text = device.BackPressure.ToString("F2");
                    lRecirculation.Text = device.RecirculationPressure.ToString("F2");
                    lHeaterTemp.Text = device.HeaterTemp.ToString("F2");
                    lInkTemp.Text = device.InkTempreture.ToString("F2");
                    lStatusBits.Text = device.StatusBits.ToString("F2");
                    lAlarm.Text = device.Alarm.ToString("F2");

                    //Display parameters
                    teMeniscusPressure.Text = device.MeniscusPressureSetPoint.ToString("F2");
                }

            }));
        }

        private async Task UpdateDeviceInfo()
        {
            //Start from 1, 0 is default device when there is no network
            for (int i = 1; i < lbDevices.Items.Count+1; i++)
            {
                var currentDevice = Devices[i + 1];

                if (await csPublic.InkSystem.TryReadData(InkSystemCommandType.GetDeviceStatus,i))
                {                  
                    csPublic.InkSystem.DataBuffer.CopyDeviceData(ref currentDevice);
                }

                if (await csPublic.InkSystem.TryReadData(InkSystemCommandType.GetMeniscusPressure, i))
                {
                    currentDevice.MeniscusPressureSetPoint = csPublic.InkSystem.DataBuffer.MeniscusPressureSetPoint;
                }

            }
        }

        /// <summary>
        /// Close threads and free memories
        /// </summary>
        private void FinishUpClosing()
        {
            //Make sure fully exit
            if (csPublic.InkSystem != null || !csPublic.InkSystem.EnableDispose)
            {
                csPublic.InkSystem.Dispose();
            }
        }

        private void RefreshSerialPorts()
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

            if (csXML.ReadXML(typeof(csConfig), csConfig.DefaultPath, out xmlconfig))
            {
                try
                {
                    //Get config
                    config = (csConfig)xmlconfig;

                    //Apply settings
                    cbPortRate.SelectedIndex = config.Port.BaudRateIndex;
                    cbStopBits.SelectedIndex = config.Port.StopBitsIndex;
                    cb_Bits.SelectedIndex = config.Port.DataBitsIndex;
                    cbVerify.SelectedIndex = config.Port.ParityIndex;
                    lueSendFormat.EditValue = config.SendFormat.ToString();
                    lueReceiveFormat.EditValue = config.ReceiveFormat.ToString();
                    lueSendSuffix.EditValue = config.EndSuffixView;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in apply settings!\r\n" + e.Message);
                }

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            csXML.WriteXML(config, typeof(csConfig), csConfig.DefaultPath);
            FinishUpClosing();
        }

        private void cbPortNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.PortName = cbPortNumber.Text;
        }

        private void cbPortRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.BaudRateIndex = cbPortRate.SelectedIndex;
        }

        private void cb_Bits_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.DataBitsIndex = cb_Bits.SelectedIndex;
        }

        private void cbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.StopBitsIndex = cbStopBits.SelectedIndex;
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            RefreshSerialPorts();
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            ReadUserUISettings();
            if (csPublic.InkSystem.Connect(config))
            {
                Debug.WriteLine("Connected.");
            }
            else
            {
                MessageBox.Show("Fail to connect.");
            }

        }

        /// <summary>
        /// Read user settings from UI
        /// </summary>
        private void ReadUserUISettings()
        {
            //Only Portname is requireds
            config.Port.PortName = cbPortNumber.Text;
        }

        private async void bDisconnect_Click(object sender, EventArgs e)
        {
            await csPublic.InkSystem.Disconnect();
        }

        private void lueSendFormat_EditValueChanged(object sender, EventArgs e)
        {
            //Get setting
            string sValue = lueSendFormat.EditValue.ToString();
            if (Enum.TryParse(sValue, out SerialDataType serialDataType))
            {
                config.SendFormat = serialDataType;
            }
            else
            {
                config.SendFormat = SerialDataType.ASCII;
            }


        }

        private void lueReceiveFormat_EditValueChanged(object sender, EventArgs e)
        {
            //Get setting
            string sValue = lueReceiveFormat.EditValue.ToString();
            if (Enum.TryParse(sValue, out SerialDataType serialDataType))
            {
                config.ReceiveFormat = serialDataType;
            }
            else
            {
                config.ReceiveFormat = SerialDataType.ASCII;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void lueSendSuffix_EditValueChanged(object sender, EventArgs e)
        {
            //Get setting
            config.EndSuffixView = lueSendSuffix.EditValue.ToString();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            //Get sending string
            string sMessage = "";
            if (tsCommandEnable.IsOn)
            {
                sMessage = cbCommands.Text;
            }
            else
            {
                sMessage = meSend.Text;
            }

            csPublic.InkSystem.SendCommand(sMessage);
        }

        private async void bSearch_Click(object sender, EventArgs e)
        {
            lbDevices.Items.Clear();

            if (await csPublic.InkSystem.TryGetDeviceList())
            {
                for (int i = 0; i < csPublic.InkSystem.DataBuffer.Devices.Count; i++)
                {
                    string sDevice = $"Device:{csPublic.InkSystem.DataBuffer.Devices[i]}";
                    lbDevices.Items.Add(sDevice);
                }

                //Set current device list
                DeviceList = csPublic.InkSystem.DataBuffer.Devices.ToList();
            }
        }

        private async void tsEnableUpdate_Toggled(object sender, EventArgs e)
        {
            if (tsEnableUpdate.IsOn)
            {
                OperationBlock.StopBlock();
            }
            else
            {
                await OperationBlock.BlockAndWaitAsync();
            }
        }

        private async void bFetch_Click(object sender, EventArgs e)
        {
            if (tsEnableUpdate.IsOn)
                await OperationBlock.BlockAndWaitAsync();

            //Get id
            int iDevice = lbDevices.SelectedIndex + 1;
            if (iDevice < 1) iDevice = 1;

            if (await csPublic.InkSystem.TryReadData(InkSystemCommandType.GetDeviceStatus,iDevice))
            {
                var currentDevice = Devices[iDevice];
                csPublic.InkSystem.DataBuffer.CopyDeviceData(ref currentDevice);
            }
            else
            {
                MessageBox.Show("error");
            }

            if (tsEnableUpdate.IsOn)
                OperationBlock.StopBlock();
        }

        private void tsEnableEdit_Toggled(object sender, EventArgs e)
        {
            teMeniscusPressure.ReadOnly = !tsEnableEdit.IsOn;
        }

        private void bApplyMeniscusPressure_Click(object sender, EventArgs e)
        {
            if (teMeniscusPressure.ReadOnly) return;


        }
    }
}
