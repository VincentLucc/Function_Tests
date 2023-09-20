using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SocketTool_Framework
{
    public class csPublic
    {

        public static string TimeString => DateTime.Now.ToString("HH:mm:ss:fff");
        public static string DateString => DateTime.Now.ToString("yyMMdd");

        public static csDevMessage messageHelper;
        public static FormMain winMain;

        /// <summary>
        /// Get mac address info
        /// </summary>
        /// <returns></returns>
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

        public static bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;

            if (bmp1.Size != bmp2.Size)
                return false;

            BitmapData data1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData data2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                unsafe
                {
                    byte* ptr1 = (byte*)data1.Scan0;
                    byte* ptr2 = (byte*)data2.Scan0;

                    int width = bmp1.Width * 4; // 4 bytes per pixel
                    int height = bmp1.Height;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (*ptr1 != *ptr2)
                                return false;

                            ptr1++;
                            ptr2++;
                        }

                        ptr1 += data1.Stride - width;
                        ptr2 += data2.Stride - width;
                    }
                }
            }
            finally
            {
                bmp1.UnlockBits(data1);
                bmp2.UnlockBits(data2);
            }

            return true;
        }


        /// <summary>
        /// Used to reduce the traffic
        /// </summary>
        /// <param name="oItem"></param>
        /// <returns></returns>
        public static string SerializeObjectIgnoreNull(object oItem)
        {
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            string sMessage = JsonConvert.SerializeObject(oItem, jsonSetting);
            return sMessage;
        }
    }


    public class RegString
    {
        public const string IPAddress = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
    }
}
