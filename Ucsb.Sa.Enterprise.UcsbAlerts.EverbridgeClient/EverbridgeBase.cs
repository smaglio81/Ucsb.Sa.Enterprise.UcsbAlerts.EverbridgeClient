using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgeBase
	{

		public EverbridgeBase() {}

		public EverbridgeBase(EverbridgeBase copyFrom)
		{
			AccountId = copyFrom.AccountId;
			OrganizationId = copyFrom.OrganizationId;
			Id = copyFrom.Id;
			CreatedId = copyFrom.CreatedId;
			CreatedDate = copyFrom.CreatedDate;
			CreatedName = copyFrom.CreatedName;
			LastModifiedId = copyFrom.LastModifiedId;
			LastModifiedDate = copyFrom.LastModifiedDate;
			LastModifiedName = copyFrom.LastModifiedName;
		}

		public long AccountId { get; set; }
		public long OrganizationId { get; set; }
		public long Id { get; set; }
		public long CreatedId { get; set; }
		public string CreatedDate { get; set; }
		public string CreatedName { get; set; }
		public long LastModifiedId { get; set; }
		public string LastModifiedDate { get; set; }
		public string LastModifiedName { get; set; }

	}
}
