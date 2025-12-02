using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CommonCode_Framework;

namespace FontTest
{
    public class csFontHelper
    {
        public static string DemoText = "1234567890\r\n" +
                                        "abcdefghijklmnopqrstuvwxyz\r\n" +
                                        "ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n" +
                                        "中文测试：北京上海广州深圳武汉成都\r\n" +
                                        "日本語テスト：東京大阪京都名古屋\r\nمرحبا بالعالم من الرياض ودبي" +
                                        "\r\nрусский язык: Москва, Санкт-Петербург\r\n" +
                                        "한국어 테스트: 서울 부산 인천 대구\r\n" +
                                        "Français : test avec des accents éèàùç\r\n" +
                                        "Español: ¡Hola! ¿Cómo estás? México, España";

        public static Font CurrentFont;
        public static float fFontSize = 12;


        public static Font LoadFont(string sFilePath, out string sMessage)
        {
            sMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(sFilePath))
                {
                    sMessage = "The input path is empty.";
                    return null;
                }

                if (!(File.Exists(sFilePath)))
                {
                    sMessage = "The specific file can't be found.";
                    return null;
                }

                //Create font
                var fontCollection = new PrivateFontCollection();
                fontCollection.AddFontFile(sFilePath);

                CurrentFont = new Font(fontCollection.Families[0],fFontSize);

                return CurrentFont;
            }
            catch (Exception e)
            {
               e.TraceException("FontHelper.LoadFont");
               sMessage = e.Message;
               return null;
            }
        }
    }
}
