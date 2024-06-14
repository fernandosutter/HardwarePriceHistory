using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.Models;

namespace HardwarePriceHistory.Core.Services
{
    public class PriceHistoryService
    {
        private readonly IPriceHistoryQueryRepository _priceHistoryQueryRepository;

        public PriceHistoryService(IPriceHistoryQueryRepository priceHistoryQueryRepository)
        {
            _priceHistoryQueryRepository = priceHistoryQueryRepository;
        }

        public List<PriceHistory> GetPrices(int productId, DateTime? initialDateTime, DateTime? finalDateTime){

            var priceHistoryFromProduct = _priceHistoryQueryRepository.GetPriceHistory(productId, initialDateTime, finalDateTime);

            return priceHistoryFromProduct;
        }
    }
}
