using HardwarePriceHistory.Data.Repository.Product;
using HardwarePriceHistory.Pichau.Models;

ProductCommandRepository productCommandRepository = new ProductCommandRepository();
ProductQueryRepository productQueryRepository = new ProductQueryRepository();
PichauProduct pichauProduct = new PichauProduct("Oi", "123", 234.54);


if (!productQueryRepository.ProductBarcodeExists(pichauProduct.Barcode))
{
    var newProductId = productCommandRepository.AddProductToDatabase(pichauProduct.Barcode, pichauProduct.Name);
    pichauProduct.Id = newProductId;
}

Console.WriteLine("Deu certo");
