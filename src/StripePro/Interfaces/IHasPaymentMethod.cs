#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasPaymentMethod
{
    StripePaymentMethod PaymentMethod { get; set; }
    string PaymentMethodId { get; set; }
}