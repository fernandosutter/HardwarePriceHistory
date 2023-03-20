namespace HardwarePriceHistory.Data.Interfaces;

public interface IProductCommandRepository
{
    Task<int> AddProductToDatabase(string barcode, string name, int productType);

    bool RemoveProductFromDatabase(string barcode);

    bool RemoveProductFromDatabase(int id);
}