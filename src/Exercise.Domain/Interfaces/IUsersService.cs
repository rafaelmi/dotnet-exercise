using Exercise.Data.Models;

namespace Exercise.Domain.Interfaces
{
    public interface IUsersService
    {
        bool Create(UserDTO user);
        bool Update(int userId, UserDTO user);
        bool Delete(int userId);
    }
}
