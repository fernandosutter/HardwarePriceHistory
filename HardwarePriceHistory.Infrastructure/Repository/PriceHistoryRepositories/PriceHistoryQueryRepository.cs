using System.Text;
using Dapper;
using HardwarePriceHistory.Infrastructure.Database;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.Models;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Infrastructure.Repository.PriceHistoryRepositories
{
    public class PriceHistoryQueryRepository : IPriceHistoryQueryRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public PriceHistoryQueryRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public List<PriceHistory> GetPriceHistory(long productBarCode, DateTime? initialDate, DateTime? finalDate)
        {
            using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
            {
                connection.Open();

                #region SQL
                var sql = new StringBuilder(@"
    
                    select 
	                    id as Id,
	                    product_id as ProductId,
	                    price as Price,
	                    datetime as Date
                    from ProductPriceHistory
                    where product_id = (select top 1 id from Products where product_barcode = @ProductBarcode)
                 ");

                if (initialDate is not null && finalDate is not null)
                    sql.Append("and datetime between @InitialDate and @FinalDate");

                sql.Append("order by id asc");

                #endregion

                var result = connection.Query<PriceHistory>(sql.ToString(),
                    new { ProductBarcode = productBarCode, InitialDate = initialDate, FinalDate = finalDate });

                return result.ToList();
            }
        }
        
        public async Task<bool> CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime)
        {
            using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
            {
                connection.Open();

                #region SQL
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
                #endregion

                var result = await connection.QueryAsync(sql, new {ProductID = productId, Price = price, DateTime = dateTime.Date });
                
                return result.Any();
            }
        }
    }
}
