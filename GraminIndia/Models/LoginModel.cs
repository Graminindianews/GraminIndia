using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
	public class LoginModel
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public string LoginName { get; set; }
		public string UserName { get; set; }
		public string Passwword { get; set; }

	}
}