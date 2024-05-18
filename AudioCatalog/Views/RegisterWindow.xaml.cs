using AudioCatalog.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AudioCatalog.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly RegisterViewModel _viewModel;
        public RegisterWindow(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            this.DataContext = registerViewModel;
            registerViewModel.CloseEvent += () => { this.Close(); };
            _viewModel = registerViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            _viewModel.Password = PasswordBox.Password;

        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmPassword = ConfirmPasswordBox.Password;
        }
    }
}
