#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasCharge
{
    string ChargeId { get; set; }

    StripeCharge Charge { get; set; }
}