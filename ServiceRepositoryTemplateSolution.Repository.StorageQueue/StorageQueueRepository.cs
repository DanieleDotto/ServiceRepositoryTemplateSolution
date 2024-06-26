using Azure.Storage.Queues;
using ServiceRepositoryTemplateSolution.Domain.StorageQueue.Abstractions;
using ServiceRepositoryTemplateSolution.Domain.StorageQueue.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.StorageQueue {
    public class StorageQueueRepository : IStorageQueueRepository {
        private readonly QueueClient _queueClient;
        public StorageQueueRepository(StorageQueueRepositoryParameter parameter) {
            _queueClient = parameter.QueueClient;
        }

        public void ClearQueue() {
            _queueClient.ClearMessages();
        }

        public async Task ClearQueueAsync() {
            await _queueClient.ClearMessagesAsync();
        }

        public void DeleteQueue() {
            throw new NotImplementedException();
        }

        public Task DeleteQueueAsync() {
            throw new NotImplementedException();
        }

        public StorageQueueMessageDTO PeekMessage() {
            throw new NotImplementedException();
        }

        public Task<StorageQueueMessageDTO> PeekMessageAsync() {
            throw new NotImplementedException();
        }

        public List<StorageQueueMessageDTO> PeekMessages(int? maxMessages) {
            throw new NotImplementedException();
        }

        public Task<List<StorageQueueMessageDTO>> PeekMessagesAsync(int? maxMessages) {
            throw new NotImplementedException();
        }

        public StorageQueueMessageDTO ReceiveMessage() {
            throw new NotImplementedException();
        }

        public Task<StorageQueueMessageDTO> ReceiveMessageAsync() {
            throw new NotImplementedException();
        }

        public List<StorageQueueMessageDTO> ReceiveMessages(int? maxMessages) {
            throw new NotImplementedException();
        }

        public Task<List<StorageQueueMessageDTO>> ReceiveMessagesAsync(int? maxMessages) {
            throw new NotImplementedException();
        }

        public void SendMessage(string message) {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync(string message) {
            throw new NotImplementedException();
        }
    }
}
