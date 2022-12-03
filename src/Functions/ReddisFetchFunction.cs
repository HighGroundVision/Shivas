using System;
using System.Collections.Generic;
using System.IO;
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
            [TimerTrigger("*/10 * * * *")] TimerInfo myTimer, 
            [Queue("shivas", Connection = "AzureWebJobsStorage")]IAsyncCollector<RedditDocument> collector,
            ILogger log)
        {
            var docs = new HashSet<RedditDocument>();
            var queries = new List<string>() {
                "https://www.reddit.com/r/abilitydraft/top.json?limit=100",
                "https://www.reddit.com/r/dota2/search.json?q=selftext:%22ability%20draft%22&sort=new&restrict_sr=on",
                "https://www.reddit.com/r/dota2/search.json?q=selftext:%22ability%20draft%22&sort=new&restrict_sr=on",
                "https://www.reddit.com/r/dota2/search.json?q=title:ability+draft&sort=new&restrict_sr=on",
            };

            foreach (var url in queries)
            {
                var root = await this.client.GetFromJsonAsync<RedditDocumentRoot>(url);
                var childern = root?.data?.children.ToList() ?? new List<Child>();
                foreach (var item in childern)
                {
                    if (item.data is null)
                        continue;

                    var doc = new RedditDocument()
                    {
                        id = item.data.id,
                        title = item.data.title,
                        url = "https://www.reddit.com" + item.data.permalink,
                    };
                    docs.Add(doc);
                }
            }

            foreach (var doc in docs)
            {
                await collector.AddAsync(doc);
            }
        }
    }
}

