using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HGV.Shivas.Fun
{
    public class StoreRedditPostFunction
    {
        [FunctionName(nameof(StoreRedditPostFunctionAdd))]
        public async Task StoreRedditPostFunctionAdd(
            [QueueTrigger("shivas", Connection = "AzureWebJobsStorage")]RedditDocument doc,
            [Blob("shivas/{id}.json", FileAccess.ReadWrite, Connection = "AzureWebJobsStorage")] BlobClient client,
            ILogger log
        )
        {
            if (doc is null) throw new ArgumentNullException(nameof(RedditDocument));
            if (client is null) throw new ArgumentNullException(nameof(CloudBlockBlob));

            var exists = await client.ExistsAsync();
            if (exists)
            {
                log.LogWarning("Reddit Document Already Exists");
                return;
            }

            var json = JsonConvert.SerializeObject(doc);
            var data = new BinaryData(json);
            await client.UploadAsync(data);
        }
    }
}
