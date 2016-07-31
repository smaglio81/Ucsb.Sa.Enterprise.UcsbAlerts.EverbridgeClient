using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ucsb.Sa.Enterprise.ClientExtensions;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
    public class UsersHttpClient : EverbridgeHttpClient<User, UserResponse, UserPagedResponse>
    {
	    public UsersHttpClient() : base("users") {}
    }
}
