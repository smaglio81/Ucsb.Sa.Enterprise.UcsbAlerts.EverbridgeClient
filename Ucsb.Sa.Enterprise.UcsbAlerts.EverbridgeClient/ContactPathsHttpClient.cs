using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class ContactPathsHttpClient : EverbridgeHttpClient<ContactPath, ContactPathResponse, ContactPathPagedResponse>
	{

		public ContactPathsHttpClient() : base("")
		{
			Name = string.Format("contactPaths/{0}", Organization.OrganizationId);
		}

	}
}
