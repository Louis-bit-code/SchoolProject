namespace HotelManagement.Obstkorb.ViewModel;

using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.ComponentModel;
using System.Windows.Input;

public class LoginViewModel : BaseViewModel
{
    private object _currentView;
    private readonly IUserStore _userStore;

    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            SetProperty(ref _currentView, value);
        }
    }

    public ICommand ShowSignInViewCommand { get; }
    public ICommand ShowSignUpViewCommand { get; }

    public LoginViewModel(IUserStore userStore)
    {
        _userStore = userStore;

        // Standardmäßig die SignIn Ansicht anzeigen
        ShowSignInViewCommand = new RelayCommand<object>(o => CurrentView = new SignInViewModel(_userStore));
        ShowSignUpViewCommand = new RelayCommand<object>(o => CurrentView = new SignUpViewModel(_userStore));

        CurrentView = new SignInViewModel(_userStore);
    }
}
