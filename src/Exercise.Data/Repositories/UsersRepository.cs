using Exercise.Data.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;

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
            return _mapper.Map<UserDTO>(GetAsEntity(userId));
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
            var user = GetAsEntity(userId);
            user.Name = userDto.Name;
            user.Password = userDto.Password;
            return _context.SaveChanges();
        }

        public int Delete(int userId)
        {
            var user = GetAsEntity(userId);
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }

        private User GetAsEntity(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) throw new KeyNotFoundException();
            return user;
        }
    }
}
