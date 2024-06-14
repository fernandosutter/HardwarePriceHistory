using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Infrastructure.Repository.PriceHistoryRepositories;
using HardwarePriceHistory.Infrastructure.Repository.ProductRepositories;
using HardwarePriceHistory.WorkerService;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IProductCommandRepository, ProductCommandRepository>();
        services.AddSingleton<IProductQueryRepository, ProductQueryRepository>();
        services.AddSingleton<IPriceHistoryCommandRepository, PriceHistoryCommandRepository>();
        services.AddSingleton<IPriceHistoryQueryRepository, PriceHistoryQueryRepository>();
    }).UseSerilog((hostContext, services, configuration) =>
    {
        configuration.WriteTo.Console()
                     .WriteTo.File("log.txt");
    })
.Build();

await host.RunAsync();