namespace HardwarePriceHistory.Pichau.Models;

public class PichauProduct
{

    public PichauProduct(string name, string barcode, double price)
    {
        Name = name;
        Barcode = barcode;
        Price = price;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }

    public string Barcode { get; set; }
    
    public double Price { get; set; }
}