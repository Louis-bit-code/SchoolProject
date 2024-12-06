using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private readonly IUserStore _userStore;

        private string _username;
        private string _password;
        private string _confirmPassword;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
                UpdateCanExecute();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ValidatePasswordRules();
                OnPropertyChanged();
                UpdateCanExecute();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
                UpdateCanExecute();
            }
        }

        public bool IsMinLengthMet { get; private set; }
        public bool IsNumberMet { get; private set; }
        public bool IsSpecialCharacterMet { get; private set; }

        public ICommand SignUpCommand { get; }

        public SignUpViewModel(IUserStore userStore)
        {
            _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
            SignUpCommand = new RelayCommand<object>(ExecuteSignUp, CanExecuteSignUp);
        }

        private bool CanExecuteSignUp(object parameter)
        {
            // Überprüfen, ob die Passwortregeln erfüllt sind und beide Passwörter gleich sind
            return IsMinLengthMet && IsNumberMet && IsSpecialCharacterMet && Password == ConfirmPassword;
        }

        private void ExecuteSignUp(object parameter)
        {
            if (_userStore.RegisterUser(Username, Password))
            {
                MessageBox.Show("Registrierung erfolgreich. Sie können sich nun anmelden.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Registrierung fehlgeschlagen. Benutzername möglicherweise bereits vergeben.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ValidatePasswordRules()
        {
            IsMinLengthMet = !string.IsNullOrEmpty(Password) && Password.Length >= 8;
            IsNumberMet = !string.IsNullOrEmpty(Password) && Password.Any(char.IsDigit);
            IsSpecialCharacterMet = !string.IsNullOrEmpty(Password) && Password.Any(ch => !char.IsLetterOrDigit(ch));
            OnPropertyChanged(nameof(IsMinLengthMet));
            OnPropertyChanged(nameof(IsNumberMet));
            OnPropertyChanged(nameof(IsSpecialCharacterMet));
        }

        private void UpdateCanExecute()
        {
            // Benachrichtige die UI, dass sich der Zustand von CanExecute geändert hat
            (SignUpCommand as RelayCommand<object>)?.RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
