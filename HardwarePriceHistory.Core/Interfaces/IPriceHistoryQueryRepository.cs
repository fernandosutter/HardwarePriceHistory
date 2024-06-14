using HardwarePriceHistory.Core.Models;

namespace HardwarePriceHistory.Core.Interfaces;

public interface IPriceHistoryQueryRepository
{
    List<PriceHistory> GetPriceHistory(int productId, DateTime? initialDate, DateTime? finalDate);

    Task<bool> CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime);
}