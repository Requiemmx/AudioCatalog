using AudioCatalog.Models;

namespace AudioCatalog.Infrastructure
{
    public class UserSingleton
    {
        private static UserSingleton UserSingletonInstance;
        public static UserSingleton Instance
        {
            get
            {
                if (UserSingletonInstance == null)
                {
                    UserSingletonInstance = new UserSingleton();
                }
                return UserSingletonInstance;
            }

        }


        private UserSingleton() { }
        public User LogingUser { get; set; }
    }
}
