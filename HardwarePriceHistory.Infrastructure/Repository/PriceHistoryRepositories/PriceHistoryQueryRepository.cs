﻿using System.Text;
using Dapper;
using HardwarePriceHistory.Infrastructure.Database;
using HardwarePriceHistory.Core.Interfaces;
using HardwarePriceHistory.Core.Models;
using Microsoft.Data.SqlClient;

namespace HardwarePriceHistory.Infrastructure.Repository.PriceHistoryRepositories
{
    public class PriceHistoryQueryRepository : IPriceHistoryQueryRepository
    {
        public List<PriceHistory> GetPriceHistory(int productId, DateTime? initialDate, DateTime? finalDate)
        {
            using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
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
                    where product_id = @ProductId
                 ");

                if (initialDate is not null && finalDate is not null)
                    sql.Append("and datetime between @InitialDate and @FinalDate");

                sql.Append("order by id asc");

                #endregion

                var result = connection.Query<Core.Models.PriceHistory>(sql.ToString(),
                    new { ProductId = productId, InitialDate = initialDate, FinalDate = finalDate });

                return result.ToList();
            }
        }
        
        public async Task<bool> CheckIfLastPriceAlreadyExistsToDate(int productId, double price, DateTime dateTime)
        {
            using (var connection = new SqlConnection(DatabaseConnection.ConnectionString))
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
