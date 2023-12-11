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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebClient
{
    public class csAPIHelper
    {
        public static HttpClient client = new HttpClient();
        public static csLoginInfo loginInfo { get; set; }
        public static string JobID { get; set; }

        /// <summary>
        /// Store the response message of current job
        /// </summary>
        public static csCheckJob_Response Job_Response { get; set; }



        public static async Task<bool> Login()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                //Avoid duplicated login
                if (loginInfo != null && loginInfo.IsValid) return true;

                //Check configuration
                if (string.IsNullOrWhiteSpace(csConfigureHelper.config.ClientID) ||
                    string.IsNullOrWhiteSpace(csConfigureHelper.config.ClientSecret))
                {
                    Debug.WriteLine("Empty user/pass.");
                    return false;
                }

                string sLoginUrl = "https://tpncy-web-services.auth.us-east-1.amazoncognito.com/oauth2/token";

                Dictionary<string, string> concent = new Dictionary<string, string>();
                concent.Add("grant_type", "client_credentials");
                concent.Add("client_id", csConfigureHelper.config.ClientID);
                concent.Add("client_secret", csConfigureHelper.config.ClientSecret);

                //Login
                var response = await client.PostAsync(sLoginUrl, new FormUrlEncodedContent(concent));
                var responseString = await response.Content.ReadAsStringAsync();


                loginInfo = null;
                //Show response time
                Debug.WriteLine($"Response received:{watch.ElapsedMilliseconds}ms");
                loginInfo = JsonConvert.DeserializeObject<csLoginInfo>(responseString);
                if (loginInfo == null) return false;
                loginInfo.UpdateExpiringTime();

                //Always show errors
                if (!string.IsNullOrWhiteSpace(loginInfo.error))
                {
                    Debug.WriteLine($"Error:{loginInfo.error}");
                }

                if (string.IsNullOrWhiteSpace(loginInfo.access_token)) return false;
                Debug.WriteLine($"Login Success({watch.ElapsedMilliseconds}ms):{loginInfo.access_token}");
                return true;
            }
            catch (Exception ex)
            {
                watch.Stop();
                Debug.WriteLine($"Login:{watch.ElapsedMilliseconds}ms\r\n" + ex.Message);
                return false;
            }
        }

        public static async Task<bool> RequestCode(string sGTIN,int iCount)
        {
            JobID = "";

            try
            {

                //Check login
                if (loginInfo==null)
                {
                    Debug.WriteLine("Login Check Fail.");
                    return false;
                }

                string sUrl = "https://sudd5dkvre.execute-api.us-east-1.amazonaws.com/v1/v1.2/serial/sgtin";
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, sUrl);

                //Setup header
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(loginInfo.token_type, loginInfo.access_token);

                //Setup content
                csRequestCode_RequestContent requestContent = new csRequestCode_RequestContent(sGTIN, iCount);
                string sContent=JsonConvert.SerializeObject(requestContent);
                //string sContent = @"{\"gtin\": \"00726587397509\",\"count\": 100000 \}";
                requestMessage.Content = new StringContent(sContent, Encoding.UTF8, "application/json");

                //Request
                var response = await client.SendAsync(requestMessage);
                string sMessage = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    //URL of the result
                    //Response location:"https://api.transparency.com/serial/job/CG7630487977880917835"
                    string sLocationUrl = response.Headers.Location.AbsoluteUri;
                    if (response.Headers.Location.Segments.Length == 4)
                    {
                        JobID = response.Headers.Location.Segments[3];
                    }

                    //Check job ID
                    if (string.IsNullOrWhiteSpace(JobID))
                    {
                        Debug.WriteLine("Empty Job ID");
                        return false;
                    }
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

        public static async Task<bool> CheckCodeReady()
        {
            //Check job ID
            if (string.IsNullOrWhiteSpace(JobID))
            {
                Debug.WriteLine("Empty Job ID");
                return false;
            }

            //JobID = "CG7630487977880917835";

            try
            {
                string sUrl = "https://sudd5dkvre.execute-api.us-east-1.amazonaws.com/v1/v1.2/serial/job/";
                sUrl += JobID;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, sUrl);

                //Setup header
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(loginInfo.token_type, loginInfo.access_token);
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Request
                var response = await client.SendAsync(requestMessage);
                string sMessage = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Server response not OK...");
                    return false;
                }


                //Check response message
                if (string.IsNullOrWhiteSpace(sMessage))
                {
                    Debug.WriteLine("Empty result.");
                    return false;
                }

                //Get response message
                Job_Response = null;
                Job_Response = JsonConvert.DeserializeObject<csCheckJob_Response>(sMessage);

                if (Job_Response.status.ToUpper() == "COMPLETED")
                {
                    Debug.WriteLine($"Sucess:\r\n {Job_Response.url}");
                    await GetCode();
                    return true;
                }
                else if (Job_Response.status.ToUpper() == "IN_PROGRESS" || Job_Response.status.ToUpper() == "PROCESSING")
                {
                    Debug.WriteLine($"Processing...");
                    return false;
                }
                else
                {
                    Debug.WriteLine($"Undefined...");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("CheckCodeReady:\r\n" + ex.Message);
                return false;
            }

        }

        public static async Task GetCode()
        {
            string sUrl = Job_Response.url;

            try
            {

                var response = await client.GetAsync(sUrl);
                var responseString = await response.Content.ReadAsStringAsync();
                var finalData = JsonConvert.DeserializeObject<csFinalData>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetCode:\r\n" + ex.Message);
            }

        }
    }

    public class csLoginInfo
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string error { get; set; }


        [XmlIgnore]
        public DateTime ExpiringTime { get; set; }
        /// <summary>
        /// Make sure at least 5 mins left for operation
        /// </summary>
        [XmlIgnore]
        public bool IsValid => (ExpiringTime - DateTime.Now).TotalMinutes > 5;

        public void UpdateExpiringTime()
        {
            ExpiringTime = DateTime.Now.AddSeconds(expires_in);
        }
    }

    public class csRequestCode_RequestContent
    {
        public string gtin { get; set; }
        public int count { get; set; }

        public csRequestCode_RequestContent(string _gtin, int _count)
        {
            gtin = _gtin;
            count = _count;
        }
    }

    public class csRequestCode_Response
    {
        public string Message { get; set; }
    }

    public class csCheckJob_Response
    {
        /// <summary>
        /// The download link
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// IN_PROGRESS: Processing
        /// COMPLETED: Ready to pick
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string error { get; set; }

        public csCheckJob_Response()
        {
            url = "";
            status = "";
            error = "";
        }
    }

    public class csFinalData
    {
        public string codeRequestId { get; set; }
        public string requestDate { get; set; }
        public List<csCodeInfo> codesList { get; set; }
    }

    public class csCodeInfo
    {
        public int numberOfCodes { get; set; }
        public string typeOfCodes { get; set; }
        public string brandIdentifier { get; set; }
        public string gtin { get; set; }
        public string sku { get; set; }
        public List<string> Codes { get; set; }
    }


}
