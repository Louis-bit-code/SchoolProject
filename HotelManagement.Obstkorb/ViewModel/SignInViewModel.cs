using Hotelmanagement.Obstkorb.DatabaseInterface;
using HotelManagement.Obstkorb.View;
using System.Windows.Input;
using System.Windows;

namespace HotelManagement.Obstkorb.ViewModel;

public class SignInViewModel : BaseViewModel
{
    private readonly IUserStore _userStore;

    public string Username { get; set; }
    public string Password { get; set; }

    public ICommand SignInCommand { get; }

    public SignInViewModel(IUserStore userStore)
    {
        _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
        SignInCommand = new RelayCommand<object>(ExecuteSignIn);
    }

    private void ExecuteSignIn(object parameter)
    {
        if (_userStore.AuthenticateUser(Username, Password))
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // LoginWindow schließen
            Application.Current.Windows[0].Close();
        }
        else
        {
            MessageBox.Show("Benutzername oder Passwort ist falsch.", "Anmeldung fehlgeschlagen", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}