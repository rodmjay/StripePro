#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasSubscriptionItem
{
    string SubscriptionItemId { get; set; }
    StripeSubscriptionItem SubscriptionItem { get; set; }
}