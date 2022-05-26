using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprintCode
{
    class csAprintOperation
    {
        static string KeyString = "NoInkPsmCanada";
        static byte[] KeyArray => Encoding.ASCII.GetBytes(KeyString);
        public static byte[] EncodeInkData(InkInfo inkData)
        {
            //Prepare data
            byte[] Buf = new byte[16];
            Buf[0] = Convert.ToByte('i');
            Buf[1] = Convert.ToByte('n');
            Buf[2] = Convert.ToByte('k');
            Buf[3] = Convert.ToByte('=');

            //Temp data
            UInt64 volumeTemp = inkData.VolumeRaw;
            UInt32 dongleIDTemp = inkData.DongleID;

            try
            {
                for (int i = 4; i < 12; i++)
                {
                    Buf[i] = (byte)volumeTemp;
                    volumeTemp >>= 8;
                }

                for (int i = 12; i < 16; i++)
                {
                    Buf[i] = (byte)dongleIDTemp;
                    dongleIDTemp >>= 8;
                }

                //Encrypt data
                Blowfish blowFish = new Blowfish(KeyArray);
                var result = blowFish.Encipher(Buf, Buf.Length);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csAprintOperation.EncodeVolumeData:\r\n" + ex.Message);
                return null;
            }
        }

        public static InkInfo DecodeInkData(byte[] bytes)
        {
            //Init variable
            InkInfo info = new InkInfo();

            try
            {
                Blowfish blowFish = new Blowfish(KeyArray);
                byte[] decodedData = blowFish.Decipher(bytes, bytes.Length);

                //Check result
                if ((decodedData[0] != 'i') ||
                   (decodedData[1] != 'n') ||
                   (decodedData[2] != 'k') ||
                   (decodedData[3] != '='))
                {//format not corrected
                    return null;
                }

                //Get volume
                info.VolumeRaw = 0;
                for (int i = 11; i >= 4; i--)
                {
                    //temp = Buf[i];
                    //InkRemained = (InkRemained + temp) * 256;
                    info.VolumeRaw <<= 8;
                    info.VolumeRaw |= (ulong)decodedData[i];
                }
                
                //Get dongle ID
                for (int i = 15; i >= 12; i--)
                {
                    //temp = BufResult[i];
                    //DongleId = (DongleId + temp) * 256;
                    info.DongleID <<= 8;
                    info.DongleID |= (UInt32)decodedData[i];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csAprintOperation.DecodeVolumeData:\r\n"+ex.Message);
                return null;
            }

            //Pass all steps
            return info;
        }

    }
}
