using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HidSharp;

namespace HidSharpDemo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SerialDeviessimpleButton1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();

            var list = DeviceList.Local.GetSerialDevices();
            watch.Stop();
            Trace.WriteLine($"DeviceList:{watch.ElapsedMilliseconds}ms");


            Trace.WriteLine($"Serial Devices: {list.Count()}");
            foreach (var item in list)
            {
                Trace.WriteLine($"{item.DevicePath}");
            }
        }

        private void AllDevicesButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();

            var list = DeviceList.Local.GetAllDevices();
            watch.Stop();
            Trace.WriteLine($"DeviceList:{watch.ElapsedMilliseconds}ms");


            Trace.WriteLine($"All Devices: {list.Count()}");
            foreach (var item in list)
            {
                Trace.WriteLine($"{item.DevicePath}");
            }
        }

        private void GetCustomButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();

            var list = DeviceList.Local.GetHidDevices();
            watch.Stop();
            Trace.WriteLine($"DeviceList:{watch.ElapsedMilliseconds}ms");


            Trace.WriteLine($"All Devices: {list.Count()}");
            int iIndex = 1;
            foreach (var item in list)
            {
                Trace.WriteLine($"{iIndex} [Manu., {item.GetManufacturer()}], [Prod., {item.GetProductName()}], [PID, {item.ProductID}], [VID, {item.VendorID}], [Release, {item.ReleaseNumber}]\r\n       [Path，{item.DevicePath}]");
                iIndex += 1;

                if (item.VendorID == 2034 && item.ProductID == 3)
                {
                    if (!item.TryOpen(out HidStream stream)) continue;
                 
                }
            }


        }
    }
}
