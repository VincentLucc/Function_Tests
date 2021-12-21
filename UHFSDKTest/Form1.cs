using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reader;

namespace UHFSDKTest
{
    public partial class Form1 : Form
    {


        csReader RFIDReader;

        public Form1()
        {
            InitializeComponent();
            csStatic.RFIDReader.m_RefreshSetting = refreshSetting;
            csStatic.RFIDReader.m_OnFastSwitchAntInventoryTagEnd = onFastSwitchAntInventoryTagEnd;
            csStatic.RFIDReader.m_OnGetInventoryBufferTagCount = onGetInventoryBufferTagCount;
            csStatic.RFIDReader.m_OnInventory6BTag = onInventory6BTag;
            csStatic.RFIDReader.m_OnInventory6BTagEnd = onInventory6BTagEnd;
            csStatic.RFIDReader.m_OnRead6BTag = onRead6BTag;
            csStatic.RFIDReader.m_OnWrite6BTag = onWrite6BTag;
            csStatic.RFIDReader.m_OnLock6BTag = onLock6BTag;
            csStatic.RFIDReader.m_OnLockQuery6BTag = onLockQuery6BTag;

            RFIDReader = csStatic.RFIDReader; //Short Alias


        }

        private void btnConnectRs232_Click(object sender, EventArgs e)
        {
            //Processing serial port to connect reader.
            string strException = string.Empty;
            string strComPort = cbComPort.Text;
            int nBaudrate = Convert.ToInt32(cbBaudrate.Text);

            int nRet = csStatic.RFIDReader.OpenCom(strComPort, nBaudrate, out strException);
            if (nRet != 0)
            {
                string strLog = "Connection failed, failure cause: " + strException;
                Console.WriteLine(strLog);

                return;
            }
            else
            {
                string strLog = "Connect" + strComPort + "@" + nBaudrate.ToString();
                Console.WriteLine(strLog);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.CloseCom();
            Console.WriteLine("close Serial port!");
        }


        void refreshSetting(ReaderSetting readerSetting)
        {
            Console.WriteLine("Version:" + readerSetting.btMajor + "." + readerSetting.btMinor);
        }








        void onFastSwitchAntInventoryTagEnd(RXFastSwitchAntInventoryTagEnd tagEnd)
        {
            Console.WriteLine("Fast Inventory end:" + tagEnd.mTotalRead);
        }

        void onInventory6BTag(byte nAntID, String strUID)
        {
            Console.WriteLine("Inventory 6B Tag:" + strUID);
        }

        void onInventory6BTagEnd(int nTagCount)
        {
            Console.WriteLine("Inventory 6B Tag:" + nTagCount);
        }

        void onRead6BTag(byte antID, String strData)
        {
            Console.WriteLine("Read 6B Tag:" + strData);
        }

        void onWrite6BTag(byte nAntID, byte nWriteLen)
        {
            Console.WriteLine("Write 6B Tag:" + nWriteLen);
        }

        void onLock6BTag(byte nAntID, byte nStatus)
        {
            Console.WriteLine("Lock 6B Tag:" + nStatus);
        }

        void onLockQuery6BTag(byte nAntID, byte nStatus)
        {
            Console.WriteLine("Lock query 6B Tag:" + nStatus);
        }

        void onGetInventoryBufferTagCount(int nTagCount)
        {
            Console.WriteLine("Get Inventory Buffer Tag Count" + nTagCount);
        }









        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            //csStatic.RFIDReader.ReadTag((byte)0xFF, (byte)0x02, (byte)0x00, (byte)0x06, new byte[] { (byte)0x00, (byte)0x00, (byte)0x00 });
            csStatic.RFIDReader.ReadTag(csReader.DeviceID, (byte)0x01, (byte)0x00, (byte)0x08,csReader.AccessCode);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte bRetry = GetRetry();
            RFIDReader.CurrentCommand.Init(CMD.INVENTORY);
            csStatic.RFIDReader.Inventory((byte)0xFF, bRetry);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.GetInventoryBufferTagCount((byte)0xFF);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.GetFirmwareVersion((byte)0xFF);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.InventoryISO18000((byte)0xFF);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.ReadTagISO18000((byte)0xff, new byte[] { (byte)0xE0, (byte)0x04, (byte)0x00, (byte)0x00, (byte)0xF6, (byte)0x78, (byte)0x41, (byte)0x06 }, (byte)0x00, (byte)0x06);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.GetInventoryBuffer((byte)0xff);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.Reset((byte)0xFF);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbBaudrate.SelectedIndex = 1;

            //Init events
        }



        private byte GetRetry()
        {
            if (int.TryParse(tbRetry.Text,out int iResult))
            {
                //Cehck range
                if (iResult>0 && iResult<256)
                {
                    return (byte)iResult;
                }
            }


            MessageBox.Show("Invalid input 0x10 will be used.");
            return 0x10;
        }

