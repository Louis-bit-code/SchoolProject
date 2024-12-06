using HotelManagement.Obstkorb.ViewModel;
using System.Windows;

namespace HotelManagement.Obstkorb.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            DataContext = loginViewModel; // Den DataContext mit dem ViewModel setzen
        }
    }
}