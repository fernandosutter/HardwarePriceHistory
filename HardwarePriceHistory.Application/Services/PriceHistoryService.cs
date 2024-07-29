using HardwarePriceHistory.Application.ViewModel;
using HardwarePriceHistory.Core.Interfaces;

namespace HardwarePriceHistory.Application.Services
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

            var result = priceHistoryFromProduct.Select(PriceHistoryViewModel.ToViewModel).ToList();

            return result;
        }
    }
}
