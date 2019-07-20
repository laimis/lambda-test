using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Core
{
	public class Notifications
	{
		private string _topic;

		public Notifications(string topic)
		{
			this._topic = topic;
		}
		
		public async Task NotifyAsync(string message)
		{
			var request = new PublishRequest
			{
				TopicArn = _topic,
				Message = message
			};

			var client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.USEast1);

			await client.PublishAsync(request);
		}
	}
}