using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AI_Grok2.Classes
{
    public class Grok2ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public Grok2ApiClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<(bool IsSuccess,string Message)> GetGrokResponseAsync(string prompt)
        {
            try
            {
                var apiUrl = "API_ENDPOINT_HERE"; // 替换为实际的Grok 2 API端点

                var requestBody = new
                {
                    prompt = prompt
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseContent);
                    return data.response; // 假设API返回的JSON格式中有名为"response"的字段
                }
                else
                {
                    string sError= $"API call failed with status code {response.StatusCode}";
                    return (false, sError);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Grok2ApiClient.Exception:{ex.Message}");
            }
           
        }
    }
}
