using HardwarePriceHistory.Application.ViewModel;
using HardwarePriceHistory.Core.Interfaces;

namespace HardwarePriceHistory.Application.Services
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

            var result = products.Select(ProductViewModel.ToViewModel).ToList();

            return result;
        }
    }
}
