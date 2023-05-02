using _CommonCode_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace EncryptionTool
{
    public class csConfigureHelper
    {
        public static csConfig Config { get; set; }

        public static string ConfigPath = Application.StartupPath + @"\config.xml";

        public csEncryption CurrentEncryption { get; set; }

        /// <summary>
        /// Configuration loaded
        /// </summary>
        public static bool IsLoad { get; set; }

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

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(csConfig));

                using (MemoryStream stream = new MemoryStream(bData))
                {
                    var configObj = xmlSerializer.Deserialize(stream);

                    if (configObj == null)
                    {
                        sMessage = "Empty config file.";
                        return false;
                    }

                    if (configObj is csConfig)
                    {
                        Config = (csConfig)configObj;
                    }
                }

                bData = null;
                IsLoad = true;
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

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(csConfig));

                using (FileStream fileStream = new FileStream(ConfigPath, FileMode.Create,
                    FileAccess.Write, FileShare.None, 8192, FileOptions.WriteThrough))
                {
                    xmlSerializer.Serialize(fileStream, Config);
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
    }
}
