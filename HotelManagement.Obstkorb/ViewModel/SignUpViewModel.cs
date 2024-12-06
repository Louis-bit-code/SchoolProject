using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows;

namespace HotelManagement.Obstkorb.ViewModel;

public class SignUpViewModel : INotifyPropertyChanged
{
    private readonly IUserStore _userStore;

    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    // Regeln zur Validierung
    public bool IsMinLengthMet { get; set; }
    public bool IsNumberMet { get; set; }
    public bool IsSpecialCharacterMet { get; set; }

    public ICommand SignUpCommand { get; }

    public SignUpViewModel(IUserStore userStore)
    {
        _userStore = userStore;
        SignUpCommand = new RelayCommand(ExecuteSignUp, CanExecuteSignUp);
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

    private void ValidatePasswordRules()
    {
        IsMinLengthMet = Password.Length >= 8;
        IsNumberMet = Regex.IsMatch(Password, @"\d");
        IsSpecialCharacterMet = Regex.IsMatch(Password, @"[!@#$%^&*(),.?\":{ }|<>]");
        OnPropertyChanged(nameof(IsMinLengthMet));
        OnPropertyChanged(nameof(IsNumberMet));
        OnPropertyChanged(nameof(IsSpecialCharacterMet));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
