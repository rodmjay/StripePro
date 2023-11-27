using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasSubscription
{
    string SubscriptionId { get; set; }
    StripeSubscription Subscription { get; set; }
}