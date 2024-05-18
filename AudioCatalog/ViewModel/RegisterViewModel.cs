using AudioCatalog.Commands;
using AudioCatalog.Infrastructure;
using AudioCatalog.Services;
using AudioCatalog.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace AudioCatalog.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public Action CloseEvent { get; set; }

        private string username;
        private string password;
        private string confirmPassword;
        private string email;
        private string name;
        private string age;

        public string Username { get { return username; } set { username = value; onPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; onPropertyChanged(); } }
        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = value; onPropertyChanged(); } }
        public string Email { get { return email; } set { email = value; onPropertyChanged(); } }
        public string Name { get { return name; } set { name = value; onPropertyChanged(); } }
        public string Age { get { return age; } set { age = value; onPropertyChanged(); } }

        public ICommand RegisterCommand { get; }

        private readonly AuthentificationService _authentificationService;
        private readonly PasswordHasher _passwordHasher;
        public RegisterViewModel(AuthentificationService authentificationService, PasswordHasher passwordHasher)
        {
            _authentificationService = authentificationService;
            RegisterCommand = new RelayCommand(Register, CanRegister);
            _passwordHasher = passwordHasher;
        }


        private void Register()
        {
            int userAge = int.Parse(Age);
            var res = _authentificationService.RegisterUser(username, _passwordHasher.HasPassword(password), email, userAge, name);
            if (res == true)
            {
                AppServiceProvider.ServiceProvider.GetService<MusicCatalogWindow>().ShowDialog();
            }
            CloseEvent();
        }

        private bool CanRegister()
        {
            if (!String.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(password))
            {
                if (password == confirmPassword)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
