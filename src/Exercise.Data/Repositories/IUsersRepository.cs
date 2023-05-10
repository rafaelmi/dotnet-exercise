using Exercise.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data.Repositories
{
    public interface IUsersRepository
    {
        UserDTO Get(int userId);
        IEnumerable<UserDTO> GetAll();
        IEnumerable<UserDTO> GetMany(int size, int offset);
        int Create(UserDTO user);
        int Update(int userId, UserDTO user);
        int Delete(int userId);
    }
}
