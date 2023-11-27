#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasProduct
{
    StripeProduct Product { get; set; }
    string ProductId { get; set; }
}