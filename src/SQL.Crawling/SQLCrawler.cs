using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Core.Health;
using CluedIn.Crawling.SQL.Core;
using CluedIn.Crawling.SQL.Infrastructure.Factories;

namespace CluedIn.Crawling.SQL
{
    public class SQLCrawler : ICrawlerDataGenerator
    {
        private readonly ISQLClientFactory clientFactory;
        public SQLCrawler(ISQLClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is SQLCrawlJobData sqlcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(sqlcrawlJobData);

            //retrieve data from provider and yield objects
            foreach (var item in client.Get(sqlcrawlJobData.ConnectionString, sqlcrawlJobData.TableName))
            {
                yield return item;
            }
        }       
    }
}
