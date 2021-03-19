using Authentication.Helper;
using Authentication.IServices;
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
    public class UserInfoService : IUserInfoService
    {
        private List<UserInfo> userInfos = new List<UserInfo> {
            new UserInfo{ UserInfoId=Guid.NewGuid(),FullName="First Last",Username="Test1",
            Password="1234"}
        };
        private readonly AppSettings _appSettings;
        public UserInfoService(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;
        }
         
        public UserInfo Authenticate(string username, string password)
        {
            var user = userInfos.SingleOrDefault(x => x.Username == username && x.Password == password);
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
        public IEnumerable<UserInfo> GetAll()
        {
            return userInfos;
        }
    }
}
