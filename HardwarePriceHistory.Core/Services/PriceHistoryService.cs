using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.ViewModel;

namespace HardwarePriceHistory.Core.Services
{
    public class PriceHistoryService
    {
        private readonly IPriceHistoryQueryRepository _priceHistoryQueryRepository;

        public PriceHistoryService(IPriceHistoryQueryRepository priceHistoryQueryRepository)
        {
            _priceHistoryQueryRepository = priceHistoryQueryRepository;
        }

        public List<PriceHistoryViewModel> GetPrices(long productBarCode, DateTime? initialDateTime, DateTime? finalDateTime){

            var priceHistoryFromProduct = _priceHistoryQueryRepository.GetPriceHistory(productBarCode, initialDateTime, finalDateTime);

            return priceHistoryFromProduct;
        }
    }
}
