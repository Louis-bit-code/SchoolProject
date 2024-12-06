using Microsoft.Data.SqlClient;
using System.Text;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class UserStore : IUserStore
{
    private readonly IDatabaseConnectionFactory _connectionFactory;

    public UserStore(IDatabaseConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public bool AuthenticateUser(string username, string password)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            connection.Open();
            var query = "SELECT PasswordHash FROM [User] WHERE Username = @Username";
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Username", username);

            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                var savedPasswordHash = result.ToString();
                var inputPasswordHash = HashPassword(password);

                return savedPasswordHash == inputPasswordHash;
            }
        }

        return false;
    }

    public bool RegisterUser(string username, string password)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            connection.Open();
            var query = "INSERT INTO [User] (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                // Benutzername ist möglicherweise bereits vorhanden
                return false;
            }
        }
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes) builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}