using Exercise.Common.DTOs;

namespace Exercise.Domain.Interfaces
{
    public interface IUsersService
    {
        void Create(UserDTO user);
        void Update(int userId, UserDTO user);
        void Delete(int userId);
    }
}
