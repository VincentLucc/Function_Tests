using DevExpress.XtraEditors.TextEditController.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionPGP
{
    public class csPublic
    {
        public static bool? IsBinaryFile(string path)
        {
            try
            {
                long length = new FileInfo(path).Length; //May except if null or empty

                if (length == 0) return null;

                using (StreamReader reader = new StreamReader(path))
                {
                    int iChar, iCount = 0;

                    while ((iChar = reader.Read()) != -1)
                    {
                        iCount += 1;
                        if (iCount > 10000) break; //Only check maximum 10000 char
                        if (IsControlChar(iChar))
                            return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("IsBinaryFile:\r\n" + e.Message);
                return null;
            }

            return false;
        }


        /// <summary>
        /// Is current char used for formatting control
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private static bool IsControlChar(int ch)
        {
            return (ch > Chars.NUL && ch < Chars.BS) || (ch > Chars.CR && ch < Chars.SUB);
        }


        private static class Chars
        {
            public static char NUL = (char)0;   // Null char
            public static char BS = (char)8;    // Back Space
            public static char CR = (char)13;   // Carriage Return
            public static char SUB = (char)26;  // Substitute
        }
    }
}
