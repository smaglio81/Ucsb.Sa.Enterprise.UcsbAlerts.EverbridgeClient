using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class ContactRecordTypesHttpClientTests
	{

		ContactRecordTypesHttpClient _client = new ContactRecordTypesHttpClient();

		[TestMethod]
		public void GetContactRecordTypesTest()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetContactRecordTypesIdTest()
		{
			var result = _client.Get(ContactRecordType.Student);

			Assert.IsNotNull(result);
		}
		

	}
}
