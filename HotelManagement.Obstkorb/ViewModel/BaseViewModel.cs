namespace HotelManagement.Obstkorb.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // Event für die Benachrichtigung der UI bei Datenänderungen
        public event PropertyChangedEventHandler PropertyChanged;

        // Methode, die aufgerufen wird, um die UI zu benachrichtigen, wenn sich eine Property ändert
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Set-Methode, die Property-Änderungen behandelt und automatisch OnPropertyChanged aufruft
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}