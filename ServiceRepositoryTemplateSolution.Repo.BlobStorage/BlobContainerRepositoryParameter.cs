using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.BlobStorage {
    public class BlobContainerRepositoryParameter {
        private readonly string _cnn;
        private readonly string _containerName;
        public BlobContainerRepositoryParameter(string cnn, string containerName) {
            if (string.IsNullOrWhiteSpace(cnn))
                throw new ArgumentException("Invalid connection string.");
            if (string.IsNullOrEmpty(containerName))
                throw new ArgumentException("Invalid container name.");
            _cnn = cnn;
            _containerName = containerName;
        }

        public string ConnectionString => _cnn;
        public string ContainerName => _containerName;
    }
}
