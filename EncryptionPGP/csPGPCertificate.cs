using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PGP.Certificate;

namespace EncryptionPGP
{
    public class csPGPCertificate
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Passphrase { get; set; }

        /// <summary>
        /// Memory usage only, used only request to input password once
        /// </summary>
        [XmlIgnore]
        public bool IsPassEntered { get; set; }

        public csPGPCertificate(string _publicKey, string _privateKey, string _passphrase)
        {
            PublicKey = _publicKey;
            PrivateKey = _privateKey;
            Passphrase = _passphrase;
        }

        public csPGPCertificate()
        {
            PublicKey = "";
            PrivateKey = "";
            Passphrase = "";
        }

 
        public GeneralResult LoadConfig(csConfig config)
        {
            //Init 
            GeneralResult result = new GeneralResult();

            //Check if password alread entered
            if (string.IsNullOrWhiteSpace(config.PasswordDecryption))
            {
                result.Message = "Password is empty.";
                return result;
            }

            //Check keys
            if (!PGP.Keys.PGPEncryptionKeys.IsValidPassphrase(config.PublicKeyPath, config.PrivateKeyPath, config.PasswordDecryption))
            {
                result.Message = "Invalid passphrase.";
                return result;
            }

            PublicKey = PGP.Certificate.PGPCertificate.GetKeyString(config.PublicKeyPath);
            PrivateKey = PGP.Certificate.PGPCertificate.GetKeyString(config.PrivateKeyPath);
            Passphrase = config.PasswordDecryption;

            result.IsSuccess = true;
            return result;
        }
    }

}
