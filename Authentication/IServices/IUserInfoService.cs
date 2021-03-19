using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.IServices
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string username,string password);
    }
}
