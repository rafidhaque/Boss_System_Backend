using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class UserInfo
    {
        [Key]
        public Guid UserInfoId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Username { get; set; }
        public string Password{get;set;}
        [Compare("Password ")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
