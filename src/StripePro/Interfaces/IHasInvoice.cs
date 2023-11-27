using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasInvoice
{
    string InvoiceId { get; set; }
    StripeInvoice Invoice { get; set; }
}