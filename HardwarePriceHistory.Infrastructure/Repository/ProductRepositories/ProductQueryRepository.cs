using Dapper;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Domain.Models;
using HardwarePriceHistory.Infrastructure.Database;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Infrastructure.Repository.ProductRepositories;

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

    public async Task<bool> ProductExistsByNameAndBarcode(string barcode, string productName)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 * FROM Products WHERE product_barcode like  '%' + @barcode + '%' and name = @productName";
            var result = await connection.QueryAsync<Product>(sql, new { barcode, productName });
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

    public async Task<int> GetProductIdWithBarcodeAndName(string barcode, string productName)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            var sql = @"SELECT top 1 id FROM Products WHERE product_barcode like  '%' + @barcode + '%' and name = @productName";
            var result = await connection.QueryFirstAsync<int>(sql, new { barcode, productName });
            return result;
        }
    }

    public List<Product> GetProductsByName(string name)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();

            #region SQL

            var sql = @"SELECT id as Id,
                            product_barcode as ProductBarCode,
                            name as ProductName
                        FROM Products WHERE name like  '%' + @name + '%'";

            #endregion

            var result = connection.Query<Product>(sql, new { name });

            return result.ToList();
        }
    }

}