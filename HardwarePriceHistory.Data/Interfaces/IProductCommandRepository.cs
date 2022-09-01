namespace HardwarePriceHistory.Data.Interfaces;

public interface IProductCommandRepository
{
    int AddProductToDatabase(string barcode, string name, int productType);

    bool RemoveProductFromDatabase(string barcode);

    bool RemoveProductFromDatabase(int id);
}