using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Listener.Sentiment
{
    public sealed class TextAnalyticsService
    {
        readonly string accountKey;
        string BaseUrl => "https://westus.api.cognitive.microsoft.com";

        public TextAnalyticsService()
        {
            using (var stream = new StreamReader("azure.txt", Encoding.UTF8))
            {
                this.accountKey = stream.ReadToEnd().Trim();
            }
        }

        public SentimentResponse Analyse(SentimentRequest request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.BaseUrl);

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.accountKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var payloadString = request.Serialize();

                var payloadBytes = Encoding.UTF8.GetBytes(payloadString);

                var sentimentEndpoint = "/text/analytics/v2.0/sentiment";
                var responseString = string.Empty;
                using (var content = new ByteArrayContent(payloadBytes))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = client.PostAsync(sentimentEndpoint, content).Result;
                    responseString = response.Content.ReadAsStringAsync().Result;
                }

                var deserialized = JsonConvert.DeserializeObject<SentimentResponse>(responseString);

                return deserialized;
            }
        }
    }

    [Serializable]
    public class SentimentRequest
    {
        [JsonProperty("documents")]
        public IEnumerable<DocumentText> Documents { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    public class DocumentText
    {
        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("text")]
        public string Text { get; }

        public DocumentText(string id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }

    [Serializable]
    public class SentimentResponse
    {
        [JsonProperty("documents")]
        public IEnumerable<DocumentScore> Documents { get; set; }
    }

    [Serializable]
    public class DocumentScore
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public decimal Score { get; set; }
    }
}