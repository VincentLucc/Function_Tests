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

        public AesKeyData AesKey { get; set; }

        public csEncryption()
        {
            AesKey = new AesKeyData();
        }

        /// <summary>
        /// Set key based on base64 string
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sVector"></param>
        public void SetKey(string sKey, string sVector)
        {
            AesKey.LoadBase64(sKey, sVector);
        }

        /// <summary>
        /// Set key based on byte array
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sVector"></param>
        public void SetKey(byte[] bKey, byte[] bVector)
        {
            AesKey.LoadByte(bKey, bVector);
        }

        public byte[] EncryptToAesByte(string Input)
        {
            //Init variables
            byte[] bResult = null;
            Aes theAES = Aes.Create();

            //Set values
            theAES.Key = AesKey.KeyByte;
            theAES.IV = AesKey.VectorByte;

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

            //set values
            theAES.Key = AesKey.KeyByte;
            theAES.IV = AesKey.VectorByte;

            //Check unput
            if (bData == null) return null;

            try
            {
                // Create an encryptor to perform the stream transform.
                ICryptoTransform decryptor = theAES.CreateDecryptor(theAES.Key, theAES.IV);

                //Create stream for encryption
                using (MemoryStream msAES = new MemoryStream(bData))
                {
                    // Create crypto stream   
                    using (CryptoStream csAES = new CryptoStream(msAES, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream 
                        using (StreamReader srAES = new StreamReader(csAES))
                        {
                            sResult = srAES.ReadToEnd();//Get result  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csEncryption.DecryptAES:\r\n" + ex.Message);
                sResult = null;
            }


            //release memory
            theAES.Dispose();
            return sResult;
        }

        public string DecryptFromAESString(string Input)
        {
            byte[] bData = Convert.FromBase64String(Input);
            string sResult = DecryptFromAesByte(bData);
            return sResult;
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

    public class AesKeyData
    {
        public string KeyString { get; set; }
        public string VectorString { get; set; }
        public byte[] KeyByte { get; set; }
        public byte[] VectorByte { get; set; }



        public AesKeyData()
        {
            KeyString = "W7xJ1G2xUDVHENLzCsgaE2cei3y0C72YxwBm8DC/w0Y=";//AES Key
            KeyByte = Convert.FromBase64String(KeyString);
            VectorString = "0qMAoH6Wz/f6CPgWLBsb4A==";//AES vector
            VectorByte = Convert.FromBase64String(VectorString);
        }

        public void LoadBase64(string sKey, string sVector)
        {
            KeyString = sKey;
            KeyByte = Convert.FromBase64String(KeyString);

            VectorString = sVector;
            VectorByte = Convert.FromBase64String(VectorString);
        }

        public void LoadByte(byte[] bKey, byte[] bVector)
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

        public static AesKeyData CreateNew(bool IgnoreVector, string sBase64Key = null)
        {
            AesKeyData keyData = new AesKeyData();
            Aes theAes = Aes.Create();

            //Set key
            try
            {
                if (string.IsNullOrEmpty(sBase64Key))
                {
                    keyData.KeyByte = theAes.Key;
                    keyData.KeyString = Convert.ToBase64String(theAes.Key);
                }
                else
                {
                    keyData.KeyByte = Convert.FromBase64String(sBase64Key);
                    keyData.KeyString = sBase64Key;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AesKeyData.CreateNew:\r\n" + ex.Message);
                return null;
            }


            //Set vector
            if (!IgnoreVector)
            {
                keyData.VectorByte = theAes.IV;
                keyData.VectorString = Convert.ToBase64String(theAes.IV);
            }

            return keyData;
        }
    }
}
