using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{

	public class GroupPagedResponse : EverbridgePagedResponse<Group> {}

	public class GroupResponse : EverbridgeResponse<Group> {}

	public class Group : EverbridgeBase
	{
		public long ResourceBundleId { get; set; }
		public long ParentId { get; set; }
		public string Name { get; set; }
		public long CreatedId { get; set; }
		public long LastSynchronizedTime { get; set; }
		public bool Dirty { get; set; }
	}

}
