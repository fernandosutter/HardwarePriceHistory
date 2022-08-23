using Dapper;
using HardwarePriceHistory.Data.Database;
using HardwarePriceHistory.Data.Interfaces;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Data.Repository.Product;

public class ProductQueryRepository : IProductQueryRepository
{
    public bool ProductNameExists(string name)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 * FROM Products WHERE name like  '%' + @name + '%'";
            var result = connection.Query<WebApi.Models.Product>(sql, new { name });
            return result.Any();
        }
    }

    public bool ProductBarcodeExists(string barcode)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 * FROM Products WHERE product_barcode like  '%' + @barcode + '%'";
            var result = connection.Query<WebApi.Models.Product>(sql, new { barcode });
            return result.Any();
        }
    }

    public int GetProductIdWithBarcode(string barcode)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 id FROM Products WHERE product_barcode like  '%' + @barcode + '%'";
            var result = connection.QueryFirst<int>(sql, new { barcode });
            return result;
        }
    }
}