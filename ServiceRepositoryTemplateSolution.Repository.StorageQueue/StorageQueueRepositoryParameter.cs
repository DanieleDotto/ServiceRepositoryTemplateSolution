using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.StorageQueue {
    public class StorageQueueRepositoryParameter {
        private readonly QueueClient _queueClient;
        public StorageQueueRepositoryParameter(string cnn, string queueName) {
            if (string.IsNullOrWhiteSpace(queueName))
                throw new ArgumentException("Invalid queue name.");
            if (string.IsNullOrWhiteSpace(cnn))
                throw new ArgumentException("Invalid connection string.");
            _queueClient = new QueueClient(cnn, queueName);
        }

        public QueueClient QueueClient => _queueClient;
    }
}
