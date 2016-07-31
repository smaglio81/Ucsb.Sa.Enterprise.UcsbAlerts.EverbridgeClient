using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{

	public class ContactPagedResponse : EverbridgePagedResponse<Contact> { }

	public class ContactResponse : EverbridgeResponse<Contact> {}
	
	public class ContactPost : EverbridgeBase
	{
		public const long NoContact = -1;
		public const long UndefinedContact = 0;

		public ContactPost()
		{
			Paths = new List<ContactPathInfoPost>();
			Groups = new List<long>();
			Address = new List<ContactAddress>();
			Topics = new List<string>();
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public long RecordTypeId { get; set; }
		public string RegisteredDate { get; set; }
		public string RegisteredEmail { get; set; }
		public string ExternalId { get; set; }
		public virtual List<ContactPathInfoPost> Paths { get; set; }
		public List<long> Groups { get; set; }
		public List<ContactAddress> Address { get; set; }
		public string UploadProcessing { get; set; }
		public List<string> Topics { get; set; }
		public string IndividualAccountId { get; set; }
		public string Country { get; set; }
	}

	public class Contact : ContactPost
	{
		public Contact() : base()
		{
			Paths = new List<ContactPathInfo>();
			GeoSearchAddress = new List<ContactAddress>();
		}
		
		public List<ContactPathInfo> Paths { get; set; }
		public List<ContactAddress> GeoSearchAddress { get; set; }
		public string Status { get; set; }
	}


	public class ContactPathInfoPost
	{
		public long PathId { get; set; }
		public string Value { get; set; }
		public string CountryCode { get; set; }
		public long WaitTime { get; set; }
	}

	public class ContactPathInfo : ContactPathInfoPost
	{
		public int Priority { get; set; }
		public string SystemRequirement { get; set; }
		public string PhoneExt { get; set; }
	}

	public class ContactAddress
	{
		public string StreetAddress { get; set; }
		public string PostalCode { get; set; }
		public long LocationId { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string LocationName { get; set; }
		public ContactGisLocation GisLocation { get; set; }
		public string Source { get; set; }
	}

	public class ContactGisLocation
	{
		public Double Lon { get; set; }
		public Double Lat { get; set; }
	}

}
