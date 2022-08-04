namespace HardwarePriceHistory.Data.Interfaces;

public interface IProductQueryRepository
{
    bool ProductNameExists(string name);
    
    bool ProductBarcodeExists(string barcode);
}