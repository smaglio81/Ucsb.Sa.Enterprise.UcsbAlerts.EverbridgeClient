using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class OrganizationsHttpClient : EverbridgeHttpClient<Organization, OrganizationResponse, OrganizationPagedResponse>
	{

		public OrganizationsHttpClient() : base("organizations") {}

	}
}
