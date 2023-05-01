using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Exercise.Models;
using Exercise.Data.Repositories;
using Exercise.Data.Models;
using Exercise.Domain.Interfaces;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersService _usersServices;

        public UsersController(IUsersRepository usersRepository,
                                 IUsersService usersServices)
        {
            _usersRepository = usersRepository;
            _usersServices = usersServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return MapResponse(await _usersRepository.GetAll());
        }

        // GET api/<UsersController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public async Task<IEnumerable<User>> Get(int size, int offset)
        {
            return MapResponse(await _usersRepository.GetMany(size, offset));
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public async Task<User> Get(int userId)
        {
            return ParseDTO(await _usersRepository.Get(userId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await _usersServices.Create(ToDTO(user));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{userId}")]
        public async Task Put(int userId, [FromBody] User user)
        {
            await _usersServices.Update(userId, ToDTO(user));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public async Task Delete(int userId)
        {
            await _usersServices.Delete(userId);
        }

        private IEnumerable<User> MapResponse(IEnumerable<UserDTO> dtos)
        {
            List<User> users = new List<User>();
            foreach (var dto in dtos)
            {
                users.Add(ParseDTO(dto));
            }
            return users;
        }

        private User ParseDTO(UserDTO userDto) => new User
        {
            UserId = userDto.UserId,
            Password = userDto.Password,
            Name = userDto.Name
        };

        private UserDTO ToDTO(User user) => new UserDTO
        {
            UserId = user.UserId,
            Password = user.Password,
            Name = user.Name
        };

    }
}
