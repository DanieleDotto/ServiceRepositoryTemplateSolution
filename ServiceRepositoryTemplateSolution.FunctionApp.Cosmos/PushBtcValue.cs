using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceRepositoryTemplateSolution.FunctionApp.BlobContainer {
    public class PushBtcValue {
        private readonly ILogger<PushBtcValue> _logger;
        private IBlobContainerService _blobContainerService;
        private HttpClient _httpClient;
        public PushBtcValue(ILogger<PushBtcValue> logger, IBlobContainerService blobContainerService) {
            _logger = logger;
            _blobContainerService = blobContainerService;
            _httpClient = new HttpClient();
        }

        [Function("PushBtcValue")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req) {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            HttpResponseMessage httpResponse = await _httpClient.GetAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
            string result = await httpResponse.Content.ReadAsStringAsync();
            JsonDocument json = JsonDocument.Parse(result);
            JsonElement root = json.RootElement;

            JsonElement chartName;
            if (root.TryGetProperty("chartName", out chartName)) {
                JsonElement bpi;
                if (root.TryGetProperty("bpi", out bpi)) {
                    JsonElement usd;
                    if (bpi.TryGetProperty("USD", out usd)) {
                        JsonElement usdRate;
                        if (usd.TryGetProperty("rate_float", out usdRate)) {
                            Dictionary<string, object> dict = new Dictionary<string, object> {
                            { "Coin", $"{chartName.GetString()}" },
                            { "Currency", "USD" },
                            { "Value", $"{usdRate.GetDouble()}" }
                        };
                            string fileName = $"{DateTime.UtcNow:O}.json";
                            await _blobContainerService.UploadJsonAsync(fileName, dict);
                        }
                    }
                }
            }

            return new OkObjectResult($"Push completed!");
        }

    }
}
