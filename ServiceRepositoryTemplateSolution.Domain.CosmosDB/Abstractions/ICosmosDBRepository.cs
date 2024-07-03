using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.CosmosDB.Abstractions {
    public interface ICosmosDBRepository<T> {
        public Task CreateItemAsync(T item);
        public Task<ItemResponseDTO<T>> ReadItemAsync(string recordId, string partitionKey);
    }
}
