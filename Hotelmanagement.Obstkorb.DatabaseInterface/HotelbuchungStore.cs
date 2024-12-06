using Dapper;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class HotelbuchungStore : BaseStore, IHotelBuchungStore
{
    public HotelbuchungStore(IDatabaseConnectionFactory connectionFactory, UserContext userContext) : base(
        connectionFactory, userContext)
    {
    }

    public IEnumerable<Hotelbuchung> GetUserBookings()
    {
        using (var connection = GetOpenConnection())
        {
            var query = "SELECT * FROM Booking WHERE UserID = @UserID";
            return connection.Query<Hotelbuchung>(query, new { UserID = UserContext.UserId });
        }
    }

    public void BookRoom(int roomId, DateTime bookingStart, DateTime bookingEnd)
    {
        using (var connection = GetOpenConnection())
        {
            var query =
                "INSERT INTO Booking (UserID, RoomID, BookingStart, BookingEnd) VALUES (@UserID, @RoomID, @BookingStart, @BookingEnd)";
            connection.Execute(query, new
            {
                UserID = UserContext.UserId,
                RoomID = roomId,
                BookingStart = bookingStart,
                BookingEnd = bookingEnd
            });
        }
    }
}