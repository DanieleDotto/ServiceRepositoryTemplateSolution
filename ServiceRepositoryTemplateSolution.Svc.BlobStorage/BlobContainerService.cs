using ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions;
using ServiceRepositoryTemplateSolution.Domain.BlobStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public async Task<JsonDocument?> DownloadJsonAsync(string blobName) {
            BinaryData? binary = await _repository.DownloadBlobAsync(blobName);
            JsonDocument? res = null;
            if (binary != null) {
                string jsonString = JsonSerializer.Serialize(binary);
                JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
                return jsonDocument;
            }
            return res;
        }
    }
}
