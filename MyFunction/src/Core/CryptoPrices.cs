using System.Net.Http;
using Newtonsoft.Json;

namespace Core
{
	public class CryptoPrices
	{
		private static HttpClient _client = new HttpClient();
		
		public async System.Threading.Tasks.Task<Prices> GetAsync(string symbol)
		{
			var url = $"https://api.cryptonator.com/api/full/{symbol}";

			var result = await _client.GetAsync(url);

			result.EnsureSuccessStatusCode();

			var content = await result.Content.ReadAsStringAsync();

			var prices = JsonConvert.DeserializeObject<Prices>(content);

			return prices;
		}
	}
}