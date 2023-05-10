using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Exercise.Models;
using Exercise.Data.Repositories;
using Exercise.Domain.Interfaces;
using Exercise.Data.DTOs;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersService _usersServices;

        public UsersController(IMapper mapper,
            IUsersRepository usersRepository,
            IUsersService usersServices)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _usersServices = usersServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _mapper.Map<IEnumerable<User>>(_usersRepository.GetAll());
        }

        // GET api/<UsersController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public IEnumerable<User> Get(int size, int offset)
        {
            return _mapper.Map<IEnumerable<User>>(_usersRepository.GetMany(size, offset));
        }

        // GET api/<UsersController>/5
        [HttpGet("{userId}")]
        public User Get(int userId)
        {
            return _mapper.Map<User>(_usersRepository.Get(userId));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _usersServices.Create(_mapper.Map<UserDTO>(user));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{userId}")]
        public void Put(int userId, [FromBody] User user)
        {
            _usersServices.Update(userId, _mapper.Map<UserDTO>(user));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public void Delete(int userId)
        {
            _usersServices.Delete(userId);
        }
    }
}
