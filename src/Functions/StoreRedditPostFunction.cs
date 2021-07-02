using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace HGV.Shivas.Fun
{
    public class StoreRedditPostFunction
    {
        [FunctionName(nameof(StoreRedditPostFunctionAdd))]
        public async Task StoreRedditPostFunctionAdd(
            [QueueTrigger("shivas", Connection = "AzureWebJobsStorage")]RedditDocument newitem, 
            [CosmosDB(
                databaseName: "hgv-shivas",
                collectionName: "reddit-by-title",
                ConnectionStringSetting = "ShivasCosmosDB",
                Id = "{id}",
                PartitionKey = "{id}")]Document existingItem,
            [CosmosDB(
                databaseName: "hgv-shivas",
                collectionName: "reddit-by-title",
                ConnectionStringSetting = "ShivasCosmosDB")]IAsyncCollector<RedditDocument> collector,
            ILogger log
        )
        {
            if(existingItem is null)
            {
                await collector.AddAsync(newitem);
            }
        }
    }
}
