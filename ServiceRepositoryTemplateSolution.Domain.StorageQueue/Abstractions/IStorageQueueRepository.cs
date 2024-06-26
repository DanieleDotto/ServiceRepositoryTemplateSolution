using ServiceRepositoryTemplateSolution.Domain.StorageQueue.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.StorageQueue.Abstractions {
    public interface IStorageQueueRepository {
        public void DeleteQueue();
        public Task DeleteQueueAsync();
        public void ClearQueue();
        public Task ClearQueueAsync();
        public void SendMessage(string message);
        public Task SendMessageAsync(string message);
        public StorageQueueMessageDTO PeekMessage();
        public Task<StorageQueueMessageDTO> PeekMessageAsync();
        public List<StorageQueueMessageDTO> PeekMessages(int? maxMessages);
        public Task<List<StorageQueueMessageDTO>> PeekMessagesAsync(int? maxMessages);
        public StorageQueueMessageDTO ReceiveMessage();
        public Task<StorageQueueMessageDTO> ReceiveMessageAsync();
        public List<StorageQueueMessageDTO> ReceiveMessages(int? maxMessages);
        public Task<List<StorageQueueMessageDTO>> ReceiveMessagesAsync(int? maxMessages);
    }
}
