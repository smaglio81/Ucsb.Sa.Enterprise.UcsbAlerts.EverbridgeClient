using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class GroupsHttpClientTests
	{

		GroupsHttpClient _client = new GroupsHttpClient();

		[TestMethod]
		public void Get()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetId()
		{
			var result = _client.Get(2203442776901150);

			Assert.IsNotNull(result);
		}

	}
}
