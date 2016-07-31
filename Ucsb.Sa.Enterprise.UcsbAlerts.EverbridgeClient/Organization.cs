using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{

	public class OrganizationPagedResponse : EverbridgePagedResponse<Organization> { }

	public class OrganizationResponse : EverbridgeResponse<Organization> {}

	public class Organization : EverbridgeBase
	{
		public Organization()
		{
			ProductIds = new List<long>();
			FeatureIds = new List<long>();
			RoleIds = new List<long>();
		}

		public const long UcsbAlertsId = 453003085614511;
		public const long UcsbITAlertsId = 453003085614535;
		public const long UcsbTestId = 453003085614664;

		public static long OrganizationId
		{
			get
			{
				if(EverbridgeHttpClientManager.IsProd) { return UcsbAlertsId; }
				return UcsbTestId;
			}
		}

		public long LastModifiedDate { get; set; }
		public string WeatherProvider { get; set; }
		public List<long> ProductIds { get; set; }
		public long DataCenterId { get; set; }
		public bool ShowMessage { get; set; }
		public string Type { get; set; }
		public bool AccountDisabled { get; set; }
		public OrganizationThrottleSetting ThrottleSetting { get; set; }
		public bool AllowSendMessage { get; set; }
		public long AwareOrgId { get; set; }
		public string Status { get; set; }
		public long ContactCount { get; set; }
		public long TwitterThresholdCount { get; set; }
		public bool ShareMessageStatus { get; set; }
		public string Email { get; set; }
		public string OrganizationStatus { get; set; }
		public long Language { get; set; }
		public bool AllowShareMessage { get; set; }
		public string EmailFromDisplay { get; set; }
		public List<long> FeatureIds { get; set; }
		public string ConferenceBridgePermission { get; set; }
		public string Name { get; set; }
		public long LastModifiedMsgBy { get; set; }
		public string AdminPhone { get; set; }
		public long LastSynchronizedTime { get; set; }
		public long ResourceBundleIf { get; set; }
		public string AccountName { get; set; }
		public long PasswordRefreshDays { get; set; }
		public OrganizationAddress Address { get; set; }
		public bool SenderInfoPermission { get; set; }
		public List<long> RoleIds { get; set; }
		public OrganizationGisSettings GisSettings { get; set; }
		public bool Dirty { get; set; }
	}

	public class OrganizationThrottleSetting
	{
		public bool SenderReviewFlag { get; set; }
		public int DefaultAmount { get; set; }
		public bool SenderToggleFlag { get; set; }
		public bool Flag { get; set; }
		public long CreatedBy { get; set; }
		public long LastModifiedBy { get; set; }
		public bool EnforceAllFlag { get; set; }
		public bool ApplyByFlag { get; set; }
	}

	public class OrganizationBroadcastSetting
	{
		public long PathInterval { get; set; }
		public long EmergencyPriority { get; set; }
		public long StandardDuration { get; set; }
		public long StandardPriority { get; set; }
		public long DefaultCycles { get; set; }
		public long CycleInterval { get; set; }
		public bool DuplicatePathsFlag { get; set; }
		public long MaxCycles { get; set; }
		public long EmergencyDuration { get; set; }
		public bool UseExternalIdFlag { get; set; }
		public bool ExposeSenderId { get; set; }
		public bool RequireSecurityCodeFlag { get; set; }
		public bool ConfirmFlag { get; set; }
		public string VmPreference { get; set; }
		public long LaunchByPhoneFlag { get; set; }
	}

	public class OrganizationAddress
	{
		public string Country { get; set;}
	}

	public class OrganizationGisSettings
	{
		public string MapCenter { get; set; }
		public long Projection { get; set; }
		public Double Longitude { get; set; }
		public long BaseMap { get; set; }
		public Double Latitude { get; set; }
		public long MapZoomLevel { get; set; }
	}
	
}
