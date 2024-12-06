using Hotelmanagement.Obstkorb.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Hotelmanagement.Obstkorb.DatabaseInterface;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace HotelManagement.Obstkorb.ViewModel;

public class HomeViewModel : BaseViewModel
{
    private readonly IHotelBuchungStore _bookingStore;
    private readonly User _user;

    public ObservableCollection<Hotelbuchung> RoomStatusList { get; set; }

    public HomeViewModel(IHotelBuchungStore bookingStore, User user)
    {
        _bookingStore = bookingStore;
        _user = user;

        // Initiale Daten laden
        LoadRoomStatuses();
    }

    public void LoadRoomStatuses()
    {
        var bookings = _bookingStore.GetAllBookings();
        var roomStatusList = bookings.Select(booking => new Hotelbuchung(_user.Username,booking.Preis,booking.Von,booking.Bis,booking.Gebucht, Convert.ToBoolean(booking.Gebucht)
            ? "Frei"
            : "Gebucht")
        ).ToList();

        RoomStatusList = new ObservableCollection<Hotelbuchung>(roomStatusList);
        OnPropertyChanged(nameof(RoomStatusList));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}