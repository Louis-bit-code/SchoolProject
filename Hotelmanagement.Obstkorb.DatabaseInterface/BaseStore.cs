using Microsoft.Data.SqlClient;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public abstract class BaseStore
{
    private readonly IDatabaseConnectionFactory ConnectionFactory;
    protected readonly UserContext UserContext;

    protected BaseStore(IDatabaseConnectionFactory connectionFactory, UserContext userContext)
    {
        ConnectionFactory = connectionFactory;
        UserContext = userContext;
    }

    protected SqlConnection GetOpenConnection()
    {
        var connection = ConnectionFactory.CreateConnection();
        connection.Open();
        return connection;
    }
}