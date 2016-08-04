using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ucsb.Sa.Enterprise.ClientExtensions;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public class ContactsHttpClient : EverbridgeHttpClient<Contact, ContactResponse, ContactPagedResponse>
	{

		public ContactsHttpClient() : base("")
		{
			Name = string.Format("contacts/{0}", Organization.OrganizationId);
		}

		public ContactPagedResponse GetPaged(int i = 1)
		{
			var url = string.Format("{0}/?pageNumber={1}", Name, i);
			var response = EverbridgeExecute(url: url, method: HttpMethod.Get);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				ContactPagedResponse result = HttpResponseMessageExtensions.DeserializeHttpResponse<ContactPagedResponse>(json, "json");
				return result;
			}

			return (ContactPagedResponse)HandleUnsuccessfulResponse(response);
		}

		public Contact Get(string externalId)
		{
			var url = string.Format("{0}/{1}?idType=externalId", Name, externalId);
			var response = EverbridgeExecute(url: url, method: HttpMethod.Get);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				ContactResponse result = HttpResponseMessageExtensions.DeserializeHttpResponse<ContactResponse>(json, "json");
				return result.Result;
			}

			return (Contact)HandleUnsuccessfulResponse(response);
		}

		public long GetContactId(string externalId)
		{
			var contact = Get(externalId);
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
				SsoUserId = ucsbCampusId,
				Paths = new List<ContactPathInfoPost>()
				{
					new ContactPathInfoPost()
					{
						WaitTime = 0,
						PathId = ContactPath.AlertEmail,
						Value = email
					}
				},
				ContactAttributes = new List<ContactContactAttribute>()
				{
					ContactContactAttribute.NonCampusIndividual
				}
			};

			var result = Post(postModel: contact);
			return result.Id;
		}

		public EverbridgeUpdateResponse Put(Contact contact)
		{
			var putModel = new ContactPost(contact);
			return base.Put(id: putModel.Id, putModel: putModel);
		}

		public long Delete(long contactId)
		{
			var result = base.Delete(contactId);
			return result.Id;
		}

	}
}
