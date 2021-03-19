using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.Core.Model
{
	public class Uzer
	{
		[Key]
		public string id { get; set; }
		public string USER_TYPE { get; set; }
		public Int64 version { get; set; }
		public bool archived { get; set; }
		public DateTime createdAt { get; set; }
		public string email { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string name { get; set; }
		public string password { get; set; }
		public string user_role { get; set; }
		public string ssoID { get; set; }
		public int status { get; set; }
		public string userName { get; set; }
		public string basicProfile_id { get; set; }
		public string branch_id { get; set; }
		public string company_id { get; set; }
		public string department_id { get; set; }


	}
}
