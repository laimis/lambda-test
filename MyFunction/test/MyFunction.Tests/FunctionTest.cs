
using Xunit;
using Amazon.Lambda.TestUtilities;
using System;

namespace MyFunction.Tests
{
	public class FunctionTest
	{
		[Fact]
		public void TestToUpperFunction()
		{

			Environment.SetEnvironmentVariable("topic", "blabla");

			Environment.SetEnvironmentVariable(
				"config",
				@"[{""symbol"":""eth-usd"",""low"":190,""high"":243},{""symbol"":""ltc-usd"",""low"":80,""high"":100}]"
			);

			// Invoke the lambda function and confirm the string was upper cased.
			var function = new Function();
			var context = new TestLambdaContext();
			var result = function.FunctionHandlerAsync("hello world", context);

			Assert.Contains("ETH", result);
			Assert.Contains("LTC", result);
		}
	}
}
