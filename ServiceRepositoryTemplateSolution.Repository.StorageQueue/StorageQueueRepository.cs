using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
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
        private const int _minPeekingMessages = 1;
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
            _queueClient.Delete();
        }

        public async Task DeleteQueueAsync() {
            await _queueClient.DeleteAsync();
        }

        public StorageQueueMessageDTO PeekMessage() {
            return PeekMessages(1).First();
        }

        public async Task<StorageQueueMessageDTO> PeekMessageAsync() {
            List<StorageQueueMessageDTO> peekedMessages = await PeekMessagesAsync(1);
            return peekedMessages.First();
        }

        public List<StorageQueueMessageDTO> PeekMessages(int? maxMessages) {
            int maxPeekableMessages = _queueClient.MaxPeekableMessages;
            if (maxMessages < _minPeekingMessages || maxMessages > maxPeekableMessages)
                throw new ArgumentException($"maxMessages value is {maxMessages} but it must be between {_minPeekingMessages} and {maxPeekableMessages}.");
            PeekedMessage[] peekedMessages = _queueClient.PeekMessages(maxMessages);
            return peekedMessages.Select(msg => new StorageQueueMessageDTO(msg.MessageId, msg.Body, msg.InsertedOn, msg.ExpiresOn, msg.DequeueCount)).ToList();
        }

        public async Task<List<StorageQueueMessageDTO>> PeekMessagesAsync(int? maxMessages) {
            int maxPeekableMessages = _queueClient.MaxPeekableMessages;
            if (maxMessages < _minPeekingMessages || maxMessages > maxPeekableMessages)
                throw new ArgumentException($"maxMessages value is {maxMessages} but it must be between {_minPeekingMessages} and {maxPeekableMessages}.");
            PeekedMessage[] peekedMessages = await _queueClient.PeekMessagesAsync(maxMessages);
            return peekedMessages.Select(msg => new StorageQueueMessageDTO(msg.MessageId, msg.Body, msg.InsertedOn, msg.ExpiresOn, msg.DequeueCount)).ToList();
        }

        public StorageQueueMessageDTO ReceiveMessage() {
            return ReceiveMessages(1).First();
        }

        public async Task<StorageQueueMessageDTO> ReceiveMessageAsync() {
            List<StorageQueueMessageDTO> receivedMessages = await ReceiveMessagesAsync(1);
            return receivedMessages.First();
        }

        public List<StorageQueueMessageDTO> ReceiveMessages(int? maxMessages) {
            int maxPeekableMessages = _queueClient.MaxPeekableMessages;
            if (maxMessages < _minPeekingMessages || maxMessages > maxPeekableMessages)
                throw new ArgumentException($"maxMessages value is {maxMessages} but it must be between {_minPeekingMessages} and {maxPeekableMessages}.");
            QueueMessage[] receivedMessages = _queueClient.ReceiveMessages(maxMessages);
            return receivedMessages.Select(msg => new StorageQueueMessageDTO(msg.MessageId, msg.Body, msg.InsertedOn, msg.ExpiresOn, msg.DequeueCount)).ToList();
        }

        public async Task<List<StorageQueueMessageDTO>> ReceiveMessagesAsync(int? maxMessages) {
            int maxPeekableMessages = _queueClient.MaxPeekableMessages;
            if (maxMessages < _minPeekingMessages || maxMessages > maxPeekableMessages)
                throw new ArgumentException($"maxMessages value is {maxMessages} but it must be between {_minPeekingMessages} and {maxPeekableMessages}.");
            QueueMessage[] receivedMessages = await _queueClient.ReceiveMessagesAsync(maxMessages);
            return receivedMessages.Select(msg => new StorageQueueMessageDTO(msg.MessageId, msg.Body, msg.InsertedOn, msg.ExpiresOn, msg.DequeueCount)).ToList();
        }

        public void SendMessage(string message) {
            _queueClient.SendMessage(message);
        }

        public async Task SendMessageAsync(string message) {
            await _queueClient.SendMessageAsync(message);
        }
    }
}
