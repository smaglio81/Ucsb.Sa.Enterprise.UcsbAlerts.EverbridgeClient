using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ucsb.Sa.Enterprise.ClientExtensions;

namespace Ucsb.Sa.Enterprise.UcsbAlerts.EverbridgeClient
{
	public abstract class EverbridgeHttpClient<T, K, I>
		: HttpClientSa
		where T : EverbridgeBase
		where K : EverbridgeResponse<T>
		where I : EverbridgePagedResponse<T>
	{

		public string Name { get; set; }

		public EverbridgeHttpClient(string name) : base("everbridge")
	    {
			EverbridgeHttpClientManager.ConfigureHeaders(this);
			Name = name;
	    }

		public object HandleUnsuccessfulResponse(HttpResponseMessage response)
		{
			switch (response.StatusCode)
			{
				case HttpStatusCode.NotFound:
					return null;

				default:
					// search for and handle request limits
					var json = response.ResponseAsString();
					var message = string.Format("Status Code: {0}\r\n{1}", response.StatusCode, json);
					throw new Exception(message);
			}
		}

		public HttpResponseMessage EverbridgeExecute(string url, HttpMethod method, object data = null)
		{
			var response = Execute(url: url, method: method, data: data).Result;

			//	Rate Limited, need to stager (.5 second) and retry
			while (response.StatusCode == (System.Net.HttpStatusCode)429)
			{
				Thread.Sleep(500);
				response = Execute(url: url, method: method, data: data).Result;
			}

			return response;
		}

		public List<T> Get()
		{
			var response = EverbridgeExecute(url: Name, method: HttpMethod.Get);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				I pagedResult = HttpResponseMessageExtensions.DeserializeHttpResponse<I>(json, "json");
				return pagedResult.Page.Data;
			}

			return (List <T>)HandleUnsuccessfulResponse(response);
		}

		public T Get(long id)
		{
			var url = string.Format("{0}/{1}", Name, id);
			var response = EverbridgeExecute(url: url, method: HttpMethod.Get);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				K result = HttpResponseMessageExtensions.DeserializeHttpResponse<K>(json, "json");
				return result.Result;
			}

			return (T)HandleUnsuccessfulResponse(response);
		}

		public EverbridgeUpdateResponse Post(object postModel)
		{
			var response = EverbridgeExecute(url: Name, method: HttpMethod.Post, data: postModel);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				EverbridgeUpdateResponse result = HttpResponseMessageExtensions.DeserializeHttpResponse<EverbridgeUpdateResponse>(json, "json");
				return result;
			}

			return (EverbridgeUpdateResponse)HandleUnsuccessfulResponse(response);
		}

		public EverbridgeUpdateResponse Put(long id, object putModel)
		{
			var url = string.Format("{0}/{1}", Name, id);
			var response = EverbridgeExecute(url: url, method: HttpMethod.Put, data: putModel);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				EverbridgeUpdateResponse result = HttpResponseMessageExtensions.DeserializeHttpResponse<EverbridgeUpdateResponse>(json, "json");
				return result;
			}

			return (EverbridgeUpdateResponse)HandleUnsuccessfulResponse(response);
		}

		public EverbridgeUpdateResponse Delete(long id)
		{
			var url = string.Format("{0}/{1}", Name, id);
			var response = EverbridgeExecute(url: url, method: HttpMethod.Delete);

			if (response.IsSuccessStatusCode)
			{
				var json = response.ResponseAsString();
				EverbridgeUpdateResponse result = HttpResponseMessageExtensions.DeserializeHttpResponse<EverbridgeUpdateResponse>(json, "json");
				return result;
			}

			return (EverbridgeUpdateResponse)HandleUnsuccessfulResponse(response);
		}

	}
}
