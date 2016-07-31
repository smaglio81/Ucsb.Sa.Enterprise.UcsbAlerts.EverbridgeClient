using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient.Tests
{
	[TestClass]
	public class ContactsHttpClientTests
	{

		ContactsHttpClient _client = new ContactsHttpClient();

		[TestMethod]
		public void GetContactTest()
		{
			var result = _client.Get();

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetContactIdTest()
		{
			var result = _client.Get(3083052079123481);

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void AddAndDeleteContactTest()
		{
			var newId = _client.AddStudent("FirstTest", "LastTest", "FirstTest.LastTest@umail.ucsb.edu", "Made-Up-Guid");
			Assert.IsNotNull(newId);
		
			var deleteResult = _client.Delete(newId);
			Assert.IsNotNull(deleteResult);
		}

		[TestMethod]
		public void AddDougShajanAccountsTest()
		{
			//var newId = _client.AddStudent("Doug", "Drury", "doug.drury@ucsb.edu", "d19e6043-bcb9-11d4-b5dc-00609797e96f");
			//Assert.IsNotNull(newId);
			//newId = _client.AddStudent("Shajan", "Kay", "shajan.kay@ucsb.edu", "1b266538-6de8-11dd-820a-0003472a8354");
			//Assert.IsNotNull(newId);
			//newId = _client.AddStudent("Vasilios", "Inembolidis", "vasilios@ucsb.edu", "f0560dc6-9467-11dd-8d54-005056b52102");
			//Assert.IsNotNull(newId);
			//newId = _client.AddStudent("Yaheya", "Quazi", "yaheya@ucsb.edu", "0289D100-9DD3-11E4-A8B8-B53B16AA077A");
			//Assert.IsNotNull(newId);
		}

	}
}
