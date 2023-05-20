using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data.Repositories;
using Exercise.Domain.Interfaces;
using Exercise.Common.DTOs;

namespace Exercise.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        public void Create(UserDTO user)
        {
            _usersRepository.Create(user);
        }

        public void Update(int userId, UserDTO user)
        {
            _usersRepository.Update(userId, user);
        }
        public void Delete(int userId)
        {
            _usersRepository.Delete(userId);
        }
    }
}
