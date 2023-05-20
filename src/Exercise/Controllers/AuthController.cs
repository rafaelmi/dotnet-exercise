using Exercise.Domain.Interfaces;
using Exercise.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService) 
        {
            _usersService = usersService;
        }

        // GET: api/Login
        [HttpGet("Login")]
        public IEnumerable<string> Login()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Logout
        [HttpGet("Logout")]
        public IEnumerable<string> Logout()
        {
            return new string[] { "value3", "value4" };
        }

        // GET: api/Login
        [HttpGet("Register")]
        public IEnumerable<string> Register(User user)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
