#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TranslationPro.Base.Applications.Extensions;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Extensions;
using TranslationPro.Base.Common.Middleware.Extensions;
using TranslationPro.Base.Languages.Extensions;
using TranslationPro.Base.Permissions;
using TranslationPro.Base.Phrases.Extensions;
using TranslationPro.Base.Stripe.Extensions;
using TranslationPro.Base.Translations.Extensions;

namespace TranslationPro.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var assembly = typeof(HostBuilderExtensions).Assembly;

        var config = new ConfigurationBuilder();

        config
            .AddEmbeddedJsonFile(assembly, "sharedSettings.json")
            .AddEmbeddedJsonFile(assembly, $"sharedSettings.{environmentName}.json", true)
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile($"appsettings.{environmentName}.json", true);

        config
            .AddEnvironmentVariables();

        var appBuilder = builder.Services.ConfigureApp(config.Build())
            .AddDatabase<ApplicationContext>()
            .AddAutomapperProfilesFromAssemblies()
            .AddPermissionExtensions()
            .AddLanguageDependencies()
            .AddApplicationDependencies()
            .AddPhraseDependencies()
            .AddTranslationDependencies()
            .AddStripeDependencies();
    }
}