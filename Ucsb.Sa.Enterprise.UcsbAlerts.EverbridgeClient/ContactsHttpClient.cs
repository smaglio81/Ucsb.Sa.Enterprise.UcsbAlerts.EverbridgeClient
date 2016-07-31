using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class ContactsHttpClient : EverbridgeHttpClient<Contact, ContactResponse, ContactPagedResponse>
	{

		public ContactsHttpClient() : base("")
		{
			Name = string.Format("contacts/{0}", Organization.OrganizationId);
		}

		public Contact Get(string email)
		{
			var url = string.Format("{0}?idType=externalId", email);
			var contact = Get<Contact>(url: url);
			return contact;
		}

		public long GetContactId(string email)
		{
			var contact = Get(email);
			if (contact == null) { return Contact.NoContact; }
			return contact.Id;
		}

		public bool IsValidContactId(long id)
		{
			return id > Contact.UndefinedContact;
		}

		public long AddStudent(string firstName, string lastName, string email, string ucsbCampusId)
		{
			var contact = new ContactPost()
			{
				RecordTypeId = ContactRecordType.Student, // student
				FirstName = firstName,
				LastName = lastName,
				Country = "US",
				ExternalId = ucsbCampusId,
				RegisteredEmail = email,
				Paths = new List<ContactPathInfoPost>()
				{
					new ContactPathInfoPost()
					{
						WaitTime = 0,
						PathId = ContactPath.AlertEmail,
						Value = email
					}
				}
			};

			var result = Post(postModel: contact);
			return result.Id;
		}

		public long Delete(long contactId)
		{
			var result = base.Delete(contactId);
			return result.Id;
		}

	}
}
