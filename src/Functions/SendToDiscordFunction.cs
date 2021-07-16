using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HGV.Shivas.Fun
{
    public class SendToDiscordFunction
    {
        private readonly HttpClient client;
        private readonly string discordWebhook;

        public SendToDiscordFunction(IHttpClientFactory factory)
        {
            this.discordWebhook = Environment.GetEnvironmentVariable("DiscordWebhook");
            this.client = factory.CreateClient();
        }

        [FunctionName(nameof(SendToDiscordFunctionRun))]
        public void SendToDiscordFunctionRun(
            [BlobTrigger("shivas/{id}.json", Connection = "AzureWebJobsStorage")]Stream stream, 
            ILogger log)
        {
            if(stream is null)
                return;

            using (var sr = new StreamReader(stream))
            using (var reader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var doc = serializer.Deserialize<RedditDocument>(reader);

                if(doc is null)
                    return;

                var msg = new { content = $"There is a new AD Post check it out! {doc.url}" };
                this.client.PostAsJsonAsync(discordWebhook, msg);
            }
        }
    }
}
