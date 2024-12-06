using Hotelmanagement.Obstkorb.DatabaseInterface;
using System.Windows.Input;

namespace HotelManagement.Obstkorb.ViewModel
{
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

        // Parameterloser Konstruktor, der DefaultUserStore verwendet
        public LoginViewModel(IUserStore userStore)
        {
            _userStore = userStore;

            // Initialisierung der Commands
            ShowSignInViewCommand = new RelayCommand<object>(o => ShowSignInView());
            ShowSignUpViewCommand = new RelayCommand<object>(o => ShowSignUpView());

            // Standardmäßig die Sign-In-Ansicht anzeigen
            ShowSignInView();
        }

        private void ShowSignInView()
        {
            CurrentView = new SignInViewModel(_userStore);
        }

        private void ShowSignUpView()
        {
            CurrentView = new SignUpViewModel(_userStore);
        }
    }
}