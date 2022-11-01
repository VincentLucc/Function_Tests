using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IPAddressHelper
{
    public class csIPHelper
    {
        /// <summary>
        /// Format: 233.168.3.75/24
        /// </summary>
        public const string PatternIPAddressWithShortMask = "^((?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))/(3[0-2]|[0-2][0-9]|[0-9])$";


     

        public static bool ParseIPv4WithMask(string sIPv4withMask, out string IPString, out string MaskString)
        {
            //Check ip address format
            IPString = "";
            MaskString= "";
            
            var ipData = Regex.Match(sIPv4withMask, PatternIPAddressWithShortMask);
       
            if (ipData.Groups.Count != 3) return false;

            IPString = ipData.Groups[1].Value;
            string sMask = GetSubnetMaskString(ipData.Groups[2].Value);
       
            MaskString = sMask;

            return true;
        }

        public static bool ParseIPv4WithMask(string sIPv4withMask, out IPAddress IP, out IPAddress Mask)
        {
            //Check ip address format
            IP = null;
            Mask = null;

            var ipData = Regex.Match(sIPv4withMask, PatternIPAddressWithShortMask);
            if (ipData.Groups.Count != 3) return false;

            IP = IPAddress.Parse(ipData.Groups[1].Value);
            string sMask = GetSubnetMaskString(ipData.Groups[2].Value);
            Mask = IPAddress.Parse(sMask);

            //Pass all steps
            return true;
        }

        public static string GetSubnetMaskString(string sNetMaskShort)
        {
            //Init variables
            string sSubMask = "";
            int iSubMask = 0;
            if (!int.TryParse(sNetMaskShort, out iSubMask)) return "";


            //Convert to long text mask
            for (int i = 8; i <= 32; i += 8)
            {
                if (iSubMask >= i)
                {
                    if (i == 32)
                    {
                        sSubMask += "255";
                    }
                    else
                    {
                        sSubMask += "255.";
                    }
                }
                else
                {
                    //1-8
                    int iSectionCount = 8 - (i - iSubMask);

                    //Convert to 0-255 value
                    int iSectionValue = 0;
                    for (int j = 0; j < iSectionCount; j++)
                    {
                        int iBitValue = (int)Math.Pow(2, (7 - j));
                        iSectionValue += iBitValue;
                    }

                    if (i == 32)
                    {
                        sSubMask += iSectionValue.ToString();
                    }
                    else
                    {
                        sSubMask += iSectionValue.ToString() + ".";
                    }
                  
                }
            }

            return sSubMask;
        }
    }
}
