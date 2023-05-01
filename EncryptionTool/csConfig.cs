using _CommonCode_Framework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EncryptionTool
{
    [XmlRoot("Config")]
    public class csConfig
    {
        public _TextType InputType { get; set; }
        public _TextType OutputType { get; set; }
        public List<csEncryption> Encryptions { get; set; }

        /// <summary>
        /// Current selected encryption
        /// </summary>
        public int SelectedIndex { get; set; }

        [XmlIgnore]
        public csEncryption SelectedEncryption => GetSelection();

        public csConfig()
        {
            InputType = _TextType.String;
            OutputType = _TextType.String;
            Encryptions = new List<csEncryption>();
        }

        private csEncryption CreateNew()
        {
            var Encryption = new csEncryption();
            //Code method 1
            //var regKey = Convert.FromBase64String("UEBDSyRNQVJURDMxVEEtWA==");
            //var regVector = Convert.FromBase64String("AAAAAAAAAAAAAAAAAAAAAA==");
            //Encryption.SetAesKey(regKey, regVector);
            //Encryption.Padding = PaddingMode.Zeros;
            //Encryption.Mode = CipherMode.ECB;
            //Encryption.KeySize = 128;
            //Encryption.BlockSize = 128;

            //Method2
            Encryption.GenerateNew();
            var defaultKey = Convert.FromBase64String("poBOzKAk+kvj74NOIx398nVBErA1IfKVCtDdrPyTPPs=");
            var defaultVector = new byte[16];
            Encryption.SetAesKey(defaultKey, defaultVector);
            return Encryption;
        }


        private csEncryption GetSelection()
        {
            if (Encryptions == null || Encryptions.Count == 0) return null;
            if (SelectedIndex < 0 || SelectedIndex >= Encryptions.Count) return null;
            return Encryptions[SelectedIndex];
        }
    }

    public enum _TextType
    {
        [Description("Plain Text")]
        String,
        [Description("Hex String")]
        Hex,
        [Description("Base-64 String")]
        Base64String,
    }
}
