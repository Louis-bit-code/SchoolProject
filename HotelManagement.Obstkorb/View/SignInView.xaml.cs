using HotelManagement.Obstkorb.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Obstkorb.View
{
    public partial class SignInView : UserControl
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignInViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}