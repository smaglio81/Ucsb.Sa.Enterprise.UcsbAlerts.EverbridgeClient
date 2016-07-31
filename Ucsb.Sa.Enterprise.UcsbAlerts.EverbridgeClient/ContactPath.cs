using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{

	public class ContactPathPagedResponse : EverbridgePagedResponse<ContactPath> { }

	public class ContactPathResponse : EverbridgeResponse<ContactPath> { }

	public class ContactPath : EverbridgeBase
	{

		//	they have a couple of values that are hard-coded, you have to create a custom value to get a dynamic number
		public const long AlertEmail = 241901148045316;

		public long PathId { get; set; }
		public long AwarePathId { get; set; }
		public bool Expose { get; set; }
		public bool IsDefault { get; set; }
		public string Status { get; set; }
		public bool Mandatory { get; set; }
		public long ResourceBundleId { get; set; }
		public bool Editable { get; set; }
		public int Seq { get; set; }
		public string Prompt { get; set; }
		public string SysPrompt { get; set; }
		public string Code { get; set; }
		public string Type { get; set; }
		public int PathFlag { get; set; }
		public string MessageCode { get; set; }
		public string ConfirmType { get; set; }
		public string FormatFlag { get; set; }
		public string PathDeliveryType { get; set; }
		public bool ExtRequired { get; set; }
		public bool DisplayFlag { get; set; }
		public string PathType { get; set; }
		public bool Default { get; set; }
		public string ExtFlag { get; set; }
		public string ExtPrompt { get; set; }
		public string ExtValue { get; set; }
	}

}
