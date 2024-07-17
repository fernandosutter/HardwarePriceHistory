using HardwarePriceHistory.Core.ViewModel;

namespace HardwarePriceHistory.Core.Interfaces;

public interface IPriceHistoryQueryRepository
{
    List<PriceHistoryViewModel> GetPriceHistory(long productBarCode, DateTime? initialDate, DateTime? finalDate);

    Task<bool> CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime);
}