using HotelManagement.Obstkorb.DatabaseInterface;
using HotelManagement.Obstkorb.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly BuchungStore _buchungStore;
        private readonly Func<ZimmerBuchungViewModel> _zimmerBuchungViewModelFactory;

        public ObservableCollection<dynamic> RecentBookings { get; private set; }
        public ICommand ShowZimmerbuchungViewCommand { get; }
        public ICommand AddBookingCommand { get; }

        public Guid SelectedCustomerId { get; set; }
        public Guid SelectedPriceId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int SelectedRoomNumber { get; set; }

        public MainViewModel(BuchungStore buchungStore, Func<ZimmerBuchungViewModel> zimmerBuchungViewModelFactory)
        {
            _buchungStore = buchungStore;
            _zimmerBuchungViewModelFactory = zimmerBuchungViewModelFactory;
            LoadBuchungen();

            ShowZimmerbuchungViewCommand = new RelayCommand(ShowZimmerbuchungView);
            AddBookingCommand = new RelayCommand(AddBooking);
        }

        private void LoadBuchungen()
        {
            var buchungen = _buchungStore.GetBuchungen();
            RecentBookings = new ObservableCollection<dynamic>(buchungen);
            OnPropertyChanged(nameof(RecentBookings));
        }

        private void ShowZimmerbuchungView()
        {
            var viewModel = _zimmerBuchungViewModelFactory();
            var container = Application.Current.MainWindow.FindName("ContentControl") as ContentControl;
            if (container != null)
            {
                container.Content = new ZimmerBuchungView { DataContext = viewModel };
            }
        }

        private void AddBooking()
        {
            try
            {
                _buchungStore.AddBuchung(SelectedCustomerId, SelectedPriceId, CheckInDate, CheckOutDate, SelectedRoomNumber);
                LoadBuchungen(); // Aktualisiere die Liste der Buchungen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Erstellen der Buchung: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}