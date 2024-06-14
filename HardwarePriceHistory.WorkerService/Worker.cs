using System.Globalization;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.Addresses;
using HardwarePriceHistory.Core.Models;
using HardwarePriceHistory.Infrastructure.Requests;

namespace HardwarePriceHistory.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IProductCommandRepository _productCommandRepository;
    private readonly IProductQueryRepository _productQueryRepository;
    private readonly IPriceHistoryCommandRepository _priceHistoryCommandRepository;
    private readonly IPriceHistoryQueryRepository _priceHistoryQueryRepository;

    public Worker(ILogger<Worker> logger,
        IProductCommandRepository productCommandRepository,
        IProductQueryRepository productQueryRepository,
        IPriceHistoryCommandRepository priceHistoryCommandRepository,
        IPriceHistoryQueryRepository priceHistoryQueryRepository
        )
    {
        _logger = logger;
        _productCommandRepository = productCommandRepository;
        _productQueryRepository = productQueryRepository;
        _priceHistoryCommandRepository = priceHistoryCommandRepository;
        _priceHistoryQueryRepository = priceHistoryQueryRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var startTime = DateTimeOffset.Now;

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            _logger.LogInformation("Iniciando as GPUS");
            await ProcessProductsPricesAsync(PichauAddresses.PichauUrlGpu, 1);
            _logger.LogInformation("Iniciando as Mobos");
            await ProcessProductsPricesAsync(PichauAddresses.PichauUrlMobo,2);
            _logger.LogInformation("Iniciando as Rams");
            await ProcessProductsPricesAsync(PichauAddresses.PichauUrlRam, 3);
            _logger.LogInformation("Iniciando as CPUs AMD");
            await ProcessProductsPricesAsync(PichauAddresses.PichauUrlProcessorAmd, 4);
            _logger.LogInformation("Iniciando as CPUs Intel");
            await ProcessProductsPricesAsync(PichauAddresses.PichauUrlProcessorIntel, 5);

            _logger.LogInformation("Worker Stopped at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Time Processing: {time}", DateTimeOffset.Now - startTime);

            // 6 horas
            await Task.Delay(21600000, stoppingToken);
        }
    }

    private async Task ProcessProductsPricesAsync(Func<int, string> urlFunction, int productType)
    {
        const int initialPage = 1;

        var pichauInitialRequest = new PichauRequest(urlFunction(initialPage));
        var pichauInitialData = pichauInitialRequest.MakeRequest();

        if (pichauInitialData is null)
        {
            _logger.LogWarning("Não foi possível iniciar as requisições");
            return;
        }

        var finalPage = pichauInitialData.Data.Products.PageInfo.TotalPages;

        var tasks = new List<Task>();

        for (int i = 1; i <= finalPage; i++)
        {
            int page = i;
            _logger.LogInformation("Iniciando página: {0}", page.ToString());
            var pichauRequest = new PichauRequest(urlFunction(page));
            var pichauData = pichauRequest.MakeRequest();

            if (pichauData is null)
            {
                _logger.LogInformation("Falha na requisição da página {0}", page.ToString());
                continue;
            }

            if (pichauData.Data is null)
            {
                _logger.LogInformation("Falha na requisição da página {0}", page.ToString());
                continue;
            }

            tasks.Add(Task.Run(async () =>
            {
                try {

                    foreach (var product in pichauData.Data?.Products.Items)
                    {
                        var pichauProduct = new PichauProduct(product.Name, product.CodigoBarra,
                            (double)product.PichauPrices.FinalPrice);

                        if (pichauProduct.Barcode is null)
                        {
                            _logger.LogInformation("Produto com barcode nulo: {0}", pichauProduct.Name);
                            continue;
                        }

                        if (pichauProduct.Price == 0)
                        {
                            _logger.LogInformation("Produto com preço zero: {0}", pichauProduct.Name);
                            continue;
                        }

                        var productBarcodeExists = await _productQueryRepository.ProductExistsByNameAndBarcode(pichauProduct.Barcode, pichauProduct.Name);

                        if (!productBarcodeExists)
                        {
                            _logger.LogInformation("Novo produto: {0}", pichauProduct.Name);
                            var newProductId = await _productCommandRepository.AddProductToDatabase(pichauProduct.Barcode, pichauProduct.Name, productType);
                            pichauProduct.Id = newProductId;
                        }
                        else
                        {
                            _logger.LogInformation("Buscando ID produto com barcode: {0}, {1}", pichauProduct.Barcode,
                                pichauProduct.Name);
                            var existingProductId = await _productQueryRepository.GetProductIdWithBarcodeAndName(pichauProduct.Barcode, pichauProduct.Name);
                            pichauProduct.Id = existingProductId;
                        }

                        var lastPriceAlreadyExists = await _priceHistoryQueryRepository.CheckIfLastPriceAlreadyExistsToDate(
                            pichauProduct.Id,
                            pichauProduct.Price, DateTime.Now);

                        if (lastPriceAlreadyExists)
                        {
                            _logger.LogInformation("Já existe preço cadastrado para {0}, para o produto {1} com preço de R${2}",
                                DateTime.Today.ToString("dd/MM/yyyy"),
                                pichauProduct.Name,
                                pichauProduct.Price
                                );
                            continue;
                        }

                        _logger.LogInformation("Adicionando Histórico: R${0}, {1}",
                        pichauProduct.Price.ToString(CultureInfo.CurrentCulture), pichauProduct.Name);
                        await _priceHistoryCommandRepository.AddPriceHistory(pichauProduct.Id, pichauProduct.Price, DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocorreu um erro ao processar a página {0}", page);
                }
                
            }));

        }
        
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro enquanto esperava que todas as tarefas fossem concluídas");
        }
    }
}