using Dapper;
using HardwarePriceHistory.Data.Database;
using HardwarePriceHistory.Data.Interfaces;
using HardwarePriceHistory.Models;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Data.Repository.PriceHistory
{
    public class PriceHistoryQueryRepository : IPriceHistoryQueryRepository
    {
        public Models.PriceHistory GetPriceHistory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PriceHistory> GetPriceHistory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PriceHistory> GetPriceHistory(string barcode)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime)
        {
            using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                var sql = @"SELECT top 1 NULL
                            FROM ProductPriceHistory
                            WHERE product_id = @ProductID
                              AND id =
                                (SELECT top 1 id
                                 FROM ProductPriceHistory
                                 WHERE product_id = @ProductID
                                   AND CAST(datetime AS Date) = @DateTime
                                 ORDER BY id DESC)
                              AND CAST(datetime AS Date) = @DateTime
                              AND price = @Price
                            ORDER BY id DESC";
                
                
                var result = connection.Query(sql, new {ProductID = productId, Price = price, DateTime = dateTime.Date });
                
                
                return result.Any();
            }
        }
    }
}
