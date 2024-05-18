using System.Security.Cryptography;
using System.Text;

namespace AudioCatalog.Services
{
    public class PasswordHasher
    {
        public string HasPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hasbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var builder = new StringBuilder();

                foreach (byte b in hasbytes)
                {
                    builder.Append(b.ToString("X2"));
                }

                return builder.ToString();
            }
        }
    }
}
