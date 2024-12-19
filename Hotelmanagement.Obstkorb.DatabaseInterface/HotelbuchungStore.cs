using Dapper;
using Hotelmanagement.Obstkorb.Model;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class HotelbuchungStore : BaseStore, IHotelBuchungStore
{
    public HotelbuchungStore(IDatabaseConnectionFactory connectionFactory, User userContext) : base(
        connectionFactory, userContext)
    {
    }

    public IEnumerable<Hotelbuchung> GetUserBookings()
    {
        using (var connection = GetOpenConnection())
        {
            var query = "SELECT * FROM Booking WHERE UserID = @UserID";
            return connection.Query<Hotelbuchung>(query, new { UserID = UserContext.Id });
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
                UserID = UserContext.Id,
                RoomID = roomId,
                BookingStart = bookingStart,
                BookingEnd = bookingEnd
            });
        }
    }

    public IEnumerable<Hotelbuchung> GetAllBookings()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hotelbuchung> GetBookingsByUserId(object id)
    {
        throw new NotImplementedException();
    }
}