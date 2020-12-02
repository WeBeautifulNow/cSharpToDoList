using ToDoList.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace ToDoList.Storage.Repositories.WorkItems
{
    public class WorkItemRepository: IWorkItemRepository
    {
        private Container _container;
        private static readonly string EndpointUri = "https://dotnet-learn-cosmos.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "fIpa7ZPKmyq5YMJGLc7M0KI0HP1haxJOdj5s0Xn0KbLjd2mLd3rbKZuXCeeOl4O0KxBbSviYJaMvY1YME0Kf0w==";

        // The name of the database and container we will create
        private string _workItemDatabaseId = "ToDoWorkItem";
        private string _workItemContainerId = "WorkItem";

        public WorkItemRepository()
        {
            CosmosClient dbClient = new CosmosClient(EndpointUri, PrimaryKey);
            this._container = dbClient.GetContainer(_workItemDatabaseId, _workItemContainerId);
        }

        public async Task<List<WorkItem>> GetAllItems()
        {
            var queryString = "SELECT * FROM d";
            var query = _container.GetItemQueryIterator<WorkItem>(new QueryDefinition(queryString));
            List<WorkItem> results = new List<WorkItem>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
