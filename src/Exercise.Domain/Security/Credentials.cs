using System.Text;
using System.Security.Cryptography;
using Exercise.Common.CustomExceptions;
using Exercise.Data.Repositories;
using Exercise.Common.DTOs;

namespace Exercise.Domain.Security
{
    public class Credentials
    {
        private readonly IUsersRepository _usersRepository;
        private readonly string _encodedCredentials;
        private string _username;
        private string _password;
        private UserDTO _user;
/*
        public Credentials(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
*/
        public Credentials(IUsersRepository usersRepository, string encodedCredentials)
        {
            _usersRepository = usersRepository;
            try
            {
                var (username, rawPassword) = DecodeCredentials(encodedCredentials);
                _username = username;
                _password = MaskPassword(rawPassword);
                _user = _usersRepository.GetByUsername(username);
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }
        }
/*
        public Credentials Create(string encodedCredentials)
        {
            return new Credentials(_usersRepository, encodedCredentials);
        }
*/
        public Credentials Validate()
        {
            if (_user == null) throw new UserNotFoundException();
            if (_user.Password != _password) throw new IncorrectPasswordException();
            return this;
        }

        public UserDTO GetUser() => _user;

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
