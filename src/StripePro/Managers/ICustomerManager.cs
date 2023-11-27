#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface ICustomerManager : IService<StripeCustomer>
{
    Task<Result> CreateCustomer(int userId, CustomerCreateOptions options);
    Task<Result> UpdateCustomer(string customerId, CustomerUpdateOptions options);
    Task<Result> DeleteCustomer(string customerId, CustomerDeleteOptions options);
    Task<Result> HandleCustomerCreated(Customer input);
    Task<Result> HandleCustomerUpdated(Customer input);
    Task<Result> HandleCustomerDeleted(Customer input);
    Task<Result> HandleCustomerDiscountCreated(Discount input);
    Task<Result> HandleCustomerDiscountDeleted(Discount input);
    Task<Result> HandleCustomerSourceCreated(Card card);

    Task<Customer> GetCustomer(string customerId, CustomerGetOptions options = null);
}