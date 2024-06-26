using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.StorageQueue {
    public class StorageQueueRepositoryParameter {
        private readonly QueueClient _queueClient;
        public StorageQueueRepositoryParameter(QueueServiceClient queueServiceClient, string queueName) {
            if (string.IsNullOrWhiteSpace(queueName))
                throw new ArgumentException("Queue name invalid.");
            _queueClient = queueServiceClient.GetQueueClient(queueName);
        }

        public QueueClient QueueClient => _queueClient;
    }
}
