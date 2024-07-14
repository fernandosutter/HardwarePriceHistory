using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Domain.Models;

namespace HardwarePriceHistory.Core.Services
{
    public class ProductService
    {

        private readonly IProductQueryRepository _productQueryRepository;

        public ProductService(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        public List<Product> GetProducts(string name)
        {
            var products = _productQueryRepository.GetProductsByName(name);

            return products;
        }
    }
}
