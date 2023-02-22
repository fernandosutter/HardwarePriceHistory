using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Data.Repository.PriceHistory;
using HardwarePriceHistory.Data.Repository.Product;
using HardwarePriceHistory.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IProductCommandRepository, ProductCommandRepository>();
        services.AddSingleton<IProductQueryRepository, ProductQueryRepository>();
        services.AddSingleton<IPriceHistoryCommandRepository, PriceHistoryCommandRepository>();
    })
    .Build();

await host.RunAsync();