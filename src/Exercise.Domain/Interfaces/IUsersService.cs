using Exercise.Data.Models;

namespace Exercise.Domain.Interfaces
{
    public interface IUsersService
    {
        Task<bool> Create(UserDTO user);
        Task<bool> Update(int userId, UserDTO user);
        Task<bool> Delete(int userId);
    }
}
