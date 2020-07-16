using CluedIn.Crawling.SQL.Core;

namespace CluedIn.Crawling.SQL
{
    public class SQLCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<SQLCrawlJobData>
    {
        public SQLCrawlerJobProcessor(SQLCrawlerComponent component) : base(component)
        {
        }
    }
}
