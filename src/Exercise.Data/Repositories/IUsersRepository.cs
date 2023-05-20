using Exercise.Common.DTOs;

namespace Exercise.Data.Repositories
{
    public interface IUsersRepository
    {
        UserDTO Get(int userId);
        UserDTO GetByUsername(string username);
        IEnumerable<UserDTO> GetAll();
        IEnumerable<UserDTO> GetMany(int size, int offset);
        int Create(UserDTO user);
        int Update(int userId, UserDTO user);
        int Delete(int userId);
    }
}
