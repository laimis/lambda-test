using Newtonsoft.Json;

namespace Core
{
	public partial class Prices
	{
		[JsonProperty("ticker")]
		public Ticker Ticker { get; set; }

		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("error")]
		public string Error { get; set; }
	}

	public partial class Ticker
	{
		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonProperty("target")]
		public string Target { get; set; }

		[JsonProperty("price")]
		public float Price { get; set; }

		[JsonProperty("volume")]
		public string Volume { get; set; }

		[JsonProperty("change")]
		public string Change { get; set; }

		[JsonProperty("markets")]
		public Market[] Markets { get; set; }
	}

	public partial class Market
	{
		[JsonProperty("market")]
		public string MarketMarket { get; set; }

		[JsonProperty("price")]
		public string Price { get; set; }

		[JsonProperty("volume")]
		public double Volume { get; set; }
	}
}
