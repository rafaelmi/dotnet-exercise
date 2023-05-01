using Microsoft.Extensions.Configuration;
using System.Data;
using Exercise.Data.Models;

namespace Exercise.Data.Repositories
{
    public class UsersRepository : Repository, IUsersRepository
    {
        private readonly TableProperties _tableProperties;

        public UsersRepository(IConfiguration configuration) : base (configuration)
        {
            _tableProperties = new TableProperties 
            {
                Name = "Users",
                IdColumnName = "user_id",
            };
        }

        public async Task<UserDTO> Get(int userId)
        {
            DataRow dataRow = await Get(_tableProperties, userId);
            return CreateDTO(dataRow);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            DataSet dataSet = await GetAll(_tableProperties);
            return CreateDTOList(dataSet);
        }

        public async Task<IEnumerable<UserDTO>> GetMany (int size, int offset)
        {
            DataSet dataSet = await GetMany(_tableProperties, size, offset);
            return CreateDTOList(dataSet);
        }

        public async Task<int> Create (UserDTO user)
        {
            string query = "INSERT INTO Users (user_id, password, name) " +
                           $"VALUES ('{user.UserId}', '{user.Password}', '{user.Name}')";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Update (int userId, UserDTO user)
        {
            string query = "UPDATE Users SET " +
                                $"password = '{user.Password}', " +
                                $"name = '{user.Name}' " +
                                $"WHERE user_id = {userId}";
            return await ExecuteNonQuery(query);
        }

        public async Task<int> Delete (int userId)
        {
            string query = $"DELETE FROM Users WHERE user_id = {userId}";
            return await ExecuteNonQuery(query);
        }

        private IEnumerable<UserDTO> CreateDTOList (DataSet dataSet)
        {
            List<UserDTO> collection = new List<UserDTO>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                collection.Add(CreateDTO(row));
            }

            return collection;
        }

        private UserDTO CreateDTO(DataRow row)
        {
            if (row != null) return new UserDTO
            {
                UserId = (int)row["user_id"],
                Password = (string)row["password"],
                Name = (string)row["name"]
            };
            else return null;
        }
    }
}
