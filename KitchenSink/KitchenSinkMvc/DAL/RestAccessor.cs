using KitchenSink.Core.DataAccessor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSinkMvc.DAL
{
	public class RestAccessor : IDataAccessor
	{
		private HttpClient _client;
		private IConfiguration _config;
		public RestAccessor(IConfiguration config)
		{
			_config = config;
			_client = new HttpClient();
			_client.DefaultRequestHeaders.Add("Authorization", GetBasicAuthHeaderString());
		}
		public IList<T> Read<T>() where T : IEntity
		{
			var url = $"{_config.GetSection("AppSettings")["ApiUrl"]}api/{typeof(T).Name}";
			var response = _client.GetAsync(url).GetAwaiter().GetResult();
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var returnMe = JsonConvert.DeserializeObject<List<T>>(json);
			return returnMe;
		}

		public IList<T> Read<T>(IDictionary<string, object> parameters) where T : IEntity
		{
			var url = $"{_config.GetSection("AppSettings")["ApiUrl"]}/api/{typeof(T).Name}?";
			url += string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));

			var response = _client.GetAsync(url).GetAwaiter().GetResult();
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			var returnMe = JsonConvert.DeserializeObject<List<T>>(json);
			return returnMe;
		}

		public IResult<T> Write<T>(T writeMe, IDictionary<string, object> parameters) where T : IEntity
		{
			var url = $"{_config.GetSection("AppSettings")["ApiUrl"]}/api/{typeof(T).Name}";
			var content = new StringContent(JsonConvert.SerializeObject(writeMe), Encoding.UTF8, "application/json");
			var response = _client.PostAsync(url, content).GetAwaiter().GetResult();
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

			return JsonConvert.DeserializeObject<Result<T>>(json);
		}

		private string GetBasicAuthHeaderString()
		{
			var encoding = Encoding.GetEncoding("iso-8859-1");
			var convertMe = $"{_config.GetSection("AppSettings")["Username"]}:{_config.GetSection("AppSettings")["Password"]}";
			var converted = Convert.ToBase64String(encoding.GetBytes(convertMe));
			return $"Basic {converted}";
		}
	}
}
