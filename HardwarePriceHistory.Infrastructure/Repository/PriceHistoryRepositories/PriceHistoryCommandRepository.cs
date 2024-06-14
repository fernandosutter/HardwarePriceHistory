using Dapper;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Infrastructure.Database;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Infrastructure.Repository.PriceHistoryRepositories;

public class PriceHistoryCommandRepository : IPriceHistoryCommandRepository
{
    public async Task<bool> AddPriceHistory(int productId, double productPrice, DateTime datetime)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            string sql = @"INSERT INTO ProductPriceHistory (product_id, price, datetime) VALUES (@ProductId, @Price, @Date)";
            await connection.ExecuteAsync(sql, new { ProductId = productId, Price = productPrice, Date = datetime });
        }
        return true;
    }

    public bool DeletePriceHistory(int id)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            string sql = @"DELETE FROM ProductPriceHistory WHERE id = @Id";
            connection.Execute(sql, new { Id = id });
        }
        return true;
    }
}