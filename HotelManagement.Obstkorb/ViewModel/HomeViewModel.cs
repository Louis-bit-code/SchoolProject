using System.Collections.ObjectModel;
using System.Windows.Input;
using Hotelmanagement.Obstkorb.Model;
using Hotelmanagement.Obstkorb.DatabaseInterface;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        // Property für die aktuelle Ansicht
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        // Property für die Zimmerliste
        private ObservableCollection<Hotelzimmer> _roomStatusList;
        public ObservableCollection<Hotelzimmer> RoomStatusList
        {
            get => _roomStatusList;
            set => SetProperty(ref _roomStatusList, value);
        }

        // Command zur Anzeige der Buchungsübersicht
        public ICommand ShowBookingOverviewCommand { get; }

        // Abhängigkeiten
        private readonly IHotelZimmerStore _hotelZimmerStore;

        // Konstruktor mit Abhängigkeiten
        public HomeViewModel(IHotelZimmerStore hotelZimmerStore, BookingOverviewViewModel bookingOverviewViewModel)
        {
            _hotelZimmerStore = hotelZimmerStore;

            // Command initialisieren
            ShowBookingOverviewCommand = new RelayCommand<object>(_ => ShowBookingOverview(bookingOverviewViewModel));

            // Initiale Daten laden
            LoadRoomStatuses();
        }

        // Methode zum Laden der Zimmerdaten
        private async Task LoadRoomStatuses()
        {
            var rooms =  await _hotelZimmerStore.GetAllRoomsAsync(); // Annahme: GetAllRooms() liefert alle Hotelzimmer
            RoomStatusList = new ObservableCollection<Hotelzimmer>(rooms);
        }

            // Methode zur Anzeige der Buchungsübersicht
            private void ShowBookingOverview(BookingOverviewViewModel bookingOverviewViewModel)
            {
                CurrentView = bookingOverviewViewModel;
            }
        }
    }