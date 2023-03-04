using HardwarePriceHistory.Models;

namespace HardwarePriceHistory.Data.Interfaces;

public interface IPriceHistoryQueryRepository
{
    PriceHistory GetPriceHistory(int id);
    
    IEnumerable<PriceHistory> GetPriceHistory();

    IEnumerable<PriceHistory> GetPriceHistory(string barcode);

    bool CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime);
}