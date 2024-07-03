using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceRepositoryTemplateSolution.Domain.BlobContainer.Abstractions;
using ServiceRepositoryTemplateSolution.Domain.BlobStorage.Abstractions;
using ServiceRepositoryTemplateSolution.Repo.BlobStorage;
using ServiceRepositoryTemplateSolution.Svc.BlobContainer;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton(new BlobContainerRepositoryParameter(Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_CNN"),
                                                                   Environment.GetEnvironmentVariable("CONTAINER_NAME")));
        services.AddSingleton<IBlobContainerRepository, BlobContainerRepository>();
        services.AddSingleton<IBlobContainerService, BlobContainerService>();
    })
    .Build();

host.Run();
