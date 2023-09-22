using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace _QuickTests_Framework
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
        public static string AppPath2 => Application.StartupPath;

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
        /// <typeparam name="tBase"></typeparam>
        /// <param name="target"></param>
        /// <param name="baseInstance"></param>
        public static void FillProperties<tChild, tBase>(this tChild target, tBase baseInstance)
        where tChild : tBase
        {
            Type typeChild = typeof(tChild);
            Type typeBase = typeof(tBase);
            PropertyInfo[] properties = typeBase.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                // Skip unreadable and writeprotected ones
                if (!propertyInfo.CanRead || !propertyInfo.CanWrite) continue;
                //Skip ignored property
                if (PropertyFillIgnoreList.Contains(propertyInfo.Name)) continue;
                // Read value
                object value = propertyInfo.GetValue(baseInstance, null);
                // Get Property of target class
                PropertyInfo pi_target = typeChild.GetProperty(propertyInfo.Name);
                // Write value to target
                pi_target.SetValue(target, value, null);
            }
        }

        /// <summary>
        /// When copy properties, ignore this 
        /// </summary>
        public static string[] PropertyFillIgnoreList = new string[] { nameof(Student.Description) };


        /// <summary>
        /// Directly copy the class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objOrigin"></param>
        /// <returns></returns>
        public static T DeepCopyBySerialize<T>( this T objOrigin)
        {
            object objNew;

            using (MemoryStream ms=new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, objOrigin);
                ms.Seek(0, SeekOrigin.Begin);//Use same memory stream to deserialize
                objNew = formatter.Deserialize(ms);
                ms.Close();
            }

            return (T)objNew;
        }
    }
}
