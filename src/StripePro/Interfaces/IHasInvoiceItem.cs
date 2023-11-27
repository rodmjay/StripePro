#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasInvoiceItem
{
    StripeInvoiceLineItem InvoiceLineItem { get; set; }
    string InvoiceLineItemId { get; set; }
}