using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Core.Dto
{
   public class UserInfo
    {
        public string UserInfoId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Username { get; set; }    
        public string Token { get; set; }
    }
}
