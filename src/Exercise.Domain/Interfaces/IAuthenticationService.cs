using Exercise.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain.Services
{
    public interface IAuthenticationService
    {
        void Login(string base64Key);
        void Logout();
        void Register(UserDTO user);
    }
}
