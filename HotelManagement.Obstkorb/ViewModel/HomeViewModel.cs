using Hotelmanagement.Obstkorb.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Hotelmanagement.Obstkorb.DatabaseInterface;
using Hotelmanagement.Obstkorb.Model.Hotel;

namespace HotelManagement.Obstkorb.ViewModel;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly IHotelBuchungStore _bookingStore;
    private readonly UserContext _userContext;

    public ObservableCollection<HotelBuchungen> RoomStatusList { get; set; }

    public HomeViewModel(IHotelBuchungStore bookingStore, UserContext userContext)
    {
        _bookingStore = bookingStore;
        _userContext = userContext;

        // Initiale Daten laden
        LoadRoomStatuses();
    }

    public void LoadRoomStatuses()
    {
        var bookings = _bookingStore.GetAllBookings();
        var roomStatusList = bookings.Select(booking => new HotelBuchungen
        {
            Id = booking.Id,
            BookingStatus = booking.UserID == _userContext.UserId ? "Von Ihnen gebucht" : "Gebucht",
            IsBookedByUser = booking.UserID == _userContext.UserId
        }).ToList();

        RoomStatusList = new ObservableCollection<HotelBuchungen>(roomStatusList);
        OnPropertyChanged(nameof(RoomStatusList));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}