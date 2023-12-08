using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class csHttpHelper
    {
        HttpClient client = new HttpClient();

        public async Task<string> Post(string sUrl, Dictionary<string, string> headerPairs)
        {
            var content = new FormUrlEncodedContent(headerPairs);
            var response = await client.PostAsync(sUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task<HttpResponseMessage> Send(HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage);
            return response;
        }

    }
}
