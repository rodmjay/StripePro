﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using TranslationPro.Base.Common.Services.Interfaces;
using TranslationPro.Base.Stripe.Entities;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Stripe.Interfaces;

public interface IStripeCustomerService : IService<StripeCustomer>
{
    Task<Result> CreateCustomer(int userId, CustomerCreateOptions options);
    Task<Result> HandleCustomerCreated(Customer input);
    Task<Result> HandleCustomerUpdated(Customer  input);
    Task<Result> HandleCustomerDeleted(Customer input);
    Task<Result> HandleCustomerDiscountCreated(Discount input);
    Task<Result> HandleCustomerDiscountDeleted(Discount input);
    Task<Result> HandleCustomerSourceCreated(Card card);


    Task<Customer> GetCustomer(string customerId, CustomerGetOptions options = null);
}