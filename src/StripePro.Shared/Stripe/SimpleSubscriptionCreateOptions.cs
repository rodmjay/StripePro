#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace StripePro.Shared.Stripe;

public class SimpleSubscriptionCreateOptions
{
    public string PriceId { get; set; }
    public string CouponCode { get; set; }
}