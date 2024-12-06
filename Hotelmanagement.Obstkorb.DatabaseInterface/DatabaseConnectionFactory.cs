using Microsoft.Data.SqlClient;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class DatabaseConnectionFactory : IDatabaseConnectionFactory
{
    private readonly string ConnectionString;

    public DatabaseConnectionFactory(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}