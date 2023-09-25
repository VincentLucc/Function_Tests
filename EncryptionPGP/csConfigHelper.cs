using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace EncryptionPGP
{
    public class csConfigHelper
    {
        public static csConfig Config { get; set; }
        public static string ConfigPath = Application.StartupPath + @"\config.xml";
        public static bool Load(out string sMessage)
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
                    if (configObj is csConfig)
                    {
                        Config = (csConfig)configObj;
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

        public static bool Save(out string sMessage) 
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

        public static bool LoadOrCreateConfig(out string sMessage)
        {
            sMessage = "";

            if (File.Exists(ConfigPath))
            {//File exist, directly load
                return Load(out sMessage);
            }
            else
            {//File not exist, create a new and save
                Config = new csConfig();
                return Save(out sMessage);
            }
        }
    }
}
