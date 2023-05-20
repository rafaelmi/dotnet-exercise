using Exercise.Data.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Exercise.Common.CustomExceptions;
using Exercise.Common.DTOs;

namespace Exercise.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly GlobalDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public UsersRepository(GlobalDbContext context,
            IConfigurationProvider configurationProvider,
            IMapper mapper)
        {
            _context = context;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public UserDTO Get(int userId)
        {
            return _mapper.Map<UserDTO>(_context.Users.Find(userId));
        }

        public UserDTO GetByUsername(string username)
        {
            var user = _context.Users
                               .Where(u => u.Username == username)
                               .FirstOrDefault();
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _context.Users
                .ProjectTo<UserDTO>(_configurationProvider)
                .ToList();
        }

        public IEnumerable<UserDTO> GetMany(int size, int offset)
        {
            return _context.Users
                .Skip(offset)
                .Take(size)
                .ProjectTo<UserDTO>(_configurationProvider)
                .ToList();
        }

        public int Create(UserDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _context.Add(user);
            return _context.SaveChanges();
        }

        public int Update(int userId, UserDTO userDto)
        {
            var user = GetEntity(userId);
            user.Name = userDto.Name;
            user.Password = userDto.Password;
            return _context.SaveChanges();
        }

        public int Delete(int userId)
        {
            var user = GetEntity(userId);
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }

        private User GetEntity(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) throw new DbRecordNotFoundException();
            return user;
        }
    }
}
