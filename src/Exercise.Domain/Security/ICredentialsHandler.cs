using Exercise.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain.Security
{
    public interface ICredentialsHandler
    {
        UserDTO ValidateCredentials(string encodedKey);
    }
}
