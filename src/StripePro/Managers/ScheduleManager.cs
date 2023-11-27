#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Stripe;
using StripePro.Entities;

namespace StripePro.Managers;

public class ScheduleManager : StripeManager<StripeSubscriptionSchedule>, IScheduleManager
{
    protected SubscriptionScheduleService ScheduleService;
    public ScheduleManager(IServiceProvider serviceProvider, SubscriptionScheduleService scheduleService) : base(serviceProvider)
    {
        ScheduleService = scheduleService;
    }
}