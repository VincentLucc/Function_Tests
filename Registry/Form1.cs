using _CommonCode_Framework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RegistryTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {

            string sRoot = $"HKEY_LOCAL_MACHINE\\SOFTWARE\\TestApp";
            Registry.SetValue(sRoot, "123", "abc");

            //Set version, default object is string
            Registry.SetValue(sRoot, "Version", "Ver.123456");
            //Set size int
            Registry.SetValue(sRoot, "Size", 16, RegistryValueKind.DWord);
            //Setbinary data
            var bData = new byte[8];
            Registry.SetValue(sRoot, "Data", bData, RegistryValueKind.Binary);



            var Result = Registry.GetValue(sRoot, "Data", -1);

            //Show all info
            Debug.WriteLine($"Reg_Path:{sRoot}");
            using (var appRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TestApp"))
            {
                foreach (var keyName in appRoot.GetValueNames())
                {
                    var keyValue = appRoot.GetValue(keyName, -1);

                    string sValueOuput = "";
                    if (keyValue is byte[])
                    {
                        sValueOuput = BitConverter.ToString((byte[])keyValue).Replace("-", " ");
                    }
                    else
                    {
                        sValueOuput = keyValue.ToString();
                    }

                    Debug.WriteLine($"Field:{keyName}, Value:{sValueOuput}");
                }
            }
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            //Check key node exist
            string sKeyPath = @"SOFTWARE\PackSmart\SmartJet";
            string sKeyPathFull = $"HKEY_LOCAL_MACHINE\\{sKeyPath}";
            var keyNode = Registry.LocalMachine.OpenSubKey(sKeyPath);
            if (keyNode == null)
            {
                keyNode = Registry.LocalMachine.CreateSubKey(sKeyPath);
            }

            //Check value property exist
            var bData = keyNode.GetValue("Data", null);
            if (bData == null)
            {
                bData = new byte[8];
                Registry.SetValue(sKeyPathFull, "Data", bData, RegistryValueKind.Binary);
            }
            keyNode?.Dispose();
        }
 
        private void bHold_Click(object sender, EventArgs e)
        {
            //多个应用可以同时Hold为Writable
            string sKeyPath = @"SOFTWARE\PackSmart\SmartJet";
            string sKeyPathFull = $"HKEY_LOCAL_MACHINE\\{sKeyPath}";
            var keyNode = Registry.LocalMachine.OpenSubKey(sKeyPath, true);
            var accessInfo = keyNode.GetAccessControl();

        }

        private void bThread_Click(object sender, EventArgs e)
        {
            string sKeyPath = @"SOFTWARE\PackSmart\SmartJet";
            string sKeyPathFull = $"HKEY_LOCAL_MACHINE\\{sKeyPath}";

            int i = 0;
            object lockTest = new object();
            Parallel.For(0, 300, abc =>
            {
                Stopwatch watch=new Stopwatch();
                watch.Restart();
                int x = 0;
                lock (lockTest)
                {
                    i += 1;
                    x = i;
                }


                string sHex = csHex.IntToHexString(x);
                byte[] bHex = csHex.HexStringToHexByte(sHex);
                Registry.SetValue(sKeyPathFull, "Data", bHex, RegistryValueKind.Binary);
                Debug.WriteLine("Write:"+x);

                //Try read
                var read = Registry.GetValue(sKeyPathFull, "Data", null);
                watch.Stop();
                if (read == null || !(read is byte[]))
                {
                    Debug.WriteLine("Empty Read.");
                }
                else
                {
                    string sRead = BitConverter.ToString((byte[])read);
                    csHex.HexStringToInt(sRead,out int iValue);
                    Debug.WriteLine($"Read:{sRead}:{iValue},{watch.ElapsedMilliseconds}ms");
                }
            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bRead_Click(object sender, EventArgs e)
        {
            var encryptor = new csEncryption();
            var regKey = Encoding.ASCII.GetBytes("P@CK$MARTINKMG-X");
            var regVector = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            encryptor.SetAesKey(regKey, regVector);
            encryptor.Padding = PaddingMode.Zeros;
            encryptor.Mode = CipherMode.ECB;
            encryptor.KeySize = 128;
            encryptor.BlockSize = 128;

            string sKeyPath = @"SOFTWARE\PackSmart\SmartJet";
            string sKeyPathFull = $"HKEY_LOCAL_MACHINE\\{sKeyPath}";
            var readObj = Registry.GetValue(sKeyPathFull, "Data", null);
            if (readObj == null || !(readObj is byte[]))
            {
                MessageBox.Show("error");
                return;
            }


            //Convert
            string sResult= encryptor.DecryptFromAesByte((byte[])readObj);
            Debug.WriteLine(sResult);
            MessageBox.Show(sResult);
        }
    }
}
