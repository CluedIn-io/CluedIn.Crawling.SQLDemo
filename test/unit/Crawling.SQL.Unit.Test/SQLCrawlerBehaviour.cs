using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.SQL;
using CluedIn.Crawling.SQL.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.SQL.Unit.Test
{
    public class SQLCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public SQLCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<ISQLClientFactory>();

            _sut = new SQLCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
