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
        var roomStatusList = bookings.Select(booking => new Hotelbuchung
        {
            Id = booking.Id,
            UserBuchung = Convert.ToBoolean(booking.UserBuchung) ? "Von Ihnen gebucht" : "Gebucht",
            Gebucht = booking.Gebucht
        }).ToList();

        RoomStatusList = new ObservableCollection<Hotelbuchung>(roomStatusList);
        OnPropertyChanged(nameof(RoomStatusList));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}