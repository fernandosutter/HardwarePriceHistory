using HardwarePriceHistory.Data.Database;
using HardwarePriceHistory.Data.Interfaces;
using Dapper;   
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Data.Repository.Product;

public class ProductCommandRepository : IProductCommandRepository
{
    public ProductCommandRepository()
    {
    }
    
    public void AddProductToDatabase(string barcode, string name)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"INSERT INTO Products (product_barcode, name) VALUES (@barcode, @name)";
            connection.Execute(sql, new { barcode, name });
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