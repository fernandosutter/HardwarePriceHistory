using HardwarePriceHistory.Core.ViewModel;
using HardwarePriceHistory.Domain.Models;

namespace HardwarePriceHistory.Core.Interfaces;

public interface IProductQueryRepository
{
    bool ProductNameExists(string name);
    
    Task<bool> ProductBarcodeExists(string barcode);

    Task<bool> ProductExistsByNameAndBarcode(string barcode, string productName);

    Task<int> GetProductIdWithBarcode(string barcode);

    Task<int> GetProductIdWithBarcodeAndName(string barcode, string productName);

    List<ProductViewModel> GetProductsByName(string name);
}