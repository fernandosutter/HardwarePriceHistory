using HardwarePriceHistory.WebApi.Models;

namespace HardwarePriceHistory.Data.Interfaces;

public interface IPriceHistoryCommandRepository
{
    bool AddPriceHistory(int productId, double productPrice, DateTime datetime);
    
    bool DeletePriceHistory(int id);
}