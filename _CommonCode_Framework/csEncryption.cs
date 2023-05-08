using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _CommonCode_Framework
{
    public class csEncryption
    {

        private string _description;

        public string Description
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_description))
                {
                    return "Undefined";
                }
                else
                {
                    return _description;
                }
          
            }
            set { _description = value; }
        }

        public string KeyString { get; set; }
        public string VectorString { get; set; }
        public byte[] KeyByte { get; set; }
        public byte[] VectorByte { get; set; }

        /// <summary>
        /// Values after the string
        /// </summary>
        public PaddingMode Padding { get; set; }

        public CipherMode Mode { get; set; }

        public int KeySize { get; set; }

        public int BlockSize { get; set; }

        public csEncryption()
        {
            InitParameters();
        }

        public void InitParameters()
        {
            //Init default settings
            Padding = PaddingMode.PKCS7;
            Mode = CipherMode.CBC;
            KeySize = 256;
            BlockSize = 128;
            Description = "Default";

            //Create default key
            KeyString = "W7xJ1G2xUDVHENLzCsgaE2cei3y0C72YxwBm8DC/w0Y=";//AES Key
            KeyByte = Convert.FromBase64String(KeyString);
            VectorString = "0qMAoH6Wz/f6CPgWLBsb4A==";//AES vector
            VectorByte = Convert.FromBase64String(VectorString);
        }


        public void LoadParameters(Aes theAES)
        {
            theAES.Padding = Padding;
            theAES.Mode = Mode;

            theAES.KeySize = KeySize;
            theAES.BlockSize = BlockSize;

            theAES.Key = KeyByte;
            theAES.IV = VectorByte;
        }

        /// <summary>
        /// Set key based on base64 string
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sVector"></param>
        public void SetAesKey(string sKey, string sVector)
        {
            KeyString = sKey;
            KeyByte = Convert.FromBase64String(KeyString);

            VectorString = sVector;
            VectorByte = Convert.FromBase64String(VectorString);
        }

        /// <summary>
        /// Set key based on byte array
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sVector"></param>
        public void SetAesKey(byte[] bKey, byte[] bVector)
        {
            KeyByte = bKey;
            KeyString = Convert.ToBase64String(KeyByte);

            VectorByte = bVector;
            VectorString = Convert.ToBase64String(VectorByte);
        }

        public void GenerateNew(bool IgnoreVector = false)
        {
            Aes theAes = Aes.Create();
            KeyByte = theAes.Key;
            KeyString = Convert.ToBase64String(theAes.Key);

            if (!IgnoreVector)
            {
                VectorByte = theAes.IV;
                VectorString = Convert.ToBase64String(theAes.IV);
            }
        }

        public byte[] EncryptToAesByte(string Input)
        {
            //Init variables
            byte[] bResult = null;
            Aes theAES = Aes.Create();
            LoadParameters(theAES);

            try
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = theAES.CreateEncryptor(theAES.Key, theAES.IV);

                //Create stream for encryption
                using (MemoryStream msAES = new MemoryStream())
                {
                    using (CryptoStream csAES = new CryptoStream(msAES, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(csAES))
                        {
                            sw.Write(Input); //Write to Stream
                        }
                    }

                    //Get result
                    bResult = msAES.ToArray(); //to byte array
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csEncryption.EncryptAES:\r\n" + ex.Message);
            }

            //Finish up
            theAES.Dispose();
            return bResult;
        }

        public string EncryptToAesString(string Input)
        {
            //Init variables
            byte[] bResult = EncryptToAesByte(Input);
            if (bResult == null) return null;
            string sResult = Convert.ToBase64String(bResult);
            return sResult;
        }

        public string DecryptFromAesByte(byte[] bData)
        {
            //variables
            Aes theAES = Aes.Create();
            string sResult = null;

            //Set values
            LoadParameters(theAES);

            try
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform decryptor = theAES.CreateDecryptor(theAES.Key, theAES.IV);

                //Create stream for encryption
                using (MemoryStream msAES = new MemoryStream(bData))
                {
                    using (CryptoStream csAES = new CryptoStream(msAES, decryptor, CryptoStreamMode.Read))
                    {

                        using (StreamReader srAES = new StreamReader(csAES))
                        {
                            sResult = srAES.ReadToEnd();//Get result                                      
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csEncryption.DecryptFromAesByte:\r\n" + ex.Message);
                sResult = null;
            }


            //release memory
            theAES.Dispose();
            return sResult;
        }

        public string DecryptAesFromBase64String(string Input)
        {
            byte[] bData = Convert.FromBase64String(Input);
            string sResult = DecryptFromAesByte(bData);
            return sResult;
        }

        /// <summary>
        /// Customized method
        /// Decrypt a hex string, treat the data as ASCII encoded text
        /// Then decrypt that text
        /// </summary>
        /// <param name="inputEncrypt"></param>
        /// <returns></returns>
        public string DecryptAesFromHEX(string inputEncrypt)
        {
            // Create AesManaged    
            try
            {
                inputEncrypt = inputEncrypt.Trim();
                //Null verify
                if (inputEncrypt == "" || inputEncrypt.StartsWith("00"))
                {//can't covert 0x00 to ASCII word
                    return "";
                }

                //Convert to HEX to ASCII string
                string sBase64 = csHex.HexStringToASCIIString(inputEncrypt);

                //Treat this string as base 64 string
                //This is customized, for backward compatibility
                Debug.WriteLine($"Base64:{sBase64}");
                return DecryptAesFromBase64String(sBase64);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DecryptAesFromHEX:\r\n" + ex.Message);
                return "";
            }
        }

        /// <summary>
        /// Create MD5 bytes
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateMD5Bytes(byte[] bInput)
        {
            // Use input string to calculate MD5 hash
            byte[] hashBytes = null;
            using (MD5 md5 = MD5.Create())
            {
                hashBytes = md5.ComputeHash(bInput);
            }
            return hashBytes;
        }

        /// <summary>
        /// Create MD5 but only take first 4 bytes of data
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateMD5Bytes_4Bytes(byte[] bInput)
        {
            var md5Hash = CreateMD5Bytes(bInput);
            //Check length
            if (md5Hash == null || md5Hash.Length < 4) return null;

            // Use input string to calculate MD5 hash
            byte[] bHash4Bytes = new byte[4];

            Array.Copy(md5Hash, bHash4Bytes, 4);
            return bHash4Bytes;
        }

        public static string CreateMD5String_4Bytes(string sInput)
        {
            if (string.IsNullOrWhiteSpace(sInput)) return null;
            var bMd5 = CreateMD5Bytes_4Bytes(csHex.HexStringToHexByte(sInput));
            string sMd5 = BitConverter.ToString(bMd5).Replace("-", "");
            return sMd5;
        }
    }
}
