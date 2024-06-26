namespace HardwarePriceHistory.Core.Interfaces;

public interface IPriceHistoryCommandRepository
{
    Task<bool> AddPriceHistory(int productId, double productPrice, DateTime datetime);
    
    bool DeletePriceHistory(int id);
}