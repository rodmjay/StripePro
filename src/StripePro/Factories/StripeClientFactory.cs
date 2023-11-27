using System;
using Stripe;
using StripePro.Config;

namespace StripePro.Factories
{
    public class StripeClientFactory
    {
        public static StripeClient GetFromSettings(StripeSettings config)
        {
            var apiKey = Environment.GetEnvironmentVariable(config.SecretKeyEnvironmentVariableName);

            return new StripeClient(apiKey: apiKey);
        }
    }
}
