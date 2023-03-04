using System.Globalization;
using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Data.Repository.PriceHistory;
using HardwarePriceHistory.Data.Repository.Product;
using HardwarePriceHistory.Pichau.Addresses;
using HardwarePriceHistory.Pichau.Models;
using HardwarePriceHistory.Pichau.Requests;

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
            ProcessProductsPrices(PichauAddresses.PichauUrlGpu,1);
            _logger.LogInformation("Iniciando as Mobos");
            ProcessProductsPrices(PichauAddresses.PichauUrlMobo,2);
            _logger.LogInformation("Iniciando as Rams");
            ProcessProductsPrices(PichauAddresses.PichauUrlRam,3);
            _logger.LogInformation("Iniciando as CPUs AMD");
            ProcessProductsPrices(PichauAddresses.PichauUrlProcessorAmd,4);
            _logger.LogInformation("Iniciando as CPUs Intel");
            ProcessProductsPrices(PichauAddresses.PichauUrlProcessorIntel,5);
            
            _logger.LogInformation("Worker Stopped at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Time Processing: {time}", DateTimeOffset.Now - startTime);

            // 6 horas
            await Task.Delay(21600000, stoppingToken);
        }
    }

    private void ProcessProductsPrices(Func<int, string> urlFunction, int productType)
    {
        const int initialPage = 1;

        var pichauInitialRequest = new PichauRequest(urlFunction(initialPage));
        var pichauInitialData = pichauInitialRequest.MakeRequest();

        var finalPage = pichauInitialData.Data.Products.PageInfo.TotalPages;

        for (var i = initialPage; i < finalPage; i++)
        {
            _logger.LogInformation("Iniciando página: {0}", i.ToString());
            var pichauRequest = new PichauRequest(urlFunction(i));
            var pichauData = pichauRequest.MakeRequest();

            if (pichauData.Data is null)
            {
                _logger.LogInformation("Falha na requisição da página {0}", i.ToString());
                continue;
            }

            foreach (var product in pichauData.Data?.Products.Items)
            {
                var pichauProduct = new PichauProduct(product.Name, product.CodigoBarra,
                    product.PriceRange.MaximumPrice.FinalPrice.Value);

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

                if (!_productQueryRepository.ProductBarcodeExists(pichauProduct.Barcode))
                {
                    _logger.LogInformation("Novo produto: {0}", pichauProduct.Name);
                    var newProductId = _productCommandRepository.AddProductToDatabase(pichauProduct.Barcode, pichauProduct.Name, productType);
                    pichauProduct.Id = newProductId;
                }
                else
                {
                    _logger.LogInformation("Buscando ID produto com barcode: {0}, {1}", pichauProduct.Barcode,
                        pichauProduct.Name);
                    var existingProductId = _productQueryRepository.GetProductIdWithBarcode(pichauProduct.Barcode);
                    pichauProduct.Id = existingProductId;
                }

                if (_priceHistoryQueryRepository.CheckIfLastPriceAlreadyExistsToDate(pichauProduct.Id,
                        pichauProduct.Price, DateTime.Now))
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
                _priceHistoryCommandRepository.AddPriceHistory(pichauProduct.Id, pichauProduct.Price, DateTime.Now);

            }
        }
    }
}