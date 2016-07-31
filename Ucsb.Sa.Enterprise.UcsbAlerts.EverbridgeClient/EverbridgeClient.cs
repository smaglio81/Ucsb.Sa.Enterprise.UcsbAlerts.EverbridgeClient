using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class EverbridgeClient : IDisposable
	{


		public ContactsHttpClient Contacts { get; set; }
		//public UsersHttpClient Users { get; set; }

		public EverbridgeClient()
		{
			Contacts = new ContactsHttpClient();
			//Users = new UsersHttpClient();
		}

		public void Dispose()
		{
			if(Contacts != null) { Contacts.Dispose(); Contacts = null; }
			//if(Users != null) { Users.Dispose(); Users = null; }
		}
	}
}
