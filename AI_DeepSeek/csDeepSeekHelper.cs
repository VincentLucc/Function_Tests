using _CommonCode_Framework;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AI_DeepSeek
{
    public class csDeepSeekHelper
    {
        public static ChatClient deepSeekClient;

        public static void Init()
        {
            //Create connection
            var credentail = new ApiKeyCredential("<abc123>");
            var clientOptions = new OpenAIClientOptions()
            {
                Endpoint = new Uri("https://api.deepseek.com/v1"),
            };

            deepSeekClient = new ChatClient("MODEL_NAME", credentail, clientOptions);
        }

        public static async Task<(ChatCompletion chatCompletion, string sError)> Request(string sContent,int iTimeout)
        {
            var chatMessage1 = ChatMessage.CreateUserMessage(sContent);
            var cancellationSource = new CancellationTokenSource();

            try
            {
                cancellationSource.CancelAfter(iTimeout);
                ChatCompletion completion = await deepSeekClient.CompleteChatAsync(new ChatMessage[] { chatMessage1 }, null, cancellationSource.Token);
                return (completion, null);
            }
            catch (Exception ex)
            {//Allow other exception
                ex.TraceException("DeepSeekHelper.Request");
                return (null, ex.Message);
            }
        }
    }
}
