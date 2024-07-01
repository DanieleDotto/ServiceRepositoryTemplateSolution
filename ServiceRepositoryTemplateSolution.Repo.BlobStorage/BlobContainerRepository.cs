using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using ServiceRepositoryTemplateSolution.Domain.BlobStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.BlobStorage {
    public class BlobContainerRepository : IBlobContainerRepository {
        private readonly BlobContainerClient _blobContainerClient;
        public BlobContainerRepository(BlobContainerRepositoryParameter parameter) {
            _blobContainerClient = new BlobContainerClient(parameter.ConnectionString, parameter.ContainerName);
        }

        public void UploadBlob(string blobName, BinaryData data) {
            _blobContainerClient.UploadBlob(blobName, data);
        }

        public async Task UploadBlobAsync(string blobName, BinaryData data) {
            await _blobContainerClient.UploadBlobAsync(blobName, data);
        }

        public BinaryData DownloadBlob(string blobName) {
            return _blobContainerClient.GetBlobClient(blobName).DownloadContent().Value.Content;
        }

        public async Task<BinaryData> DownloadBlobAsync(string blobName) {
            BlobDownloadResult response = await _blobContainerClient.GetBlobClient(blobName).DownloadContentAsync();
            return response.Content;
        }


    }
}
