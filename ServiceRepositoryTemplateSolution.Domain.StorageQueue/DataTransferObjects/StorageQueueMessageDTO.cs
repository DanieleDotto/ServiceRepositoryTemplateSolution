using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.StorageQueue.DataTransferObjects {
    public class StorageQueueMessageDTO {
        public StorageQueueMessageDTO(string messageId, BinaryData body, DateTimeOffset? insertedOn, DateTimeOffset? expiresOn, long dequeueCount) {
            MessageId = messageId;
            Body = body;
            MessageText = body.ToString();
            InsertedOn = insertedOn;
            ExpiresOn = expiresOn;
            DequeueCount = dequeueCount;
        }

        public string MessageId { get; }
        public string MessageText {
            get => Body.ToString();
            internal set => Body = new BinaryData(value);
        }
        public BinaryData Body { get; internal set; }
        public DateTimeOffset? InsertedOn { get; }
        public DateTimeOffset? ExpiresOn { get; }
        public long DequeueCount { get; }
    }

}
