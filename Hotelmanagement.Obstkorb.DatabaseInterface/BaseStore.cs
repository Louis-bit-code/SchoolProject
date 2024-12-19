using Hotelmanagement.Obstkorb.Model;
using Microsoft.Data.SqlClient;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public abstract class BaseStore
{
    private readonly IDatabaseConnectionFactory ConnectionFactory;
   

    protected BaseStore(IDatabaseConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    protected SqlConnection GetOpenConnection()
    {
        var connection = ConnectionFactory.CreateConnection();
        connection.Open();
        return connection;
    }
}