using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class OrganizationsHttpClientTests
	{

		OrganizationsHttpClient _client = new OrganizationsHttpClient();

		[TestMethod]
		public void GetOrganizationsTest()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetOrganizationsIdTest()
		{
			var result = _client.Get(453003085614511);

			Assert.IsNotNull(result);
		}

	}
}
