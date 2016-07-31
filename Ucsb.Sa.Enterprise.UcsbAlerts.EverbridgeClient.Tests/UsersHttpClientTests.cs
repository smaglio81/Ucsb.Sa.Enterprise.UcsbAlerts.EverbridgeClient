using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class UsersHttpClientTests
	{

		UsersHttpClient _client = new UsersHttpClient();

		[TestMethod]
		public void GetUsersTest()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetUsersIdTest()
		{
			var result = _client.Get(1323816294836790);

			Assert.IsNotNull(result);
		}

	}
}
