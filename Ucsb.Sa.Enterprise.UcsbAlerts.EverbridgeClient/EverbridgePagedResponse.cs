using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgePagedResponse<T> where T : class
	{

		public string Message { get; set; }
		public string FirstPageUri { get; set; }
		public string NextPageUri { get; set; }
		public string LastPageUri { get; set; }
		public EverbridgePage<T> Page { get; set; }

	}

	public class EverbridgePage<T> where T : class
	{
		public int PageSize { get; set; }
		public int Start { get; set; }
		public List<T> Data { get; set; }
		public int TotalCount { get; set; }
		public int CurrentPageNo { get; set; }
		public int TotalPageCount { get; set; }
	}
}
