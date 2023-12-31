﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StripePro.Common.Settings;

namespace StripePro.Common.Middleware.Bases;

[ApiController]
[Produces("application/json")]
[Route("v1.0/[controller]")]
public class BaseController : ControllerBase
{
    protected readonly AppSettings AppSettings;
    protected readonly IDistributedCache Cache;

    /// <param name="serviceProvider"></param>
    protected BaseController(IServiceProvider serviceProvider)
    {
        Cache = serviceProvider.GetRequiredService<IDistributedCache>();
        AppSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
    }
    
}