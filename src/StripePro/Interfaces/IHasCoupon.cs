using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasCoupon
{
    StripeCoupon Coupon { get; set; }
    string CouponId { get; set; }
}