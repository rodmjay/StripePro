using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasPrice
{
    string PriceId { get; set; }
    StripePrice Price { get; set; }
}