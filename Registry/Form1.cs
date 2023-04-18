using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


    }
}
