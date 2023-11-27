﻿using System;
using System.Threading.Tasks;
using Stripe;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public class DiscountManager : StripeManager<StripeDiscount>, IDiscountManager
{
    protected readonly DiscountService DiscountService;

    public DiscountManager(IServiceProvider serviceProvider, DiscountService discountService) : base(serviceProvider)
    {
        DiscountService = discountService;
    }

    public async Task<Result> HandleCustomerDiscountCreated(Discount deserialize)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleCustomerDiscountDeleted(Discount deserialize)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> HandleCustomerDiscountUpdated(Discount deserialize)
    {
        throw new NotImplementedException();
    }
}