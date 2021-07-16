using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace HGV.Shivas.Fun
{
    public class StoreRedditPostFunction
    {
        [FunctionName(nameof(StoreRedditPostFunctionAdd))]
        public async Task StoreRedditPostFunctionAdd(
            [QueueTrigger("shivas", Connection = "AzureWebJobsStorage")]RedditDocument doc,
            [Blob("shivas/{id}.json", FileAccess.ReadWrite, Connection = "AzureWebJobsStorage")] CloudBlockBlob blob,
            ILogger log
        )
        {
            if(doc is null)
                return;

            var result = await blob.ExistsAsync();
            if(result == true)
                return;
            
            var json = JsonConvert.SerializeObject(doc);
            await blob.UploadTextAsync(json);
        }
    }
}
