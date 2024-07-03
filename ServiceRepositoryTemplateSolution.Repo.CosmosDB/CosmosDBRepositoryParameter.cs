using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRepositoryTemplateSolution.Repo.CosmosDB {
    public class CosmosDBRepositoryParameter {
        private string _cnn, _databaseId, _containerId;
        public CosmosDBRepositoryParameter(string cnn, string databaseId, string containerId) {
            _cnn = cnn;
            _databaseId = databaseId;
            _containerId = containerId;
        }
        public string ConnectionString => _cnn;
        public string DatabaseId => _databaseId;
        public string ContainerId => _containerId;
    }
}
