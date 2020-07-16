using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.SQL.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CluedIn.Crawling.SQL.Core.Models;

namespace CluedIn.Crawling.SQL.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class SQLClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger<SQLClient> log;

        private readonly IRestClient client;

        public SQLClient(ILogger<SQLClient> log, SQLCrawlJobData sqlCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (sqlCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(sqlCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from sqlCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", sqlCrawlJobData.ConnectionString, ParameterType.QueryString);
        }

        [Obsolete]
        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.LogError(diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", ""); 
        }

        public IEnumerable<object> Get(string connectionString, string tableName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    var command = new SqlCommand($"SELECT * FROM {tableName}", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception exception)
                {
                    log.LogError(exception.Message, exception);
                }
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        if (tableName == "people")
                            yield return new Person(reader);
                    }
                }
            }
        }
    }
}
