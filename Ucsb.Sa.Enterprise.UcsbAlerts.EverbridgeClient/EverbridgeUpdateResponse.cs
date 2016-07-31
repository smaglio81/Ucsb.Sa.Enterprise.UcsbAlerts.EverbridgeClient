using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgeUpdateResponse
	{

		public string Message { get; set; }
		public long Id { get; set; }
		public string BaseUri { get; set; }
		public string InstanceUri { get; set; }

	}
}
