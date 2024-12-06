namespace HotelManagement.Obstkorb.ViewModel;

using System.ComponentModel;
using System.Windows.Input;

public class LoginViewModel : BaseViewModel
{
    private object _currentView;

    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    public ICommand ShowSignInViewCommand { get; }
    public ICommand ShowSignUpViewCommand { get; }

    public LoginViewModel()
    {
        // Standardmäßig die SignIn Ansicht anzeigen
        ShowSignInViewCommand = new RelayCommand<>(o => CurrentView = new SignInViewModel());
        ShowSignUpViewCommand = new RelayCommand<>(o => CurrentView = new SignUpViewModel());

        CurrentView = new SignInViewModel();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}