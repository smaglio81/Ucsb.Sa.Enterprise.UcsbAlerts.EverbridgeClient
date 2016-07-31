using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class ContactPathsHttpClientTests
	{

		ContactPathsHttpClient _client = new ContactPathsHttpClient();

		[TestMethod]
		public void GetContactPathTest()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetContactPathIdTest()
		{
			var result = _client.Get(id: 2203425597033859);

			Assert.IsNotNull(result);
		}

	}
}
