using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.SQL.Core
{
    public class SQLCrawlJobData : CrawlJobData
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
    }
}
