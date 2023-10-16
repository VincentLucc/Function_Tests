using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OpenCV_Sharp4
{
    public class csConfigureHelper
    {
        public static cvInspection Inspection { get; set; }

        public static string ConfigPath = Application.StartupPath + @"\config.xml";

        public static bool LoadConfig(out string sMessage)
        {
            sMessage = "";
            if (!File.Exists(ConfigPath))
            {
                sMessage = "Unable to find the config file.";
                return false;
            }

            try
            {
                var bData = File.ReadAllBytes(ConfigPath);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(cvInspection));

                using (MemoryStream stream = new MemoryStream(bData))
                {
                    var configObj = xmlSerializer.Deserialize(stream);
                    if (configObj is cvInspection)
                    {
                        Inspection = (cvInspection)configObj;
                    }
                }

                bData = null;

                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("LoadConfig:\r\n" + ex.Message);
                sMessage = "Error while loading the config file.\r\n" + ex.Message;
            }


            return false;
        }

        public static bool SaveConfig(out string sMessage)
        {
            sMessage = "";
            try
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(cvInspection));

                using (FileStream fileStream = new FileStream(ConfigPath, FileMode.Create,
                    FileAccess.Write, FileShare.None, 8192, FileOptions.WriteThrough))
                {
                    xmlSerializer.Serialize(fileStream, Inspection);
                }

                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("LoadConfig:\r\n" + ex.Message);
                sMessage = "Error while loading the config file.\r\n" + ex.Message;
            }

            //Fail
            return false;
        }

        public static bool LoadOrCreateConfig(out string sMessage)
        {
            sMessage = "";

            if (File.Exists(ConfigPath))
            {//File exist, directly load
                return LoadConfig(out sMessage);
            }
            else
            {//File not exist, create a new and save
                Inspection = new cvInspection();
                return SaveConfig(out sMessage);
            }
        }
    }
}
