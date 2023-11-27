#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasPaymentIntent
{
    string PaymentIntentId { get; set; }
    public StripePaymentIntent PaymentIntent { get; set; }
}