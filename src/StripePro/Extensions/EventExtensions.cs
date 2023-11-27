using Newtonsoft.Json;
using Stripe;
using StripePro.Common.Extensions;

namespace StripePro.Extensions;

public static class EventExtensions
{
    public static T Deserialize<T>(this Event input)
    {
        return JsonConvert.DeserializeObject<T>(input.Data.Object.ToJson());
    }
}