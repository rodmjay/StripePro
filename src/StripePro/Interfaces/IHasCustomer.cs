using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasCustomer
{
    StripeCustomer Customer { get; set; }
    string CustomerId { get; set; }
}