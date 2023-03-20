using Dapper;
using HardwarePriceHistory.Data.Database;
using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Models;
using Microsoft.Data.SqlClient;

public class ProductQueryRepository : IProductQueryRepository
{
    public bool ProductNameExists(string name)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 * FROM Products WHERE name like  '%' + @name + '%'";
            var result = connection.Query<Product>(sql, new { name });
            return result.Any();
        }
    }

    public async Task<bool> ProductBarcodeExists(string barcode)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 * FROM Products WHERE product_barcode like  '%' + @barcode + '%'";
            var result = await connection.QueryAsync<Product>(sql, new { barcode });
            return result.Any();
        }
    }

    public async Task<int> GetProductIdWithBarcode(string barcode)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 id FROM Products WHERE product_barcode like  '%' + @barcode + '%'";
            var result = await connection.QueryFirstAsync<int>(sql, new { barcode });
            return result;
        }
    }
}