using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface
{
    public interface IHotelZimmerStore
    {
        Task<List<Hotelzimmer>> GetAllRoomsAsync();
    }
}