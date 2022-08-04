namespace HardwarePriceHistory.Data.Interfaces;

public interface IProductCommandRepository
{
    void AddProductToDatabase(string barcode, string name);

    bool RemoveProductFromDatabase(string barcode);

    bool RemoveProductFromDatabase(int id);
}