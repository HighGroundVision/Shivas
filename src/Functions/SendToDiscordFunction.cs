using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
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
        public async Task SendToDiscordFunctionRun(
            [BlobTrigger("shivas/{id}.json", Connection = "AzureWebJobsStorage")] BlobClient client, 
            ILogger log)
        {
            if (client is null) throw new ArgumentNullException(nameof(BlobClient));

            var reponse = await client.DownloadContentAsync();
            var json = reponse?.Value?.Content?.ToString() ?? throw new InvalidOperationException("DownloadContentAsync");
            var doc = JsonConvert.DeserializeObject<RedditDocument>(json) ?? throw new InvalidOperationException("DeserializeObject");
            
            var msg = new { content = $"There is a new AD Post check it out! {doc.url}" };
            await this.client.PostAsJsonAsync(discordWebhook, msg);
        }
    }
}
