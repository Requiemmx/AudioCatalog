using AudioCatalog.Commands;
using AudioCatalog.Infrastructure;
using AudioCatalog.Services;
using AudioCatalog.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public Action ClouseAction { get; set; }
        private readonly PasswordHasher _passwordHasher;
        public LoginViewModel(AuthentificationService authentificationService, PasswordHasher passwordHasher)
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
            RegisterCommand = new RelayCommand(Register, CanRegister);
            _authentificationService = authentificationService;
            _passwordHasher = passwordHasher;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private void Login()
        {
            var res = _authentificationService.AuthentificatedUser(username, _passwordHasher.HasPassword(password));
            if (res == true)
            {
                AppServiceProvider.ServiceProvider.GetService<MusicCatalogWindow>().Show();
                ClouseAction();
            }
            else MessageBox.Show("User not Found", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool CanRegister()
        {
            return true;
        }

        private void Register()
        {
            ((RegisterWindow)AppServiceProvider.ServiceProvider.GetService<RegisterWindow>()).Show();
            ClouseAction();
        }

        private readonly AuthentificationService _authentificationService;



        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private string username;
        private string password;

        public string Username { get { return username; } set { username = value; onPropertyChanged(); } }

        public string Password { get { return password; } set { password = value; onPropertyChanged(); } }


    }
}
