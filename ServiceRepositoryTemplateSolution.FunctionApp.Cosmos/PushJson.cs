using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions;

namespace ServiceRepositoryTemplateSolution.FunctionApp.StorageAccount
{
    public class PushJson
    {
        private readonly ILogger<PushJson> _logger;
        private IBlobContainerService _blobContainerService;
        public PushJson(ILogger<PushJson> logger, IBlobContainerService blobContainerService)
        {
            _logger = logger;
            _blobContainerService = blobContainerService;
        }

        [Function("PushJson")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            Dictionary<string, object> dict = new Dictionary<string, object> {
                {"Name", "John" },
                {"Age", 15 }
            };


            _blobContainerService.UploadJsonAsync("TestFile.json", dict);

            
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
