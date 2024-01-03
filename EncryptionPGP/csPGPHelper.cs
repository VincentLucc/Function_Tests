using DevExpress.XtraGrid;
using Org.BouncyCastle.Utilities.IO;
using PGP.Certificate;
using PGP.PGPDecryption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EncryptionPGP
{

    /// <summary>
    /// Data file result
    /// </summary>
    public class csPGPHelper
    {
        public static byte[] fileBytes;

        public static string PlainText;

        public static GeneralResult DecryptFile(string sFilePath)
        {
            var result = new GeneralResult();
            fileBytes = null;

            //Init file type
            bool isBinaryFile = false;
            if (csPublic.IsBinaryFile(sFilePath) == true) isBinaryFile = true;


            //License function allowd and user enabled this function
            //User can only run encrypted file
            if (!isBinaryFile)
            {
                result.Message = "File is not encrtpted.";
                return result;
            }


            //Get cetificate
            csPGPCertificate cetificate = new csPGPCertificate();

            //Load keys
            var certResult = cetificate.LoadConfig(csConfigHelper.Config);
            if (!certResult.IsSuccess)
            {
                result.Message = certResult.Message;
                return result;
            }

            try
            {

                //Decryption
                using (MemoryStream ms = new MemoryStream())
                using (StreamWriter sw = new StreamWriter(ms, Encoding.Default))
                {
                    sw.Write(cetificate.PrivateKey);
                    sw.Flush();
                    ms.Position = 0;

                    using (MemoryOutputStream outputStream = (MemoryOutputStream)PGPDecrypt.Decrypt2(sFilePath, ms, cetificate.Passphrase))
                    {
                        fileBytes = outputStream.ToArray();
                    }

                }



                //Decryption finished
                if (fileBytes != null && fileBytes.Length > 0)
                {
                    using (MemoryStream memStream = new MemoryStream(fileBytes))
                    {
                        using (StreamReader reader = new StreamReader(memStream))
                        {
                            PlainText = reader.ReadToEnd();
                        }
                    }
                }

                //Pass all steps
                result.IsSuccess = true;
                return result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DecryptProcedure.Exception:\r\n{ex.Message}");
                fileBytes = null;
                result.Message = ex.Message;
                return result;
            }

        }


        public static GeneralResult CreateKeyFiles(csConfig config)
        {
            var result = new GeneralResult();

            try
            {
                //Check Folder
                if (!Directory.Exists(config.NewKeysFolder))
                {
                    result.Message = "The folder doesn't exist.";
                    return result;
                }


                //Check Password
                if (string.IsNullOrWhiteSpace(config.PasswordEncryption))
                {
                    result.Message = "Password is empty.";
                    return result;
                }

                string sPublic = config.NewKeysFolder + "\\PublicKey.asc";
                string sPrivate = config.NewKeysFolder + "\\PrivateKey.asc";

                if (!PGPCertificate.GenerateKey(config.NewKeysFolder, config.PasswordEncryption, sPublic, sPrivate))
                {
                    result.Message = "Create key error.";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

            //Pass all steps
            result.IsSuccess = true;
            return result;
        }

        public static GeneralResult EncryptFile(csConfig config)
        {
            var result = new GeneralResult();


            if (string.IsNullOrWhiteSpace(config.DecryptFilePath))
            {
                result.Message = "The file path is empty.";
                return result;
            }

            if (!File.Exists(config.DecryptFilePath))
            {
                result.Message = "The file doesn't exist.";
                return result;
            }

            try
            {
                //Get the file name
                string sPublicPath = csConfigHelper.Config.PublicKeyPath;
                string sPrivatePath = csConfigHelper.Config.PrivateKeyPath;
                string sOutput = config.DecryptFilePath + ".gpg";
                //Armored file means change text to readable ascii text
                //Use the raw text mode
                PGPDecrypt.EncryptAndSign(config.DecryptFilePath, sOutput, sPublicPath, sPrivatePath, config.PasswordEncryption, false);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                result.Message = ex.Message;
                return result;
            }


            //Pass all steps
            result.IsSuccess = true;
            return result;
        }

    }

}
