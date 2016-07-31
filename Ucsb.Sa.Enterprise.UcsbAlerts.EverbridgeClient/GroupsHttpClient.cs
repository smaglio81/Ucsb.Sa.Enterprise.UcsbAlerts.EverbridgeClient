using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class GroupsHttpClient : EverbridgeHttpClient<Group, GroupResponse, GroupPagedResponse>
	{

		public GroupsHttpClient() : base("")
		{
			Name = string.Format("groups/{0}", Organization.OrganizationId);
		}


	}
}
