using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasDiscount
{
    string DiscountId { get; set; }
    StripeDiscount Discount { get; set; }
}