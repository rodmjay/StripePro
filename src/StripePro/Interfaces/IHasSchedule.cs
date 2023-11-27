#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Entities;

namespace StripePro.Interfaces;

public interface IHasSchedule
{
    StripeSubscriptionSchedule Schedule { get; set; }
    string ScheduleId { get; set; }
}