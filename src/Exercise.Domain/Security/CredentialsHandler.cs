using System.Text;
using System.Security.Cryptography;
using Exercise.Common.CustomExceptions;
using Exercise.Data.Repositories;
using Exercise.Common.DTOs;

namespace Exercise.Domain.Security
{
    public class CredentialsHandler : ICredentialsHandler
    {
        private readonly IUsersRepository _usersRepository;

        public CredentialsHandler(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        public UserDTO ValidateCredentials(string encodedKey)
        {
            try
            {
                var (username, rawPassword) = DecodeCredentials(encodedKey);
                var password = MaskPassword(rawPassword);
                var user = _usersRepository.GetByUsername(username);
                if (user == null) throw new UserNotFoundException();
                if (user.Password != password) throw new IncorrectPasswordException();
                return user;
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }
        }

        private (string, string) DecodeCredentials(string encodedKey)
        {
            string[] decoded = Base64Decode(encodedKey)
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (decoded.Length != 2) throw new FormatException();
            return (decoded[0], decoded[1]);
        }

        private string Base64Decode(string base64Key)
        {
            byte[] stream = Convert.FromBase64String(base64Key);
            return Encoding.UTF8.GetString(stream);
        }

        private string MaskPassword(string password)
        {
            string res = string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (byte b in hash)
                {
                    res += (char)b;
                }
            }

            return res;
        }
    }
}
