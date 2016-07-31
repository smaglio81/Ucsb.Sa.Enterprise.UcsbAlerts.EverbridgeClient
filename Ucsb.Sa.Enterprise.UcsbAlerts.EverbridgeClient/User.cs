using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class UserPagedResponse : EverbridgePagedResponse<User> { }

	public class UserResponse : EverbridgeResponse<User> { }

	public class User : EverbridgeBase
	{
		public User()
		{
			RoleIds = new List<long>();
			Roles = new List<UserRole>();
		}

		public string Owner { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string SsoUserId { get; set; }
		public string Suffix { get; set; }
		public string Email { get; set; }
		public string LastModifiedProxyName { get; set; }
		public long LastLoginDate { get; set; }
		public List<long> RoleIds { get; set; }
		public List<UserRole> Roles { get; set; }
		public long DefaultRoleId { get; set; }
		public string UserStatus { get; set; }
	}

	public class UserRole
	{
		public long Id { get; set; }
		public string RoleTemplate { get; set; }
		public string Name { get; set; }
	}
}
