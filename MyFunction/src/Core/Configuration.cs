using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Core
{
	public class Configuration
	{
		private Dictionary<string, LowHigh> _toMonitor;

		public Configuration(string configJson)
		{
			var arr = JsonConvert.DeserializeObject<LowHigh[]>(configJson);

			_toMonitor = arr.ToDictionary(a => a.Symbol, a => a);
		}

		public IEnumerable<string> CryptoToMonitor() => _toMonitor.Keys;

		public int GetHigh(string symbol) => _toMonitor[symbol].High;

		public int GetLow(string symbol) => _toMonitor[symbol].Low;

		private struct LowHigh
		{
			public LowHigh(string symbol, int low, int high)
			{
				this.Symbol = symbol;
				this.Low = low;
				this.High = high;
			}
			
			public string Symbol;
			public int Low;
			public int High;
		}
	}
}