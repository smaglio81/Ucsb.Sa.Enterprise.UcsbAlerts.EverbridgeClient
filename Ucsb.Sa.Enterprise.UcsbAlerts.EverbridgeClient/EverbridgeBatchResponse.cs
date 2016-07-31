using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgeBatchResponse
	{

		public string Message { get; set; }
		public string Code { get; set; }
		public List<string> ErrorInfo { get; set; }

	}
}
