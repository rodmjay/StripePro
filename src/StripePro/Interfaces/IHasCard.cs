using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasCard
{
    StripeCard Card { get; set; }
}