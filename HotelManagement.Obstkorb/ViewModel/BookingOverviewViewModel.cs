using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.Collections.ObjectModel;
using Hotelmanagement.Obstkorb.Model;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class BookingOverviewViewModel : BaseViewModel
    {
        private readonly IHotelBuchungStore _hotelBuchungStore;
        private readonly UserContext _userContext;

        public ObservableCollection<Hotelbuchung> UserBookings { get; private set; }

        public BookingOverviewViewModel(IHotelBuchungStore hotelBuchungStore, UserContext userContext)
        {
            _hotelBuchungStore = hotelBuchungStore;
            _userContext = userContext;

            LoadBookings();
        }

        private void LoadBookings()
        {
            var bookings = _hotelBuchungStore.GetBookingsByUserId(_userContext.CurrentUser.Id);
            UserBookings = new ObservableCollection<Hotelbuchung>(bookings);
        }
    }
}