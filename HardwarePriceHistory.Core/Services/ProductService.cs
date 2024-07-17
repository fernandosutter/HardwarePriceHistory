using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.ViewModel;

namespace HardwarePriceHistory.Core.Services
{
    public class ProductService
    {

        private readonly IProductQueryRepository _productQueryRepository;

        public ProductService(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public List<ProductViewModel> GetProducts(string name)
        {
            var products = _productQueryRepository.GetProductsByName(name);

            return products;
        }
    }
}
