using System.Windows;
using System.Windows.Input;
using Hotelmanagement.Obstkorb.DatabaseInterface;

namespace HotelManagement.Obstkorb.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserStore _userStore;

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand ShowSignUpViewCommand { get; }

        public LoginViewModel(IUserStore userStore, SignUpViewModel signUpViewModel)
        {
            _userStore = userStore;

            LoginCommand = new RelayCommand<object>(_ => PerformLogin());
            ShowSignUpViewCommand = new RelayCommand<object>(_ => ShowSignUp(signUpViewModel));
        }

        private void PerformLogin()
        {
            // Beispiel: Authentifizierung basierend auf Benutzername und Passwort
            var user = _userStore.GetUserByUsername(Username);
            if (user != null && user.Pa
            ssword  == Password) // Achtung: Passwort-Hashing verwenden!
            {
                MessageBox.Show("Login erfolgreich!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                // Hier könnte die Navigation zur HomeView ausgelöst werden
                Application.Current.MainWindow.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Ungültiger Benutzername oder Passwort.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowSignUp(SignUpViewModel signUpViewModel)
        {
            CurrentView = signUpViewModel;
        }
    }
}