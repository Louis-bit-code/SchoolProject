namespace HotelManagement.Obstkorb.ViewModel
{
    using Hotelmanagement.Obstkorb.DatabaseInterface;
    using Hotelmanagement.Obstkorb.Model.Hotel;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class HotelbuchungViewModel : BaseViewModel
    {
        private readonly IHotelBuchungStore _hotelbuchungStore;
        public ObservableCollection<Hotelzimmer> HotelzimmerListe { get; private set; }
        public ObservableCollection<Hotelbuchung> Buchungen { get; private set; }

        public ICommand BookRoomCommand { get; }

        public HotelbuchungViewModel(IHotelBuchungStore hotelbuchungStore)
        {
            _hotelbuchungStore = hotelbuchungStore;
            HotelzimmerListe = new ObservableCollection<Hotelzimmer>();
            Buchungen = new ObservableCollection<Hotelbuchung>();

            // Befehl zum Buchen eines Zimmers
            BookRoomCommand = new RelayCommand<Guid>(BookRoom);

            // Zimmer und Buchungen laden
            LoadHotelzimmer();
            LoadBookings();
        }

        // Methode zum Laden aller Hotelzimmer
        private void LoadHotelzimmer()
        {
            var zimmer = _hotelbuchungStore.GetAllRooms();  // Erhalte alle Zimmerdaten
            HotelzimmerListe.Clear();
            foreach (var item in zimmer)
            {
                HotelzimmerListe.Add(item);
            }
        }

        // Methode zum Laden aller Buchungen des Nutzers
        private void LoadBookings()
        {
            var bookings = _hotelbuchungStore.GetBookingsByUser();
            Buchungen.Clear();
            foreach (var booking in bookings)
            {
                Buchungen.Add(booking);
            }
        }

        // Methode zum Buchen eines Zimmers
        private void BookRoom(Guid zimmerId)
        {
            var von = DateTime.Now;  // Beispielwert
            var bis = DateTime.Now.AddDays(2);  // Beispielwert

            _hotelbuchungStore.BookRoom(zimmerId, von, bis);

            // Buchungen neu laden, damit die UI aktuell ist
            LoadBookings();
        }
    }
}