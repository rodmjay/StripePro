using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface ISubscriptionManager : IService<StripeSubscription>
{
    Task<Result> CreateSubscription(int userId, SubscriptionCreateOptions options);
    Task<Result> CreateSubscription(string customerId, SubscriptionCreateOptions options);
    Task<Result> HandleSubscriptionCreated(Subscription input);
    Task<Result> HandleSubscriptionDeleted(Subscription input);
    Task<Result> HandleSubscriptionUpdated(Subscription input);
    Task<Result> HandleSubscriptionPaused(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateApplied(Subscription input);
    Task<Result> HandleSubscriptionPendingUpdateExpired(Subscription input);
    Task<Result> HandleSubscriptionResumed(Subscription input);
    Task<Result> HandleSubscriptionTrialWillEnd(Subscription input);

}