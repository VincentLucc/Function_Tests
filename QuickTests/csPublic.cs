using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuickTests
{
    public static class csPublic
    {
        //App Strings
        public static string TimeString => DateTime.Now.ToString("HH:mm:ss:fff");
        public static long TimeTick => DateTime.Now.Ticks;
        /// <summary>
        /// Nano second, 10(-9)
        /// </summary>
        public static long TimeNano=> DateTime.Now.Ticks * 100;
        public static long TimeMs => DateTime.Now.Ticks / 10000;
        public static string AppPath => Path.GetDirectoryName(Application.ExecutablePath);

        public static csLED LED;

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

        /// <summary>
        /// Extension method to copy values from parent class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tbase"></typeparam>
        /// <param name="target"></param>
        /// <param name="baseInstance"></param>
        public static void FillProperties<T, Tbase>(this T target, Tbase baseInstance)
        where T : Tbase
        {
            Type t = typeof(T);
            Type tb = typeof(Tbase);
            PropertyInfo[] properties = tb.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                // Skip unreadable and writeprotected ones
                if (!pi.CanRead || !pi.CanWrite) continue;
                // Read value
                object value = pi.GetValue(baseInstance, null);
                // Get Property of target class
                PropertyInfo pi_target = t.GetProperty(pi.Name);
                // Write value to target
                pi_target.SetValue(target, value, null);
            }
        }
    }
}
