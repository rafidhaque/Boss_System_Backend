
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Core.Dto;
namespace Auth.Core.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string username,string password);
    }
}
