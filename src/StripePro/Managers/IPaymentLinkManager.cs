#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IPaymentLinkManager : IService<StripePaymentLink>
{
    Task<Result> CreatePaymentLink(int userId, PaymentLinkCreateOptions options);
    Task<Result> HandlePaymentLinkCreated(PaymentLink paymentLink);
}