
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Input;
using System.Xml.Linq;
using HotelManagement.Obstkorb.DatabaseInterface;
using HotelManagement.Obstkorb.ViewModel;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class ZimmerBuchungViewModel : BaseViewModel
    {
        private readonly BuchungStore _buchungStore;

        public ObservableCollection<string> RoomCategories { get; private set; }
        public ObservableCollection<string> Customers { get; private set; }
        public ObservableCollection<string> Prices { get; private set; }

        private string _selectedRoomCategory;
        public string SelectedRoomCategory
        {
            get => _selectedRoomCategory;
            set
            {
                _selectedRoomCategory = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _checkInDate;
        public DateTime? CheckInDate
        {
            get => _checkInDate;
            set
            {
                _checkInDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _checkOutDate;
        public DateTime? CheckOutDate
        {
            get => _checkOutDate;
            set
            {
                _checkOutDate = value;
                OnPropertyChanged();
            }
        }

        private int _numberOfGuests;
        public int NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmBookingCommand { get; }

        public ZimmerBuchungViewModel(BuchungStore buchungStore)
        {
            _buchungStore = buchungStore;
            LoadData();

            ConfirmBookingCommand = new RelayCommand(ConfirmBooking, CanConfirmBooking);
        }

        private void LoadData()
        {
            // Mock data for demonstration purposes (replace with actual data fetching)
            RoomCategories = new ObservableCollection<string> { "Einzelzimmer", "Doppelzimmer", "Suite" };
            Customers = new ObservableCollection<string> { "Max Mustermann", "Lisa Müller", "John Doe" };
            Prices = new ObservableCollection<string> { "50 EUR", "100 EUR", "150 EUR" };
            OnPropertyChanged(nameof(RoomCategories));
            OnPropertyChanged(nameof(Customers));
            OnPropertyChanged(nameof(Prices));
        }

        private bool CanConfirmBooking()
        {
            return !string.IsNullOrEmpty(SelectedRoomCategory) &&
                   CheckInDate.HasValue &&
                   CheckOutDate.HasValue &&
                   NumberOfGuests > 0;
        }

        private void ConfirmBooking()
        {
            // Implement the logic for confirming a booking here
            // Example:
            try
            {
                _buchungStore.AddBuchung(Guid.NewGuid(), Guid.NewGuid(), CheckInDate.Value, CheckOutDate.Value, NumberOfGuests);
                TotalPrice = CalculateTotalPrice();
                OnPropertyChanged(nameof(TotalPrice));
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private decimal CalculateTotalPrice()
        {
            // Implement logic to calculate the total price
            return 100m; // Placeholder value
        }
    }
}