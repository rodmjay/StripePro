using System;
using System.Threading.Tasks;
using Stripe;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public class PaymentMethodManager : StripeManager<StripePaymentMethod>, IPaymentMethodManager
{
    protected readonly PaymentMethodService PaymentMethodService;

    public PaymentMethodManager(IServiceProvider serviceProvider, PaymentMethodService paymentMethodService) : base(serviceProvider)
    {
        PaymentMethodService = paymentMethodService;
    }

    public async Task<Result> HandlePaymentMethodAttached(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodAutomaticallyUpdated(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodDetached(PaymentMethod input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePaymentMethodUpdated(PaymentMethod input)
    {
        throw new NotImplementedException();
    }
}