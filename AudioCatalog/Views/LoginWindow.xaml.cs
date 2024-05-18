using AudioCatalog.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;
        public LoginWindow(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.DataContext = loginViewModel;
            _viewModel = loginViewModel;
            _viewModel.ClouseAction = () => { this.Close(); };
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = (sender as PasswordBox).Password;
        }
    }
}
