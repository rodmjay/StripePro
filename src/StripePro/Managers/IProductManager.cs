#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IProductManager : IService<StripeProduct>
{
    Task<Result> CreateProduct(ProductCreateOptions options);
    Task<Result> DeleteProduct(string productId, ProductDeleteOptions options);
    Task<Result> UpdateProduct(string productId, ProductUpdateOptions options);
    Task<Result> HandleProductCreated(Product input);
    Task<Result> HandleProductDeleted(Product input);
    Task<Result> HandleProductUpdated(Product input);
}