#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasPaymentLink
{
    StripePaymentLink PaymentLink { get; set; }
    string PaymentLinkId { get; set; }
}