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
            try {
                _blobContainerClient.UploadBlob(blobName, data);
            } catch (RequestFailedException e) {
                Console.WriteLine($"Si è verificato un errore durante l'upload del blob: {blobName}");
                Console.WriteLine($"Dettagli dell'errore: {e.Message}");
                Console.WriteLine(e.StackTrace);
            }
        }

        public async Task UploadBlobAsync(string blobName, BinaryData data) {
            try {
                await _blobContainerClient.UploadBlobAsync(blobName, data);
            } catch (RequestFailedException e) {
                await Console.Out.WriteLineAsync($"Si è verificato un errore durante l'upload del blob: {blobName}");
                await Console.Out.WriteLineAsync($"Dettagli dell'errore: {e.Message}");
                await Console.Out.WriteLineAsync(e.StackTrace);
            }
        }

        public BinaryData? DownloadBlob(string blobName) {
            try {
                return _blobContainerClient.GetBlobClient(blobName).DownloadContent().Value.Content;
            } catch (RequestFailedException e) {
                Console.WriteLine($"Si è verificato un errore durante il download del blob: {blobName}");
                Console.WriteLine($"Dettagli dell'errore: {e.Message}");
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }


        public async Task<BinaryData?> DownloadBlobAsync(string blobName) {
            try {
                BlobDownloadResult response = await _blobContainerClient.GetBlobClient(blobName).DownloadContentAsync();
                return response.Content;
            } catch (RequestFailedException e) {
                Console.WriteLine($"Si è verificato un errore durante il download del blob: {blobName}");
                Console.WriteLine($"Dettagli dell'errore: {e.Message}");
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }


    }
}
