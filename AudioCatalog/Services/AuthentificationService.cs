using AudioCatalog.Infrastructure;
using AudioCatalog.Models;
using AudioCatalog.Repository;

namespace AudioCatalog.Services
{
    public class AuthentificationService
    {
        private readonly UserRepository _userRepository;

        public AuthentificationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public bool RegisterUser(string username, string password, string email, int age = 0, string name = "")
        {
            var IsExistsUser = _userRepository.GetUserByName(username);
            if (IsExistsUser != null)
            {
                return false;
            }

            var user = new User() { Username = username, Password = password, Age = age, Name = name, Email = email };

            _userRepository.Add(user);
            UserSingleton.Instance.LogingUser = user;

            return true;
        }

        public bool AuthentificatedUser(string username, string password)
        {
            var user = _userRepository.GetUserByName(username);
            if (user != null && user.Password == password)
            {
                UserSingleton.Instance.LogingUser = user;
                return true;
            }

            return false;
        }
    }
}
