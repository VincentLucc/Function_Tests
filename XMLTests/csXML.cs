using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLTests
{
    public class csXML
    {
        /// <summary>
        /// read xml
        /// </summary>
        /// <param name="ClassType"></param>
        /// <param name="FilePath"></param>
        /// <param name="oResult"></param>
        /// <returns></returns>
        public static bool ReadXML(Type ClassType, string FilePath, out object oResult)
        {
            //Init
            oResult = new object();

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(ClassType);

                //Check file existance
                if (!File.Exists(FilePath)) return false;

                //Read xml file
                using (FileStream reader = new FileStream(FilePath, FileMode.Open))
                {
                    oResult = xmlSerializer.Deserialize(reader);
                    reader.Close();
                }


                if (oResult == null) return false;
            }
            catch (Exception e1)
            {
                Debug.WriteLine("csXML.ReadXML:\r\n" + e1.Message);
                return false;
            }


            //Pass all steps
            return true;
        }


        /// <summary>
        /// Write to xml
        /// </summary>
        /// <param name="TargetObject"></param>
        /// <param name="ClassType"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static bool WriteXML(string FilePath, object TargetObject)
        {
            try
            {
                //Init values
                XmlSerializer xmlSerializer = new XmlSerializer(TargetObject.GetType());

                //Check directory
                string sDir = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(sDir)) Directory.CreateDirectory(sDir);

                //Write to XML
                //Must enable write through to make sure write to disk instead of system cache, incase system shutdown
                using (Stream writer = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None,
                                                      8192, FileOptions.WriteThrough))
                {
                    xmlSerializer.Serialize(writer, TargetObject);
                    writer.Flush();
                    writer.Close();
                }
 
            }
            catch (Exception e1)
            {
                Debug.WriteLine("csXML.WriteXML:\r\n" + e1.Message);
                return false;
            }

            //Pass all steps
            return true;
        }
    }
}

