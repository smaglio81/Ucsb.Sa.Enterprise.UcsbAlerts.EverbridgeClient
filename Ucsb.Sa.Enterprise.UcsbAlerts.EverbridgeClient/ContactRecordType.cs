using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{

	public class ContactRecordTypePagedResponse : EverbridgePagedResponse<ContactRecordType> { }

	public class ContactRecordTypeResponse : EverbridgeResponse<ContactRecordType> { }

	public class ContactRecordType : EverbridgeBase
	{
		private const long _Student = 2643230248142444;
		private const long _Employee = 453003085614510;

		private const long _StudentTest = 3083034899255799;
		private const long _EmployeeTest = 453003085614663;

		public static long Student
		{
			get
			{
				if (EverbridgeHttpClientManager.IsProd) { return _Student; }
				return _StudentTest;
			}
		}

		public static long Employee
		{
			get
			{
				if (EverbridgeHttpClientManager.IsProd) { return _Employee; }
				return _EmployeeTest;
			}
		}

		public string FillColor { get; set; }
		public string Status { get; set; }
		public long ResourceBundleId { get; set; }
		public int CachedContactCount { get; set; }
		public string Name { get; set; }
		public string RecordType { get; set; }
	}
}
