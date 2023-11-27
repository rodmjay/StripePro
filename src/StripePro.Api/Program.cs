#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using StripePro.Common.Middleware.Extensions;

namespace StripePro.Api;

[ExcludeFromCodeCoverage]
public class Program
{
    public static void Main(string[] args)
    {
        BuildHost(args)
            .Init();
    }

    public static IHostBuilder BuildHost(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(HostBuilderExtensions.Configure)
            .UseSerilog()
            .ConfigureWebHostDefaults(builder =>
            {
                builder
                    .ConfigureLogging(HostBuilderExtensions.ConfigureLogging)
                    .UseStartup<Startup>();
            });
    }
}