using Exercise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data.Repositories
{
    internal interface IUsersRepository
    {
        Task<UserDTO> Get(int userId);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<IEnumerable<UserDTO>> GetMany(int size, int offset);
        Task<int> Create(UserDTO user);
        Task<int> Update(int userId, UserDTO user);
        Task<int> Delete(int userId);
    }
}
