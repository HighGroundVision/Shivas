using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace HGV.Shivas.Fun
{
    public class ReddisFetchFunction
    {
        private readonly HttpClient client;

        public ReddisFetchFunction(IHttpClientFactory factory)
        {
            this.client = factory.CreateClient();
        }

        // https://www.reddit.com/r/dota2/search.json?q=selftext:ability+draft&sort=new&restrict_sr=on

        [FunctionName(nameof(ReddisFetchFunctionTimer))]
        public async Task ReddisFetchFunctionTimer(
            [TimerTrigger("0 0 * * * *")] TimerInfo myTimer, 
            [Queue("shivas", Connection = "AzureWebJobsStorage")]IAsyncCollector<RedditDocument> collector,
            ILogger log)
        {
            var root = await this.client.GetFromJsonAsync<RedditDocumentRoot>("https://www.reddit.com/r/dota2/search.json?q=title:ability+draft&sort=new&restrict_sr=on");
            var childern = root?.data?.children.ToList() ?? new List<Child>();
            foreach (var item in childern)
            {
                if(item.data is null)
                    continue;

                var doc = new RedditDocument()
                {
                    id = item.data.id,
                    title = item.data.title,
                    url = "https://www.reddit.com" + item.data.permalink,
                };
                await collector.AddAsync(doc);
            }
        }
    }
}

