#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection;
using StripePro.Common.Settings;

namespace StripePro.Common.Middleware.Builders;

public class UIBuilder
{
    public UIBuilder(WebAppBuilder serviceBuilder)
    {
        Services = serviceBuilder.Services;
        AppSettings = serviceBuilder.AppSettings;
    }

    public AppSettings AppSettings { get; }
    public IServiceCollection Services { get; }
}