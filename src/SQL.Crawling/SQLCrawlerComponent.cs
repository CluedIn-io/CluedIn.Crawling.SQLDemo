using CluedIn.Core;
using CluedIn.Crawling.SQL.Core;

using ComponentHost;

namespace CluedIn.Crawling.SQL
{
    [Component(SQLConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class SQLCrawlerComponent : CrawlerComponentBase
    {
        public SQLCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

