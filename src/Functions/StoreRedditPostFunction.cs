using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
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
            [Blob("shivas/{id}.json", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream stream,
            ILogger log
        )
        {
            try
            {
                if (doc is null)
                    return;

                var json = JsonConvert.SerializeObject(doc);
                var writer = new StreamWriter(stream);
                await writer.WriteAsync(json);

            }
            catch (Exception ex)
            {
                log.LogError(ex, "Blob Already Exists");
            }
        }
    }
}
