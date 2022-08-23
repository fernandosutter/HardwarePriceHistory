namespace HardwarePriceHistory.Data.Database;

public static class DatabaseConnection
{
    private const string _connectionString = "Server=192.168.101.15,1433;Database=HardwarePriceHistory;User ID=sa;Password=SQLSUTTER@123;TrustServerCertificate=True;";
    
    public static string ConnectionString
    {
        //Tratar variavel de ambiente para substituir o valor da string de conexão
        get
        {
            return _connectionString;
        }
    }
}