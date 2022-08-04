using HardwarePriceHistory.WebApi.Models;

namespace HardwarePriceHistory.Data.Interfaces;

public interface IPriceHistoryCommandRepository
{
    bool AddPriceHistory(PriceHistory priceHistory);
    
    bool DeletePriceHistory(int id);
}