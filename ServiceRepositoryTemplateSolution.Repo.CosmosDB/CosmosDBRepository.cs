using Microsoft.Azure.Cosmos;
using ServiceRepositoryTemplateSolution.Domain.CosmosDB;
using ServiceRepositoryTemplateSolution.Domain.CosmosDB.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.CosmosDB {
    public class CosmosDBRepository<T> : ICosmosDBRepository<T> {
        private Container _container;
        public CosmosDBRepository(CosmosDBRepositoryParameter parameter) {
            _container = new CosmosClient(parameter.ConnectionString).GetContainer(parameter.DatabaseId, parameter.ContainerId);
        }

        public async Task CreateItemAsync(T item) {
            await _container.CreateItemAsync(item, new PartitionKey(""));
        }

        public async Task<ItemResponseDTO<T>> ReadItemAsync(string recordId, string partitionKey) {
            ItemResponse<T> response = await _container.ReadItemAsync<T>(recordId, new PartitionKey(partitionKey));
            return new ItemResponseDTO<T>(response.StatusCode, response.Resource);
        }

        public async Task<List<T>> ExecuteQueryAsync<T>(string queryString, IDictionary<string, object> parameters) {
            QueryDefinition query = new QueryDefinition(queryString);

            foreach (var parameter in parameters) {
                query.WithParameter(parameter.Key, parameter.Value);
            }

            using FeedIterator<T> feed = _container.GetItemQueryIterator<T>(
                queryDefinition: query
                );

            List<T> items = new List<T>();
            while (feed.HasMoreResults) {
                FeedResponse<T> response = await feed.ReadNextAsync();
                foreach (T item in response) {
                    items.Add(item);
                }
            }

            return items;
        }


    }
}