using System;
using Amazon.Lambda.Core;
using Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace MyFunction
{
	public class Function
	{
		public string FunctionHandlerAsync(object input, ILambdaContext context)
		{
			var topic = GetEnvironmentVariable("topic");
			var configJson = GetEnvironmentVariable("config");

			var checker = new CryptoChecker(
				new Configuration(configJson),
				new CryptoPrices(),
				new Notifications(topic)
			);

			return checker.Run();
		}

		private string GetEnvironmentVariable(string name)
		{
			var var = Environment.GetEnvironmentVariable(name);
			if (string.IsNullOrEmpty(var))
			{
				throw new InvalidOperationException("Missing environment variable " + name);
			}
			return var;
		}
	}
}
