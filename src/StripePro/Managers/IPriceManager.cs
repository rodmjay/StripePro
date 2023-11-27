#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IPriceManager : IService<StripePrice>
{
    Task<Result> CreatePrice(PriceCreateOptions options);
    Task<Result> UpdatePrice(string priceId, PriceUpdateOptions options);
    Task<Result> HandlePriceCreated(Price input);
    Task<Result> HandlePriceDeleted(Price input);
    Task<Result> HandlePriceUpdated(Price input);
}