using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Models;

namespace HardwarePriceHistory.WebAPI.Services
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
