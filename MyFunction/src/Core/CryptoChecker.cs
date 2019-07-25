using System.Linq;
using System.Threading.Tasks;

namespace Core
{
	public class CryptoChecker
	{
		private const int TIMEOUT_MILLISECONDS = 10 * 1000;

		public CryptoChecker(
			Configuration config,
			CryptoPrices priceService,
			Notifications notifications)
		{
			this.Config = config;
			this.PriceService = priceService;
			this.Notifications = notifications;
		}

		private Configuration Config { get; }
		private CryptoPrices PriceService { get; }
		private Notifications Notifications { get; }

		public string Run()
		{
			var checks = this.Config.CryptoToMonitor();

			var tasks = checks.Select(a => ExecuteCheck(a)).ToArray();

			Task.WaitAll(tasks, TIMEOUT_MILLISECONDS);

			return string.Join("\r\n", tasks.Select(t => t.Result));
		}

		private async Task<string> ExecuteCheck(string symbol)
		{
			var price = await this.PriceService.GetAsync(symbol);
			if (price == null)
			{
				return $"{symbol} prices unavailable";
			}

			var sellTriggered = false;
			var buyTriggered = false;

			var message = $"{price.Ticker.Base} price: {price.Ticker.Price}";

			if (price.Ticker.Price >= this.Config.GetHigh(symbol))
			{
				sellTriggered = true;
				await this.Notifications.NotifyAsync(message);
			}

			if (price.Ticker.Price <= this.Config.GetLow(symbol))
			{
				buyTriggered = true;
				await this.Notifications.NotifyAsync(message);
			}

			return $"{price.Ticker.Base} @ {price.Ticker.Price} sell: {sellTriggered}, buy: {buyTriggered}";
		}
	}
}