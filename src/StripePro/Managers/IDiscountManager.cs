using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface IDiscountManager : IService<StripeDiscount>
{
    Task<Result> HandleCustomerDiscountCreated(Discount deserialize);
    Task<Result> HandleCustomerDiscountDeleted(Discount deserialize);
    Task<Result> HandleCustomerDiscountUpdated(Discount deserialize);
}