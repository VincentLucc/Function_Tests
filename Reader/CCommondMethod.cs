// Decompiled with JetBrains decompiler
// Type: Reader.CCommondMethod
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Reader
{
    public class CCommondMethod
    {
        public static byte[] StringToByteArray(string strHexValue)
        {
            string[] strArray = strHexValue.Split(' ');
            byte[] numArray = new byte[strArray.Length];
            try
            {
                int index = 0;
                foreach (string str in strArray)
                {
                    numArray[index] = Convert.ToByte(str, 16);
                    ++index;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CCommondMethod.StringToByteArray:\r\n" + ex.Message);
            }
            return numArray;
        }

        public static byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
                nLen = strAryHex.Length;
            byte[] numArray = new byte[nLen];
            try
            {
                int index = 0;
                foreach (string str in strAryHex)
                {
                    numArray[index] = Convert.ToByte(str, 16);
                    ++index;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CCommondMethod.StringArrayToByteArray:\r\n" + ex.Message);
            }
            return numArray;
        }

        public static string ByteArrayToString(byte[] btAryHex, int nIndex, int nLen)
        {
            if (nIndex + nLen > btAryHex.Length)
                nLen = btAryHex.Length - nIndex;
            string str1 = string.Empty;
            for (int index = nIndex; index < nIndex + nLen; ++index)
            {
                string str2 = string.Format(" {0:X2}", (object)btAryHex[index]);
                str1 += str2;
            }
            return str1;
        }

        public static string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strArray = (string[])null;
            if (!string.IsNullOrEmpty(strValue))
            {
                ArrayList arrayList = new ArrayList();
                string str = string.Empty;
                int num = 0;
                for (int startIndex = 0; startIndex < strValue.Length; ++startIndex)
                {
                    if ((int)strValue[startIndex] != 32)
                    {
                        ++num;
                        if (!new Regex("^(([A-F])*(\\d)*)$").IsMatch(strValue.Substring(startIndex, 1)))
                            return strArray;
                        str += strValue.Substring(startIndex, 1);
                        if (num == nLength || startIndex == strValue.Length - 1 && !string.IsNullOrEmpty(str))
                        {
                            arrayList.Add((object)str);
                            num = 0;
                            str = string.Empty;
                        }
                    }
                }
                if (arrayList.Count > 0)
                {
                    strArray = new string[arrayList.Count];
                    arrayList.CopyTo((Array)strArray);
                }
            }
            return strArray;
        }
    }
}
