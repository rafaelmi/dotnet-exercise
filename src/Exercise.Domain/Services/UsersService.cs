using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data.Repositories;
using Exercise.Data.Models;
using Exercise.Domain.Interfaces;

namespace Exercise.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        public bool Create(UserDTO user)
        {
            int count = _usersRepository.Create(user);
            return count == 1;
        }

        public bool Update(int userId, UserDTO user)
        {
            int count = _usersRepository.Update(userId, user);
            return count == 1;
        }
        public bool Delete(int userId)
        {
            int count = _usersRepository.Delete(userId);
            return count == 1;
        }
    }
}
