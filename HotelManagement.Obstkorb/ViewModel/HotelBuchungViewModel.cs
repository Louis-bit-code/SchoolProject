namespace HotelManagement.Obstkorb.ViewModel
{
    using Hotelmanagement.Obstkorb.DatabaseInterface;
    using Hotelmanagement.Obstkorb.Model.Hotel;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class HotelbuchungViewModel : BaseViewModel
    {
        private IHotelZimmerStore HotelZimmerStore { get; }

        private IHotelBuchungStore HotelBuchungStore { get; }
        public ObservableCollection<Hotelzimmer> HotelzimmerListe { get; private set; }
        public ObservableCollection<Hotelbuchung> Buchungen { get; private set; }

        public ICommand BookRoomCommand { get; }

        public HotelbuchungViewModel(IHotelBuchungStore hotelbuchungStore)
        {
            HotelBuchungStore = hotelbuchungStore;
            HotelzimmerListe = new ObservableCollection<Hotelzimmer>();
            Buchungen = new ObservableCollection<Hotelbuchung>();

            // Befehl zum Buchen eines Zimmers
            BookRoomCommand = new RelayCommand<int>(BookRoom);

            // Zimmer und Buchungen laden
            LoadHotelzimmer();
            LoadBookings();
        }

        // Methode zum Laden aller Hotelzimmer
        private async Task LoadHotelzimmer()
        {
            var zimmer =  await HotelZimmerStore.GetAllRoomsAsync(); // Erhalte alle Zimmerdaten
            HotelzimmerListe.Clear();
            foreach (var item in zimmer)
            {
                HotelzimmerListe.Add(item);
            }
        }

        // Methode zum Laden aller Buchungen des Nutzers
        private void LoadBookings()
        {
            var bookings = HotelBuchungStore.GetUserBookings();
            Buchungen.Clear();
            foreach (var booking in bookings)
            {
                Buchungen.Add(booking);
            }
        }

        // Methode zum Buchen eines Zimmers
        private void BookRoom(int zimmerId)
        {
            DateTime von = DateTime.Now; // Beispielwert
            DateTime bis = DateTime.Now.AddDays(2); // Beispielwert

            HotelBuchungStore.BookRoom(zimmerId, von, bis);

            // Buchungen neu laden, damit die UI aktuell ist
            LoadBookings();
        }
    }
}