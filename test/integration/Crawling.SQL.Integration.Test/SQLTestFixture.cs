using System.IO;
using System.Reflection;
using CluedIn.Crawling.SQL.Core;
using CrawlerIntegrationTesting.Clues;
using CrawlerIntegrationTesting.Log;
using Xunit.Abstractions;
using DebugCrawlerHost = CrawlerIntegrationTesting.CrawlerHost.DebugCrawlerHost<CluedIn.Crawling.SQL.Core.SQLCrawlJobData>;

namespace CluedIn.Crawling.SQL.Integration.Test
{
    public class SQLTestFixture
    {
        public ClueStorage ClueStorage { get; }
        private readonly DebugCrawlerHost debugCrawlerHost;

        public TestLogger Log { get; }
        public SQLTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            debugCrawlerHost = new DebugCrawlerHost(executingFolder, SQLConstants.ProviderName);

            ClueStorage = new ClueStorage();

            Log = debugCrawlerHost.AppContext.Container.Resolve<TestLogger>();

            debugCrawlerHost.ProcessClue += ClueStorage.AddClue;

            debugCrawlerHost.Execute(SQLConfiguration.Create(), SQLConstants.ProviderId);
        }

        public void PrintClues(ITestOutputHelper output)
        {
            foreach(var clue in ClueStorage.Clues)
            {
                output.WriteLine(clue.OriginEntityCode.ToString());
            }
        }

        public void PrintLogs(ITestOutputHelper output)
        {
            output.WriteLine(Log.PrintLogs());
        }

        public void Dispose()
        {
        }

    }
}


