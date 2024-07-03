using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.BlobStorage.Abstractions {
    public interface IBlobContainerRepository {
        public void UploadBlob(string blobName, BinaryData data);
        public Task UploadBlobAsync(string blobName, BinaryData data);
        public BinaryData? DownloadBlob(string blobName);
        public Task<BinaryData?> DownloadBlobAsync(string blobName);
    }
}
