using Dapper;
using HardwarePriceHistory.Data.Database;
using HardwarePriceHistory.Data.Interfaces;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Data.Repository.PriceHistory;

public class PriceHistoryCommandRepository : IPriceHistoryCommandRepository
{
    public bool AddPriceHistory(WebApi.Models.PriceHistory priceHistory)
    {
        using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
        {
            connection.Open();
            string sql = @"INSERT INTO ProductPriceHistory (product_id, price, datetime) VALUES (@ProductId, @Price, @Date)";
            connection.Execute(sql, new { ProductId = priceHistory.ProductId, Price = priceHistory.Price, Date = priceHistory.Date });
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