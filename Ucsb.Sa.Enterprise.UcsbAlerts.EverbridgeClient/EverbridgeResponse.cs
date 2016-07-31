using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgeResponse<T> where T : EverbridgeBase
	{

		public string Message { get; set; }
		public T Result { get; set; }

	}
}
