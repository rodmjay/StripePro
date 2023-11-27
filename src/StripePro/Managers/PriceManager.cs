using System;
using System.Threading.Tasks;
using Stripe;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public class PriceManager : StripeManager<StripePrice>, IPriceManager
{
    protected readonly PriceService PriceService;
    public PriceManager(IServiceProvider serviceProvider, PriceService priceService) : base(serviceProvider)
    {
        PriceService = priceService;
    }

    public async Task<Result> CreatePrice(PriceCreateOptions options)
    {
        var price = await PriceService.CreateAsync(options);
        if (price != null)
            return Result.Success();

        return Result.Failed();
    }

    public async Task<Result> UpdatePrice(string priceId, PriceUpdateOptions options)
    {
        var price = await PriceService.UpdateAsync(priceId, options);
        if (price != null)
            return Result.Success();

        return Result.Failed();
    }

    public async Task<Result> HandlePriceCreated(Price input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePriceDeleted(Price input)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandlePriceUpdated(Price input)
    {
        throw new NotImplementedException();
    }
}