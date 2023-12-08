using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class csAPIHelper
    {
        public static csLoginInfo loginInfo { get; set; }

        public static csHttpHelper httpHelper = new csHttpHelper();

        public static async Task<bool> Login()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                string sLoginUrl = "https://tpncy-web-services.auth.us-east-1.amazoncognito.com/oauth2/token";

                Dictionary<string, string> concent = new Dictionary<string, string>();
                concent.Add("grant_type", "client_credentials");
                concent.Add("client_id", "4oqkpchlr7oi7g2vkdaphoe2ck");
                concent.Add("client_secret", "1nilgr9kfb1ggo6136dgcftild8ltse9hktv76atc3vnd5tg164g");

                string sResult = await httpHelper.Post(sLoginUrl, concent);
                loginInfo = null;
                //Show response time
                Debug.WriteLine($"Response received:{watch.ElapsedMilliseconds}ms");
                loginInfo = JsonConvert.DeserializeObject<csLoginInfo>(sResult);
                if (loginInfo == null) return false;

                //Always show errors
                if (!string.IsNullOrWhiteSpace(loginInfo.error))
                {
                    Debug.WriteLine($"Error:{loginInfo.error}");
                }

                if (string.IsNullOrWhiteSpace(loginInfo.access_token)) return false;
                Debug.WriteLine($"Login Success({watch.ElapsedMilliseconds}):{loginInfo.access_token}");
                return true;
            }
            catch (Exception ex)
            {
                watch.Stop();
                Debug.WriteLine($"Login:{watch.ElapsedMilliseconds}ms\r\n" + ex.Message);
                return false;
            }
        }

        public static async Task<bool> RequestCode()
        {
            try
            {
                string sUrl = "https://sudd5dkvre.execute-api.us-east-1.amazonaws.com/v1/v1.2/serial/sgtin";
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, sUrl);

                //Setup header
                requestMessage.Headers.Authorization= new AuthenticationHeaderValue(loginInfo.token_type, loginInfo.access_token);
                

                //Setup content
                //csRequestCode_RequestContent requestContent=new csRequestCode_RequestContent("00726587397523", "100");
                //string sJson = JsonConvert.SerializeObject(requestContent);
                //requestMessage.Content = new StringContent(sJson, Encoding.UTF8, "application/json");

                //Setup coneent 2
                Dictionary<string, string> content = new Dictionary<string, string>();
                content.Add("gtin", "00726587397509");
                content.Add("count", "10");
                requestMessage.Content = new FormUrlEncodedContent(content);


                //Request
                var response = await httpHelper.Send(requestMessage);
                string sMessage = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var Result = JsonConvert.DeserializeObject<csRequestCode_Response>(sMessage);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login:\r\n" + ex.Message);
                return false;
            }
        }
    }

    public class csLoginInfo
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string error { get; set; }
    }

    public class csRequestCode_RequestContent
    {
        public string gtin { get; set; }
        public string count { get; set; }

        public csRequestCode_RequestContent(string _gtin, string _count)
        {
            gtin= _gtin;
            count = _count;
        }
    }

    public class csRequestCode_Response
    {
        public string Message { get; set; }
    }
}
