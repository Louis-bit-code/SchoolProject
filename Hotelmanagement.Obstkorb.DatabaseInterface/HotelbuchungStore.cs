using Dapper;
using Hotelmanagement.Obstkorb.Model;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public class HotelbuchungStore : BaseStore, IHotelBuchungStore
{
    public HotelbuchungStore(IDatabaseConnectionFactory connectionFactory) : base(
        connectionFactory)
    {
    }


    public IEnumerable<Hotelbuchung> GetUserBookings()
    {
        throw new NotImplementedException();
    }

    public void BookRoom(int roomId, DateTime bookingStart, DateTime bookingEnd)
    {
        throw new NotImplementedException();
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