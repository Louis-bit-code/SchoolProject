using Hotelmanagement.Obstkorb.Model.Hotel;

namespace Hotelmanagement.Obstkorb.DatabaseInterface
{
    public class HotelZimmerStore : IHotelZimmerStore

    {
        public Task<List<Hotelzimmer>> GetAllRoomsAsync()
        {
            throw new NotImplementedException();
        }
    }
}