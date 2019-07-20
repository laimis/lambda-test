## Description

This lambda function that pings cryptocurrency price endpoint and sends notice if the price is either above or below a certain threshold.

# Cryptocurrency check

api.cryptonator.com is used for cryptocurrency to USD conversion rates.

# Notifications

AWS SNS email notifications are used when price threshold is reached.

# Configuration

- create SNS topic and specify topic as an environment variable "topic" in lambda configuration
- for currency check config, create an environment variable "config" in lambda configuration. Example configuration:

```[{"symbol":"eth-usd","low":190,"high":243},{"symbol":"ltc-usd","low":80,"high":114}]```

The above checks ETH-USD rate and sends notice if the value is either above 243 or below 190. LTC-USD is signalled if the value is below 80 or above 114. This is useful to let you know when price is low enough to buy more, or if price is high enough where sell could give you a certain return on your existing purchase.
