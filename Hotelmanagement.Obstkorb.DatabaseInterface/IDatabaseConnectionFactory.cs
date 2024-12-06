using Microsoft.Data.SqlClient;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public interface IDatabaseConnectionFactory
{
    SqlConnection CreateConnection();
}