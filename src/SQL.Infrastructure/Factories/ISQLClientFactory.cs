using CluedIn.Crawling.SQL.Core;

namespace CluedIn.Crawling.SQL.Infrastructure.Factories
{
    public interface ISQLClientFactory
    {
        SQLClient CreateNew(SQLCrawlJobData sqlCrawlJobData);
    }
}
