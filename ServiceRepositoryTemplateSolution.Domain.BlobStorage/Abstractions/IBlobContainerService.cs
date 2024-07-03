using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions {
    public interface IBlobContainerService {
        public Task UploadJsonAsync(string fileName, IDictionary<string, object> data);
    }
}
