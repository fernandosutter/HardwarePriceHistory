namespace HardwarePriceHistory.Data.Interfaces;

public interface IProductQueryRepository
{
    bool ProductNameExists(string name);
    
    Task<bool> ProductBarcodeExists(string barcode);
    
    Task<int> GetProductIdWithBarcode(string barcode);
}