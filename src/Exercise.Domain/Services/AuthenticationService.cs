using Exercise.Common.DTOs;
using Exercise.Domain.Interfaces;
using System;
using System.Text.Encodings;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Domain.Security;
using Exercise.Data.Repositories;

namespace Exercise.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsersService _usersService;
        private readonly IUsersRepository _usersRepository;
//        private readonly ICredentials _credentials;

        public AuthenticationService(IUsersService usersService,
                                     IUsersRepository usersRepository)
//                                     ICredentials credentials)
        {
            _usersService = usersService;
            _usersRepository = usersRepository;
//            _credentials = credentials;
        }

        public void Register(UserDTO user)
        {
            _usersService.Create(user);
        }

        public void Login(string encodedKey)
        {
            var user = new Credentials(_usersRepository, encodedKey)
                            .Validate()
                            .GetUser();
        }

        public void Logout()
        {

        }
    }
}
