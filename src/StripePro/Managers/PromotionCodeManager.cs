#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Stripe;
using StripePro.Entities;

namespace StripePro.Managers;

public class PromotionCodeManager : StripeManager<StripePromotionCode>, IPromotionCodeManager
{
    protected readonly PromotionCodeService PromotionCodeService;

    public PromotionCodeManager(IServiceProvider serviceProvider, PromotionCodeService promotionCodeService) : base(serviceProvider)
    {
        PromotionCodeService = promotionCodeService;
    }
}