using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Domain.CosmosDB {
    public class ItemResponseDTO<T> {
        private HttpStatusCode _httpStatusCode;
        private T _item;
        public ItemResponseDTO(HttpStatusCode httpStatusCode, T item) {
            _httpStatusCode = httpStatusCode;
            _item = item;
        }
        public HttpStatusCode HttpStatusCode => _httpStatusCode;
        public T Item => _item;
    }
}
