using ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions;
using ServiceRepositoryTemplateSolution.Domain.BlobStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Svc.BlobContainer {
    public class BlobContainerService : IBlobContainerService {
        private IBlobContainerRepository _repository;
        public BlobContainerService(IBlobContainerRepository blobContainerRepository) {
            _repository = blobContainerRepository;
        }

        public async Task UploadJsonAsync(string fileName, IDictionary<string, object> data) {
            string jsonString = JsonSerializer.Serialize(data);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
            BinaryData binaryData = BinaryData.FromBytes(bytes);
            await _repository.UploadBlobAsync(fileName, binaryData);
        }
    }
}
