using HardwarePriceHistory.Core.Models;

namespace HardwarePriceHistory.Application.ViewModel
{
    public class ProductViewModel
    {
        public string Barcode { get; init; }
        public string Name { get; init; }
        public static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Barcode = product.ProductBarCode,
                Name = product.ProductName
            };
        }
    }

    
    
}
