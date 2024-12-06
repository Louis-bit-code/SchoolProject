using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class UserRepository
{
    private readonly string _connectionString =
        "Server=DEIN_SERVER;Database=DEINE_DATENBANK;User Id=DEIN_BENUTZER;Password=DEIN_PASSWORT;";

    public int AuthenticateUser(string username, string password)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "SELECT UserID FROM [User] WHERE Username = @Username AND PasswordHash = @Password";
            return connection.ExecuteScalar<int>(sql, new { Username = username, Password = password });
        }
    }

    public IEnumerable<Hotelzimmer> GetAvailableRooms()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql =
                "SELECT * FROM Room WHERE RoomID NOT IN (SELECT RoomID FROM Booking WHERE BookingStart <= GETDATE() AND BookingEnd >= GETDATE())";
            return connection.Query<Hotelzimmer>(sql);
        }
    }
}