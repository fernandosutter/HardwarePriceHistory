namespace HardwarePriceHistory.Data.Database;

public static class DatabaseConnection
{
    public static string ConnectionString
    {
        //Tratar variavel de ambiente para substituir o valor da string de conexão
        get
        {
            #if DEBUG
            return "Server=192.168.101.11,1433;Database=HardwarePriceHistory;User ID=sa;Password=SQLSUTTER@123;TrustServerCertificate=True;";
            #endif
        }
    }
}