using System.Globalization;
using HardwarePriceHistory.Data.Repository.PriceHistory;
using HardwarePriceHistory.Data.Repository.Product;
using HardwarePriceHistory.Pichau.Addresses;
using HardwarePriceHistory.Pichau.Models;
using HardwarePriceHistory.Pichau.Requests;

namespace HardwarePriceHistory.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
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
            _logger.LogInformation("Iniciando as CPU AMD");
            ProcessProductsPrices(PichauAddresses.PichauUrlProcessorAmd,4);
            _logger.LogInformation("Iniciando as CPU Intel");
            ProcessProductsPrices(PichauAddresses.PichauUrlProcessorIntel,5);
            
            _logger.LogInformation("Worker Stopped at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Time Processing: {time}", DateTimeOffset.Now - startTime);

            // 6 horas
            await Task.Delay(21600000, stoppingToken);
        }
    }

    private void ProcessProductsPrices(Func<int, string> urlFunction, int productType)
    {
        #region Repositories

        ProductCommandRepository productCommandRepository = new ProductCommandRepository();
        ProductQueryRepository productQueryRepository = new ProductQueryRepository();
        PriceHistoryCommandRepository priceHistoryCommandRepository = new PriceHistoryCommandRepository();

        #endregion

        int initialPage = 1;
        int finalPage;

        PichauRequest pichauInitialRequest = new PichauRequest(urlFunction(initialPage));
        var pichauInitialData = pichauInitialRequest.MakeRequest();

        finalPage = pichauInitialData.Data.Products.PageInfo.TotalPages;

        for (int i = initialPage; i < finalPage; i++)
        {
            _logger.LogInformation("Iniciando página: {0}", i.ToString());
            PichauRequest pichauRequest = new PichauRequest(urlFunction(i));
            var pichauData = pichauRequest.MakeRequest();

            if (pichauData is null)
            {
                _logger.LogInformation("Falha na requisição da página {0}", i.ToString());
                continue;
            }

                foreach (var product in pichauData.Data.Products.Items)
            {
                PichauProduct pichauProduct = new PichauProduct(product.Name, product.CodigoBarra,
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

                if (!productQueryRepository.ProductBarcodeExists(pichauProduct.Barcode))
                {
                    _logger.LogInformation("Novo produto: {0}", pichauProduct.Name);
                    var newProductId =
                        productCommandRepository.AddProductToDatabase(pichauProduct.Barcode, pichauProduct.Name, productType);
                    pichauProduct.Id = newProductId;
                }
                else
                {
                    _logger.LogInformation("Buscando ID produto com barcode: {0}, {1}", pichauProduct.Barcode,
                        pichauProduct.Name);
                    var existingProductId = productQueryRepository.GetProductIdWithBarcode(pichauProduct.Barcode);
                    pichauProduct.Id = existingProductId;
                }

                _logger.LogInformation("Adicionando Histórico: R${0}, {1}",
                    pichauProduct.Price.ToString(CultureInfo.CurrentCulture), pichauProduct.Name);
                priceHistoryCommandRepository.AddPriceHistory(pichauProduct.Id, pichauProduct.Price, DateTime.Now);
            }
        }
    }
}