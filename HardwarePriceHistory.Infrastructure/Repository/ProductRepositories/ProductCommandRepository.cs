using Dapper;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Infrastructure.Database;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Infrastructure.Repository.ProductRepositories;

public class ProductCommandRepository : IProductCommandRepository
{
    public async Task<int> AddProductToDatabase(string barcode, string name, int productType)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"INSERT INTO Products (product_barcode, name, product_type) VALUES (@barcode, @name, @productType); SELECT SCOPE_IDENTITY()";
            int returnedId = await connection.ExecuteScalarAsync<int>(sql, new { barcode, name, productType });
            return returnedId;
        }
    }

    public bool RemoveProductFromDatabase(string barcode)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"DELETE FROM Products WHERE product_barcode = @barcode";
            var result = connection.Execute(sql, new { barcode });
            return result > 0;
        }
    }
    
    public bool RemoveProductFromDatabase(int id)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"DELETE FROM Products WHERE id = @id";
            var result = connection.Execute(sql, new { id });
            return result > 0;
        }
    }
}