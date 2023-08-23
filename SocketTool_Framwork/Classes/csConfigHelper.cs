using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SocketTool_Framework
{
    public class csConfigHelper
    {
        public static csConfigModel config;

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

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(csConfigModel));

                using (MemoryStream stream = new MemoryStream(bData))
                {
                    var configObj = xmlSerializer.Deserialize(stream);
                    if (configObj is csConfigModel)
                    {
                        config = (csConfigModel)configObj;
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

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(csConfigModel));

                using (FileStream fileStream = new FileStream(ConfigPath, FileMode.Create,
                    FileAccess.Write, FileShare.None, 8192, FileOptions.WriteThrough))
                {
                    xmlSerializer.Serialize(fileStream, config);
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
                config = new csConfigModel();
                return SaveConfig(out sMessage);
            }
        }
    }
}
