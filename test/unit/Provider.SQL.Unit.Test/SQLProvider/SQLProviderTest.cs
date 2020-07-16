using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.SQL.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.SQL.Unit.Test.SQLProvider
{
    public abstract class SQLProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<ISQLClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected SQLProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<ISQLClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new SQL.SQLProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
