using System.Threading.Tasks;
using Stripe;
using StripePro.Common.Services.Interfaces;
using StripePro.Entities;
using StripePro.Shared.Common;

namespace StripePro.Managers;

public interface ICouponManager : IService<StripeCoupon>
{
    Task<Result> CreateCoupon(CouponCreateOptions options);
    Task<Result> UpdateCoupon(string couponId, CouponUpdateOptions options);
    Task<Result> DeleteCoupon(string couponId, CouponDeleteOptions options);
    Task<Result> HandleCouponCreated(Coupon coupon);
    Task<Result> HandleCouponDeleted(Coupon coupon);
}