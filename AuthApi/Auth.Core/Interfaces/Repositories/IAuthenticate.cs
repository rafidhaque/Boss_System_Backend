using Auth.Core.Dto;
using Auth.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Core.Interfaces.Repositories
{
    public interface IAuthenticate
    {
        UserInfo Authenticate(string Email, string Password);
    }
}
