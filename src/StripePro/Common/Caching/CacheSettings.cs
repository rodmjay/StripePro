#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace StripePro.Common.Caching;

[ExcludeFromCodeCoverage]
public class CacheSettings
{
    public TimeSpan? DefaultExpiration { get; set; }
}