using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionPGP
{
    public class csConfig
    {
        public string KeysFolder { get; set; }
        public string PublicKeyPath { get; set; }
        public string PrivateKeyPath { get; set; }
        public string Password { get; set; }
        public csConfig() { }
    }
}
