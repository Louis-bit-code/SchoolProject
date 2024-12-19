using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface;

public interface IHotelBuchungStore
{
    IEnumerable<Hotelbuchung> GetUserBookings();
    void BookRoom(int roomId, DateTime bookingStart, DateTime bookingEnd);

    IEnumerable<Hotelbuchung> GetAllBookings();
    IEnumerable<Hotelbuchung> GetBookingsByUserId(object id);
}