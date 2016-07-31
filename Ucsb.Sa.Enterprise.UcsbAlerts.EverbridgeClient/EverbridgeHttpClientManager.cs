using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ucsb.Sa.Enterprise.ClientExtensions;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	/// <summary>
	/// Manager for Http Clients to the Everbridge API
	/// </summary>
	public static class EverbridgeHttpClientManager
	{
		private static AuthenticationHeaderValue AuthenticationToken { get; set; }

		static EverbridgeHttpClientManager()
		{
			var authBytes = Encoding.ASCII.GetBytes("username:password");
			string authBase64 = Convert.ToBase64String(authBytes);
			AuthenticationToken = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authBase64);
		}

		public static void ConfigureHeaders(HttpClientSa client)
		{
			client.DefaultRequestHeaders.Authorization = AuthenticationToken;
		}

		public static bool IsProd
		{
			get
			{
				var org = ConfigurationManager.AppSettings["everbridge:organization"];

				switch (org.ToLower())
				{
					case "prod": return true;
					default: return false;
				}
			}
		}

	}
}
