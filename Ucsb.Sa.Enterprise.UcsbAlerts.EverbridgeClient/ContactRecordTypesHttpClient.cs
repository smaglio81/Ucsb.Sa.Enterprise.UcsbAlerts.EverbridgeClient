using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class ContactRecordTypesHttpClient : EverbridgeHttpClient<ContactRecordType, ContactRecordTypeResponse, ContactRecordTypePagedResponse>
	{
		public ContactRecordTypesHttpClient() : base("")
		{
			Name = string.Format("recordTypes/{0}", Organization.OrganizationId);
		}

	}
}
