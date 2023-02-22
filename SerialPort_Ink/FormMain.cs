using DevExpress.XtraEditors;
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
using System.Threading;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace SerialPort_Ink
{
    public partial class FormMain : XtraForm
    {
        csConfig config = new csConfig();
        /// <summary>
        /// device network status
        /// </summary>
        List<int> DeviceNetwork = new List<int>();
        LoopBlocker loopBlock = new LoopBlocker(); //Block process operation only
        /// <summary>
        /// Store device data
        /// 0 is default device without network
        /// 1-32 A-Z
        /// </summary>
        List<InkDevice> Devices { get; set; }
        int TargetDeviceID => GetTargetDeviceID();

        public bool UIExit => this == null || this.Disposing || this.IsDisposed;

        public FormMain()
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            csXML.WriteXML(config, typeof(csConfig), csConfig.DefaultPath);
            FinishUpClosing();
        }

        private void InitVariables()
        {
            csPublic.InkSystem = new csInkSystemColor(config);
            Devices = new List<InkDevice>();

            //Prepare enough empty device
            for (int i = 0; i < 30; i++)
            {
                InkDevice inkDevice = new InkDevice();
                Devices.Add(inkDevice);
            }

            //Disable auto updating data by default
            loopBlock.StartBlock();
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
            cbStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            foreach (var item in PortConfig.StopBitsCollection)
            {
                cbStopBits.Properties.Items.Add(item);
            }


            //verification
            cbVerify.Properties.Items.Clear();
            cbVerify.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            foreach (var item in PortConfig.ParityCollection)
            {
                cbVerify.Properties.Items.Add(item);
            }

            //Flow control
            tsFlowControl.IsOn = config.Port.EnableFlowControl;
            tsFlowControl.Toggled += TsFlowControl_Toggled;

            //Quick commands
            foreach (var item in config.Commands)
            {
                cbCommands.Properties.Items.Add(item);
            }

            //Parameter settings
            teMeniscusPressure.ReadOnly = true;

            //Data send format
            var serialTypeList = Enum.GetNames(typeof(SerialDataType));
            lueSendFormat.Properties.DataSource = serialTypeList;
            lueSendFormat.Properties.ShowFooter = false;//remove the X button in bottom

            //Data receive format
            lueReceiveFormat.Properties.DataSource = serialTypeList;
            lueReceiveFormat.Properties.DropDownRows= serialTypeList.Length;
            lueReceiveFormat.Properties.ShowFooter = false;//remove the X button in bottom

            //Data send surfix
            lueSendSuffix.Properties.DataSource = csConfig.EndSuffixCollection;
            lueSendSuffix.Properties.DropDownRows = csConfig.EndSuffixCollection.Length;
            lueSendSuffix.Properties.ShowFooter = false;//remove the X button in bottom

            //Serial port send mode normal or 2bytes by 2 bytes
            var serialSendMode = Enum.GetNames(typeof(SerialSendMode));
            lueSendMode.Properties.DataSource = serialSendMode;
            lueSendMode.Properties.DropDownRows = serialSendMode.Length;
            lueSendMode.Properties.ShowFooter = false;//remove the X button in bottom

            //Init gridview
            InitGridviewWithDefaultSettings(gvReceive,false,false, HorzAlignment.Near);
            gvReceive.OptionsView.ShowVerticalLines = DefaultBoolean.False;
            gvReceive.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            gvReceive.OptionsView.ShowColumnHeaders = false;
        }

        public static void InitGridviewWithDefaultSettings(DevExpress.XtraGrid.Views.Grid.GridView View, bool EnableEdit = false, bool ShowNewRow = false, HorzAlignment alignment = HorzAlignment.Center)
        {
            //Basic settings
            View.OptionsView.ShowGroupPanel = false; //User don't see group panel
            View.OptionsView.ShowIndicator = false; //Hide row header
            View.OptionsCustomization.AllowSort = false;//Disable sort
            View.OptionsCustomization.AllowFilter = false;//distable filter
            View.OptionsCustomization.AllowQuickHideColumns = false;//User can't drag and hide the column
            View.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.True;//Display the summary in column lane         
            View.OptionsDetail.EnableMasterViewMode = false; //Disable group

            //Alignments
            View.Appearance.HeaderPanel.TextOptions.HAlignment = alignment;
            View.Appearance.Row.TextOptions.HAlignment = alignment;
            View.Appearance.GroupFooter.TextOptions.HAlignment = alignment;//Center the display

            //Editable
            //Disable edit(Notice: All editors in grid will be affected include Buttons, ComboBox)
            //To set editable for seperate items, enable edit first, then disable edit in specific column
            //nameColumn.OptionsColumn.AllowEdit = false;
            View.OptionsBehavior.Editable = EnableEdit;

            //New row
            View.OptionsView.NewItemRowPosition = ShowNewRow ? NewItemRowPosition.Bottom : NewItemRowPosition.None; //Hide new function row
        }

        private void TsFlowControl_Toggled(object sender, EventArgs e)
        {
            config.Port.EnableFlowControl = tsFlowControl.IsOn;
        }

        private void InitOperations()
        {
            lock (csPublic.InkSystem.lockComLog)
            {
                gcReceive.DataSource = csPublic.InkSystem.ComLog;
            }
         

            //Start UI update timer
            System.Windows.Forms.Timer tUpdate = new System.Windows.Forms.Timer();
            tUpdate.Interval = 100;
            tUpdate.Tick += TUIUpdate_Elapsed;
            tUpdate.Start();


            //Start operation thread
            Thread tOperation = new Thread(ProcessOperation);
            tOperation.IsBackground = true;
            tOperation.Start();
        }


        private void TbReceive1_TextChanged(object sender, EventArgs e)
        {
            //Put this in event to make sure same location reached every time

        }

        private void TUIUpdate_Elapsed(object sender, EventArgs e)
        {
            var tUpdate = (System.Windows.Forms.Timer)sender;
            tUpdate.Enabled = false; //Avoid overflow

            //Auto exit
            if (UIExit) return;

            //Refresh data to UI
            RefreshReceivedData();
            ShowDeviceInfo();
            UpdateSerialPortConnection();

            tUpdate.Enabled = true; //Avoid overflow
        }

        private void UpdateSerialPortConnection()
        {
            bool isConected = csPublic.InkSystem.IsConnected;

            if (isConected)
            {
                bOpen.Enabled = false;
                bDisconnect.Enabled = true;
            }
            else
            {
                bOpen.Enabled = true;
                bDisconnect.Enabled = false;
            }
        }

        private async void ProcessOperation()
        {
            //Disable loop querry by default.
            loopBlock.EnableBlock = true;

            while (!UIExit)
            {
                Thread.Sleep(100);

                //Check operation pause flag
                if (loopBlock.EnableBlock)
                {
                    loopBlock.IsBlocked = true;
                    continue;
                }

                if (!config.EnableUpdate) continue;

                //Attempt to fetch data from ink devices
                await UpdateDeviceInfo();
            }

            //Finish up
            FinishUpClosing();
        }

        private void RefreshReceivedData()
        {
            if (!gcReceive.Focused)
            {
                lock (csPublic.InkSystem.lockComLog)
                {
                    gcReceive.RefreshDataSource();
                }
                gvReceive.MoveLast();
            }
        }



        private void ShowDeviceInfo()
        {
            //Show device info
            if (TargetDeviceID > -1 && TargetDeviceID < Devices.Count)
            {
                //Get selected device
                var device = Devices[TargetDeviceID];
                lBackPressure.Text = device.BackPressure.ToString("F2");
                lRecirculation.Text = device.RecirculationPressure.ToString("F2");
                lHeaterTemp.Text = device.HeaterTemp.ToString("F2");
                lInkTemp.Text = device.InkTempreture.ToString("F2");
                lStatusBits.Text = device.StatusBits.ToString("F2");
                lAlarm.Text = device.Alarm.ToString("F2");

                //Display parameters
                if (!tsMeniscusPressure.IsOn)
                    teMeniscusPressure.Text = device.MeniscusPressureSetPoint.ToString("F2");
                if (!tsHeaterSetPoint.IsOn)
                    teHeaterSetPoint.Text = device.HeaterSetPoint.ToString("F2");
                if (!tsFillPumpSpeed.IsOn)
                    teFillPumpSpeed.Text = device.FillPumpSpeedSetPoint.ToString("F2");
                if (!tsFillPumpTimeout.IsOn)
                    teFillPumpTimeout.Text = device.FillPumpTimeout.ToString("F2");
                if (!tsPurgeTime.IsOn)
                    tePurgeTime.Text = device.PurgeTimeSetPoint.ToString("F2");
                if (!tsPurgePressure.IsOn)
                    tePurgePressure.Text = device.PurgePressureSetpoint.ToString("F2");
                if (!tsStartupDelay.IsOn)
                    teStartupDelay.Text = device.StartUpDelay.ToString("F2");
                if (!tsBypassTime.IsOn)
                    teBypassTime.Text = device.ByPassTime.ToString("F2");
            }
        }


        private async Task UpdateDeviceInfo()
        {
            //Start from 1, 0 is default device when there is no network
            for (int i = 0; i < DeviceNetwork.Count; i++)
            {
                int iDeviceID = DeviceNetwork[i];
                var currentDevice = Devices[iDeviceID];

                //Read status
                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetDeviceStatus, iDeviceID))
                    csPublic.InkSystem.DataBuffer.CopyDeviceStatus(ref currentDevice);

                //Read parameters
                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetMeniscusPressure, iDeviceID))
                    currentDevice.MeniscusPressureSetPoint = csPublic.InkSystem.DataBuffer.MeniscusPressureSetPoint;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetHeaterSetpoint, iDeviceID))
                    currentDevice.HeaterSetPoint = csPublic.InkSystem.DataBuffer.HeaterSetPoint;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetFillPumpSpeed, iDeviceID))
                    currentDevice.FillPumpSpeedSetPoint = csPublic.InkSystem.DataBuffer.FillPumpSpeedSetPoint;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetFillPumpTimeout, iDeviceID))
                    currentDevice.FillPumpTimeout = csPublic.InkSystem.DataBuffer.FillPumpTimeout;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetPurgeTime, iDeviceID))
                    currentDevice.PurgeTimeSetPoint = csPublic.InkSystem.DataBuffer.PurgeTimeSetPoint;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetPurgePressure, iDeviceID))
                    currentDevice.PurgePressureSetpoint = csPublic.InkSystem.DataBuffer.PurgePressureSetpoint;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetStartupDelay, iDeviceID))
                    currentDevice.StartUpDelay = csPublic.InkSystem.DataBuffer.StartUpDelay;

                if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetBypassTime, iDeviceID))
                    currentDevice.ByPassTime = csPublic.InkSystem.DataBuffer.ByPassTime;

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
                    tsFlowControl.IsOn = config.Port.EnableFlowControl;
                    lueSendFormat.EditValue = config.SendFormat.ToString();
                    lueReceiveFormat.EditValue = config.ReceiveFormat.ToString();
                    lueSendSuffix.EditValue = config.EndSuffixView;
                    lueSendMode.EditValue = config.SendMode.ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in apply settings!\r\n" + e.Message);
                }
            }
        }

        /// <summary>
        /// Read current selected device ID
        /// </summary>
        /// <returns></returns>
        private int GetTargetDeviceID()
        {
            //Check selection
            if (lbDevices.Items.Count < 1 || lbDevices.SelectedIndex < 0) return 0;

            //Check data match
            if (lbDevices.Items.Count != DeviceNetwork.Count) return 0;

            //Get selection
            return DeviceNetwork[lbDevices.SelectedIndex];
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

        private void cbVerify_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Port.ParityIndex = cbVerify.SelectedIndex;
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

            await loopBlock.BlockAndWaitAsync();

            if (await csPublic.InkSystem.TryGetDeviceList())
            {
                for (int i = 0; i < csPublic.InkSystem.DataBuffer.DeviceList.Count; i++)
                {
                    string sDevice = $"Device:{csPublic.InkSystem.DataBuffer.DeviceList[i]}";
                    lbDevices.Items.Add(sDevice);
                }

                //Set current device list
                DeviceNetwork = csPublic.InkSystem.DataBuffer.DeviceList.ToList();
            }

            loopBlock.StopBlock();
        }

        private void tsEnableUpdate_Toggled(object sender, EventArgs e)
        {
            config.EnableUpdate = tsEnableUpdate.IsOn;
        }

        private async void bFetch_Click(object sender, EventArgs e)
        {

            await loopBlock.BlockAndWaitAsync();

            //Get id
            await UpdateDeviceInfo();

            loopBlock.StopBlock();
        }


        private void tsEnableEdit_Toggled(object sender, EventArgs e)
        {
            teMeniscusPressure.ReadOnly = !tsMeniscusPressure.IsOn;
        }
        private async void bApplyMeniscusPressure_Click(object sender, EventArgs e)
        {
            if (teMeniscusPressure.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teMeniscusPressure.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetMeniscusPressure, TargetDeviceID, dValue))
            {
                tsMeniscusPressure.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void tsHeaterSetPoint_Toggled(object sender, EventArgs e)
        {
            teHeaterSetPoint.ReadOnly = !tsHeaterSetPoint.IsOn;
        }

        private async void bHeaterSetPoint_Click(object sender, EventArgs e)
        {
            if (teHeaterSetPoint.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teHeaterSetPoint.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetHeaterSetpoint, TargetDeviceID, dValue))
            {
                tsHeaterSetPoint.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void tsFillPumpSpeed_Toggled(object sender, EventArgs e)
        {
            teFillPumpSpeed.ReadOnly = !tsFillPumpSpeed.IsOn;
        }

        private void tsFillPumpTimeout_Toggled(object sender, EventArgs e)
        {
            teFillPumpTimeout.ReadOnly = !tsFillPumpTimeout.IsOn;
        }

        private void tsPurgeTime_Toggled(object sender, EventArgs e)
        {
            tePurgeTime.ReadOnly = !tsPurgeTime.IsOn;
        }

        private void tsPurgePressure_Toggled(object sender, EventArgs e)
        {
            tePurgePressure.ReadOnly = !tsPurgePressure.IsOn;
        }

        private void tsStartupDelay_Toggled(object sender, EventArgs e)
        {
            teStartupDelay.ReadOnly = !tsStartupDelay.IsOn;
        }

        private void tsBypassTime_Toggled(object sender, EventArgs e)
        {
            teBypassTime.ReadOnly = !tsBypassTime.IsOn;
        }

        private async void bFillPumpSpeed_Click(object sender, EventArgs e)
        {
            if (teFillPumpSpeed.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teFillPumpSpeed.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetFillPumpSpeed, TargetDeviceID, dValue))
            {
                tsFillPumpSpeed.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bFillPumpTimeout_Click(object sender, EventArgs e)
        {
            if (teFillPumpTimeout.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teFillPumpTimeout.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetFillPumpTimeout, TargetDeviceID, dValue))
            {
                tsFillPumpTimeout.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bPurgeTime_Click(object sender, EventArgs e)
        {
            if (tePurgeTime.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(tePurgeTime.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetPurgeTime, TargetDeviceID, dValue))
            {
                tsPurgeTime.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bPurgePressure_Click(object sender, EventArgs e)
        {
            if (tePurgePressure.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(tePurgePressure.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetPurgePressure, TargetDeviceID, dValue))
            {
                tsPurgePressure.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bStartupDelay_Click(object sender, EventArgs e)
        {
            if (teStartupDelay.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teStartupDelay.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetStartupDelay, TargetDeviceID, dValue))
            {
                tsStartupDelay.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bBypassTime_Click(object sender, EventArgs e)
        {
            if (teBypassTime.ReadOnly) return;
            if (lbDevices.SelectedIndex < 0) return;
            //Get set value
            if (!double.TryParse(teBypassTime.Text, out double dValue)) return;
            //Try set value
            if (await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetBypassTime, TargetDeviceID, dValue))
            {
                tsBypassTime.IsOn = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void bResetAlarm_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetParameter(InkSysCommandType.ResetAlarms, TargetDeviceID))
                MessageBox.Show("Error");
        }

        private async void bPurge_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetBypassTime, TargetDeviceID))
                MessageBox.Show("Error");
        }

        private async void bActivateDrainSystem_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetDrainSystem, TargetDeviceID, 1))
                MessageBox.Show("Error");
        }

        private async void bDisableDrainSystem_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetParameter(InkSysCommandType.SetDrainSystem, TargetDeviceID, 0))
                MessageBox.Show("Error");
        }

        private async void bDegassEnable_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetSystemFunction((int)InkSystemFunction.EnableDegass, true, TargetDeviceID))
                MessageBox.Show("Error");


        }

        private async void bDegassDisable_Click(object sender, EventArgs e)
        {
            //Try set value
            if (!await csPublic.InkSystem.TrySetSystemFunction((int)InkSystemFunction.EnableDegass, false, TargetDeviceID))
                MessageBox.Show("Error");
        }

        private async void bSystemFunctionRead_Click(object sender, EventArgs e)
        {
            //Try set value
            if (await csPublic.InkSystem.TryReadData2(InkSysCommandType.GetSystemFunction, TargetDeviceID))
            {
                UInt16 iValue = csPublic.InkSystem.DataBuffer.SystemFunction;
                string sBinary = Convert.ToString(iValue, 2);
                MessageBox.Show($"System:{iValue}\r\n{sBinary}");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void lueSendMode_EditValueChanged(object sender, EventArgs e)
        {
            //Get setting
            string sValue = lueSendMode.EditValue.ToString();
            if (Enum.TryParse(sValue, out SerialSendMode serialSendMode))
            {
                config.SendMode = serialSendMode;
            }
            else
            {//Set to default
                config.SendMode = SerialSendMode.Normal;
            }
        }

        private void tsFlowControl_Toggled_1(object sender, EventArgs e)
        {

        }

        private void tsCommandEnable_Toggled(object sender, EventArgs e)
        {

        }
    }
}
