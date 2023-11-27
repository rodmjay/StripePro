#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IPaymentMethodManager : IService<StripePaymentMethod>
{
    Task<Result> HandlePaymentMethodAttached(PaymentMethod input);
    Task<Result> HandlePaymentMethodAutomaticallyUpdated(PaymentMethod input);
    Task<Result> HandlePaymentMethodDetached(PaymentMethod input);
    Task<Result> HandlePaymentMethodUpdated(PaymentMethod input);
}