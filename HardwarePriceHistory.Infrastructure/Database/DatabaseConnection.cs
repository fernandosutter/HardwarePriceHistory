using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HardwarePriceHistory.Infrastructure.Database;

public class DatabaseConnection
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DatabaseConnection(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DB_CONNECTION_STRING");
    }
    public string ConnectionString => _connectionString;
}