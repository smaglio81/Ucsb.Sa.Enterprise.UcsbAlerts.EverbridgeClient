using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class Upload : EverbridgeBase
	{
		public List<UploadError> UploadErrors { get; set; }
		public List<UploadHeader> Headers { get; set; }
		public string GeoSuccessNum { get; set; }
		public string FileSize { get; set; }
		public string UploadMethod { get; set; }
		public string GeoFailNum { get; set; }
		public string Status { get; set; }
		public string WithErrorNum { get; set; }
		public string UploadStatus { get; set; }
		public string ResourceBundleId { get; set; }
		public string CriticalNum { get; set; }
		public string Source { get; set; }
		public string SuccessNum { get; set; }
		public string FileName { get; set; }

	}

	public class UploadError
	{
		public List<string> FieldNames { get; set; }
		public string ErrorCode { get; set; }
		public string CriticalError { get; set; }
	}

	public class UploadHeader
	{
		public string CsvColumnName { get; set; }
		public string Useful { get; set; }
	}
}
