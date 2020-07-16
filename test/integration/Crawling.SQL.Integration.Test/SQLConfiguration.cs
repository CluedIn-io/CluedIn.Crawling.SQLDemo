using System.Collections.Generic;
using CluedIn.Crawling.SQL.Core;

namespace CluedIn.Crawling.SQL.Integration.Test
{
  public static class SQLConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { SQLConstants.KeyName.ConnectionString, "demo" }
            };
    }
  }
}
