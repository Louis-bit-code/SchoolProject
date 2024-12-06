using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows;

namespace HotelManagement.Obstkorb.ViewModel;

public class SignUpViewModel : BaseViewModel
{
    private readonly IUserStore _userStore;

    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public bool IsMinLengthMet { get; set; }
    public bool IsNumberMet { get; set; }
    public bool IsSpecialCharacterMet { get; set; }

    public ICommand SignUpCommand { get; }

    public SignUpViewModel(IUserStore userStore)
    {
        _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
        SignUpCommand = new RelayCommand<object>(ExecuteSignUp, CanExecuteSignUp);
    }

    private bool CanExecuteSignUp(object parameter)
    {
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
}
