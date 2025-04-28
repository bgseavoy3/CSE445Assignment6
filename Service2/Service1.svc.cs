using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string ChatResponses(string input)
        {
            //this is the "main method" that calles CallChat, which is separate due to needing to be asynchronous
            try
            {
                return CallChat(input).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message; 
            }
        }
        private async Task<string> CallChat(string input)
        {
            //create a new httpClient with the correct header value
            var apiKey = "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";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            //this is the format of what is sent to the API
            var body = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "system", content = "Respond in a comforting and relaxed manner without giving remedies."
                    },
                    new
                    {
                        role = "user", content = input
                    }
                }
            };
            //turn the format above into a JSON object that can be sent to ChatGPT API
            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //send the content from above to the API
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            //wait until response and store it in sResponse
            var sResponse = await response.Content.ReadAsStringAsync();
            //parse sResponse to get just the response from the API
            var document = JObject.Parse(sResponse);
            string result = document["choices"]?[0]?["message"]?["content"]?.ToString();
            //return the result with no additional whitespace in case there is any
            return result.Trim() ?? "(no response)";
        }
    }
}
