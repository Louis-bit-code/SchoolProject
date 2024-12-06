using Hotelmanagement.Obstkorb.Model;
using Microsoft.Data.SqlClient;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public abstract class BaseStore
{
    private readonly IDatabaseConnectionFactory ConnectionFactory;
    protected readonly User UserContext;

    protected BaseStore(IDatabaseConnectionFactory connectionFactory, User userContext)
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