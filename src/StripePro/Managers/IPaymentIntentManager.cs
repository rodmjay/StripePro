#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IPaymentIntentManager : IService<StripePaymentIntent>
{
    Task<Result> HandlePaymentIntentCanceled(PaymentIntent input);
    Task<Result> HandlePaymentIntentCreated(PaymentIntent input);
    Task<Result> HandlePaymentIntentPartiallyFunded(PaymentIntent input);
    Task<Result> HandlePaymentIntentPaymentFailed(PaymentIntent input);
    Task<Result> HandlePaymentIntentProcessing(PaymentIntent input);
    Task<Result> HandlePaymentIntentRequiresAction(PaymentIntent input);
    Task<Result> HandlePaymentIntentSucceeded(PaymentIntent input);
    Task<Result> HandlePaymentIntentCapturableUpdated(PaymentIntent deserialize);
    Task<Result> HandlePaymentRequiresAction(PaymentIntent deserialize);
}