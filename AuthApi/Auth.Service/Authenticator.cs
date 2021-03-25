using Auth.Core.Dto;
using Auth.Core.Interfaces;
using Auth.Core.Model;
using Auth.Repository;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth.Service
{
    public class Authenticator : IUserInfoService
    {
        ApplicationDbContext _context;

        public Authenticator(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserInfo Authenticate(string username, string password)
        {
            var user = _context.Uzers.Where(t => t.email == username && t.password == password).SingleOrDefault();
            if (user == null) return null;
            return new UserInfo
            {
                UserInfoId = user.id,

            };
        }
    }
}
