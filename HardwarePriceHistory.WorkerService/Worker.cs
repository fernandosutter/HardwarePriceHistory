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
        #region Repositories
        ProductCommandRepository productCommandRepository = new ProductCommandRepository();
        ProductQueryRepository productQueryRepository = new ProductQueryRepository();
        PriceHistoryCommandRepository priceHistoryCommandRepository = new PriceHistoryCommandRepository();
        #endregion
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            int initialPage = 1;
            int finalPage;

            PichauRequest pichauInitialRequest = new PichauRequest(PichauAddresses.PichauUrlGpu(initialPage));
            var pichauInitialData = pichauInitialRequest.MakeRequest();

            finalPage = pichauInitialData.Data.Products.PageInfo.TotalPages;
            
            for (int i = initialPage; i < finalPage; i++)
            {
                
                _logger.LogInformation("Iniciando página: {0}", i.ToString());
                PichauRequest pichauRequest = new PichauRequest(PichauAddresses.PichauUrlGpu(i));
                var pichauData = pichauRequest.MakeRequest();
                
                foreach (var product in pichauData.Data.Products.Items)
                {
                    PichauProduct pichauProduct = new PichauProduct(product.Name, product.CodigoBarra, product.PriceRange.MaximumPrice.FinalPrice.Value);

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
                        _logger.LogInformation("Novo produto: {0}", pichauProduct.Name );
                        var newProductId = productCommandRepository.AddProductToDatabase(pichauProduct.Barcode, pichauProduct.Name);
                        pichauProduct.Id = newProductId;
                    }
                    else
                    {
                        _logger.LogInformation("Buscando ID produto com barcode: {0}, {1}",pichauProduct.Barcode, pichauProduct.Name );
                        var existingProductId = productQueryRepository.GetProductIdWithBarcode(pichauProduct.Barcode);
                        pichauProduct.Id = existingProductId;
                    }
                
                    _logger.LogInformation("Adicionando Histórico: R${0}, {1}",pichauProduct.Price.ToString(), pichauProduct.Name );
                    priceHistoryCommandRepository.AddPriceHistory(pichauProduct.Id,pichauProduct.Price, DateTime.Now);
                }
                
            }
            
            // 12 horas
            await Task.Delay(43200000, stoppingToken);
        }
    }
}