using Auth.Core.Dto;
using Auth.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Service
{
    public class Authenticator : IAuthenticate
    {

        public UserInfo Authenticate(string Email, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