        private void bReadUser_Click(object sender, EventArgs e)
        {
           
        }

        private void bBeepOn_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.SetBeeperMode((byte)0xFF, (byte)0x01);
        }

        private void bBeepOff_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.SetBeeperMode((byte)0xFF, (byte)0x00);
        }

        private void bPower_Click(object sender, EventArgs e)
        {
            if (cbPower.SelectedIndex < 0)
            {
                return;
            }

            //Get power
            byte bPower = CalPowerLevel(cbPower.SelectedIndex + 1);

            if (!csStatic.RFIDReader.TrySetPower(bPower))
            {
                MessageBox.Show("error");
            }

            Debug.WriteLine($"Power Set:{bPower}");
        }

        /// <summary>
        /// Power Level from 1 to 10
        /// </summary>
        /// <param name="Power"></param>
        private byte CalPowerLevel(int iPower)
        {
            //Device power range  0 to 33(0x00 – 0x21), the unit is dBm.
            byte bPower = (byte)10; //Gave a default value

            //Check range
            if (iPower > 10 || iPower < 1)
            {
                return bPower;
            }

            //Get power
            bPower = (byte)(iPower * 2);
            return bPower;
        }

        private void bPowerRead_Click(object sender, EventArgs e)
        {
            csStatic.RFIDReader.CurrentCommand.Init(CMD.GET_OUTPUT_POWER);
            csStatic.RFIDReader.GetOutputPower(0xff);
        }

        private void bBufferReset_Click(object sender, EventArgs e)
        {
            RFIDReader.ResetInventoryBuffer(csReader.DeviceID);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            csStatic.RFIDReader.TryInventoryReal();
        }

        private void bGetAndResetBuffer_Click(object sender, EventArgs e)
        {
            RFIDReader.GetAndResetInventoryBuffer(csReader.DeviceID);
        }

        private void bShowCurrentTags_Click(object sender, EventArgs e)
        {
            //Copy list
            RFIDReader.DetectedTags = RFIDReader.CurrentCommand.Tags.ToList();
            Debug.WriteLine("Current list:");
            foreach (var item in RFIDReader.DetectedTags)
            {
                Debug.WriteLine(item.strEPC);
            }
        }

        private void bSwetCurrentTag_Click(object sender, EventArgs e)
        {
            RFIDReader.TrySetOperationTag();
        }

        private void bWriteUser_Click(object sender, EventArgs e)
        {
            //Get data
            var data=csCRC.StringToHexByte(tbInput.Text);

            if (!RFIDReader.TryWriteTag(TagDataType.User,data))
            {
                MessageBox.Show("Error");
            }
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            string sResult=null;
            if (!RFIDReader.TryReadTag(TagDataType.User, ref sResult))
            {
                MessageBox.Show("Error");
                return;
            }

            MessageBox.Show(sResult);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sResult = null;
            if (!RFIDReader.TryReadTag(TagDataType.EPC, ref sResult))
            {
                MessageBox.Show("Error");
                return;
            }

            MessageBox.Show(sResult);
        }

        private void bPassWrite_Click(object sender, EventArgs e)
        {
            //Get data
            var data = csCRC.StringToHexByte(tbInput.Text);

            if (!RFIDReader.TryWriteTag(TagDataType.Reserved, data))
            {
                MessageBox.Show("Error");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            var iCount = RFIDReader.TryInventoryReal2();

            Debug.WriteLine($"InventoryCount:{iCount}");

            if (iCount==-1)
            {
                MessageBox.Show("Error");
            }
        }

        private void btInventoryRealStart_Click(object sender, EventArgs e)
        {
            RFIDReader.InitCommand(CMD.REAL_TIME_INVENTORY, true);
            RFIDReader.InventoryReal((byte)0xFF, (byte)0x01);
        }

        private void btInventoryRealStop_Click(object sender, EventArgs e)
        {
            RFIDReader.CurrentCommand.IsLoop = false;
            RFIDReader.DetectedTags = RFIDReader.CurrentCommand.Tags;
        }

        private void bWriteEPC_Click(object sender, EventArgs e)
        {
            //Get data
            var data = csCRC.StringToHexByte(tbInput.Text);

            if (!RFIDReader.TryWriteTag(TagDataType.EPC, data))
            {
                MessageBox.Show("Error");
            }
        }

        private void bReadReserve_Click(object sender, EventArgs e)
        {
            string sResult = null;
            if (!RFIDReader.TryReadTag(TagDataType.Reserved, ref sResult))
            {
                MessageBox.Show("Error");
                return;
            }

            MessageBox.Show(sResult);
        }

        private void bGetCurrentTag_Click(object sender, EventArgs e)
        {
            RFIDReader.TryGetOperationTag();
        }
    }
}
