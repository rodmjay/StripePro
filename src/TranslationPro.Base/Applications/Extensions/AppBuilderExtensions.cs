﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Services;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Shared.Applications;

namespace TranslationPro.Base.Applications.Extensions;

public static class AppBuilderExtensions
{
    public static AppBuilder AddApplicationDependencies(this AppBuilder builder)
    {
        builder.Services.TryAddTransient<ApplicationErrorDescriber>();
        builder.Services.TryAddScoped<IApplicationService, ApplicationService>();
        return builder;
    }
}