using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuickTests
{
    class csPublic
    {
        //App Strings
        public static string TimeString => DateTime.Now.ToString("HH:mm:ss:fff");
        public static string AppPath => Path.GetDirectoryName(Application.ExecutablePath);

        public static bool IsValidPath(string path)
        {
            try
            {
                if (Directory.Exists(path)) return true;              
            }
            catch (Exception ex)
            {
                Debug.WriteLine("IsValidPath:\r\n"+ex.Message);
            }

            //Fail to pass check
            return false;
        }
    }
}
