using Auth.Core.Dto;
using Auth.Core.Interfaces;
using Authentication.Helper;
using Authentication.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class UserInfoService 
    {
        //private List<UserInfo> userInfos = new List<UserInfo> {
        //    new UserInfo{ UserInfoId=Guid.NewGuid(),FullName="First Last",Username="Test1",
        //    Password="1234"}
        //};
        private readonly AppSettings _appSettings;
        IUserInfoService _userService;
        public UserInfoService(IOptions<AppSettings> appsettings, IUserInfoService userService)
        {
            _appSettings = appsettings.Value;
            _userService = userService;
        }
         
        public UserInfo Authenticate(string username, string password)
        {
            //var user = userInfos.SingleOrDefault(x => x.Username == username && x.Password == password);
            var user = _userService.Authenticate(username, password);
            if (user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var ket = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserInfoId.ToString())
                }),
                Expires=DateTime.UtcNow.AddDays(7),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(ket),SecurityAlgorithms.HmacSha256Signature)
             };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
         
    }
}
