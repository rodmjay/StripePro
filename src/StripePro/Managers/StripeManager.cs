#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using StripePro.Common.Data.Interfaces;
using StripePro.Common.Services.Bases;
using StripePro.Config;

namespace StripePro.Managers;

public abstract class StripeManager<TEntity> : BaseService<TEntity> where TEntity : class, IObjectState
{
    protected IStripeClient StripeClient;
    protected StripeSettings StripeSettings;
    protected StripeManager(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        StripeClient = serviceProvider.GetRequiredService<IStripeClient>();
        StripeSettings = serviceProvider.GetRequiredService<StripeSettings>();
    }
}