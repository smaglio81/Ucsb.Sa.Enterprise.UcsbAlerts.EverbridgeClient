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
			ContactAttributes = new List<ContactContactAttribute>();
		}

		public ContactPost(ContactPost copyFrom) : base(copyFrom)
		{
			FirstName = copyFrom.FirstName;
			LastName = copyFrom.LastName;
			RecordTypeId = copyFrom.RecordTypeId;
			RegisteredDate = copyFrom.RegisteredDate;
			RegisteredEmail = copyFrom.RegisteredEmail;
			ExternalId = copyFrom.ExternalId;
			UploadProcessing = copyFrom.UploadProcessing;
			IndividualAccountId = copyFrom.IndividualAccountId;
			Country = copyFrom.Country;
			SsoUserId = copyFrom.SsoUserId;
			
			Paths = new List<ContactPathInfoPost>();
			//	could have used an interface ... decided against it
			switch (copyFrom.GetType().Name)
			{
				case "Contact":
					foreach (var path in ((Contact) copyFrom).Paths)
					{
						var p = new ContactPathInfoPost(path);
						Paths.Add(p);
					}
					break;
				default:
					foreach (var path in copyFrom.Paths)
					{
						var p = new ContactPathInfoPost(path);
						Paths.Add(p);
					}
					break;
			}

			Groups = new List<long>();
			Groups.AddRange(copyFrom.Groups);

			Address = new List<ContactAddress>();
			foreach (var addr in copyFrom.Address)
			{
				var a = new ContactAddress(addr);
				Address.Add(a);
			}

			Topics = new List<string>();
			Topics.AddRange(copyFrom.Topics);

			ContactAttributes = new List<ContactContactAttribute>();
			foreach (var attr in copyFrom.ContactAttributes)
			{
				var a = new ContactContactAttribute(attr);
				ContactAttributes.Add(a);
			}
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public long RecordTypeId { get; set; }
		public string RegisteredDate { get; set; }
		public string RegisteredEmail { get; set; }
		public string ExternalId { get; set; }
		public List<ContactPathInfoPost> Paths { get; set; }
		public List<long> Groups { get; set; }
		public List<ContactAddress> Address { get; set; }
		public string UploadProcessing { get; set; }
		public List<string> Topics { get; set; }
		public string IndividualAccountId { get; set; }
		public string Country { get; set; }
		public string SsoUserId { get; set; }
		public List<ContactContactAttribute> ContactAttributes { get; set; }
	}

	public class Contact : ContactPost
	{
		public Contact() : base()
		{
			Paths = new List<ContactPathInfo>();
			GeoSearchAddress = new List<ContactAddress>();
		}

		public Contact(Contact copyFrom) : base(copyFrom)
		{
			Status = copyFrom.Status;

			Paths = new List<ContactPathInfo>();
			foreach (var path in Paths)
			{
				var p = new ContactPathInfo(path);
				Paths.Add(p);
			}

			GeoSearchAddress = new List<ContactAddress>();
			foreach (var address in copyFrom.GeoSearchAddress)
			{
				var a = new ContactAddress(address);
				GeoSearchAddress.Add(a);
			}
		}

		public List<ContactPathInfo> Paths { get; set; }
		public List<ContactAddress> GeoSearchAddress { get; set; }
		public string Status { get; set; }
	}


	public class ContactPathInfoPost
	{
		public ContactPathInfoPost() {}

		public ContactPathInfoPost(ContactPathInfoPost copyFrom)
		{
			PathId = copyFrom.PathId;
			Value = copyFrom.Value;
			CountryCode = copyFrom.CountryCode;
			WaitTime = copyFrom.WaitTime;
		}

		public long PathId { get; set; }
		public string Value { get; set; }
		public string CountryCode { get; set; }
		public long WaitTime { get; set; }
	}

	public class ContactPathInfo : ContactPathInfoPost
	{
		public ContactPathInfo() {}

		public ContactPathInfo(ContactPathInfo copyFrom) : base(copyFrom)
		{
			Priority = copyFrom.Priority;
			SystemRequirement = copyFrom.SystemRequirement;
			PhoneExt = copyFrom.PhoneExt;
		}

		public int Priority { get; set; }
		public string SystemRequirement { get; set; }
		public string PhoneExt { get; set; }
	}

	public class ContactAddress
	{
		public ContactAddress() {}

		public ContactAddress(ContactAddress copyFrom)
		{
			StreetAddress = copyFrom.StreetAddress;
			PostalCode = copyFrom.PostalCode;
			LocationId = copyFrom.LocationId;
			City = copyFrom.City;
			State = copyFrom.State;
			Country = copyFrom.Country;
			LocationName = copyFrom.LocationName;
			Source = copyFrom.Source;

			GisLocation = new ContactGisLocation(copyFrom.GisLocation);
		}

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
		public ContactGisLocation() {}

		public ContactGisLocation(ContactGisLocation copyFrom)
		{
			Lon = copyFrom.Lon;
			Lat = copyFrom.Lat;
		}

		public Double Lon { get; set; }
		public Double Lat { get; set; }
	}

	public class ContactContactAttribute
	{

		public static ContactContactAttribute NonCampusIndividualProd =
			new ContactContactAttribute()
			{
				OrgAttrId = 1323816294816030,
				Name = "Non-Campus Individual?",
				Values = new List<string>() {"Yes"}
			};

		public static ContactContactAttribute CampusOnlyIndividualProd =
			new ContactContactAttribute()
			{
				OrgAttrId = 1323816294816030,
				Name = "Non-Campus Individual?",
				Values = new List<string>() { "No" }
			};

		public static ContactContactAttribute NonCampusIndividualTest =
			new ContactContactAttribute()
			{
				OrgAttrId = 1323816294816031,
				Name = "Non-Campus Individual?",
				Values = new List<string>() { "Yes" }
			};

		public static ContactContactAttribute CampusOnlyIndividualTest =
			new ContactContactAttribute()
			{
				OrgAttrId = 1323816294816031,
				Name = "Non-Campus Individual?",
				Values = new List<string>() { "No" }
			};

		public static ContactContactAttribute NonCampusIndividual
		{
			get
			{
				if (EverbridgeHttpClientManager.IsProd) { return NonCampusIndividualProd; }
				return NonCampusIndividualTest;
			}
		}

		public static ContactContactAttribute CampusOnlyIndividual
		{
			get
			{
				if (EverbridgeHttpClientManager.IsProd) { return CampusOnlyIndividualProd; }
				return CampusOnlyIndividualTest;
			}
		}



		public ContactContactAttribute() {}

		public ContactContactAttribute(ContactContactAttribute copyFrom)
		{
			OrgAttrId = copyFrom.OrgAttrId;
			Name = copyFrom.Name;

			Values = new List<string>();
			Values.AddRange(copyFrom.Values);
		}

		public List<string> Values { get; set; }
		public long OrgAttrId { get; set; }
		public string Name { get; set; }
	}

}
