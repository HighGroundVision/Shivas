using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

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
        public void SendToDiscordFunctionRun([CosmosDBTrigger(
            databaseName: "hgv-shivas",
            collectionName: "reddit-by-title",
            ConnectionStringSetting = "ShivasCosmosDB",
            LeaseCollectionName = "leases", CreateLeaseCollectionIfNotExists = true)]IReadOnlyList<Document> input, ILogger log)
        {
            if(input is null)
                return;

            if(input.Count == 0) 
                return;

            foreach (var item in input)
            {
                var url = item.GetPropertyValue<string>("url");
                var msg = new {
                    content = $"There is a new AD Post check it out! {url}",
                };
                this.client.PostAsJsonAsync(discordWebhook, msg);
            }
        }
    }
}
