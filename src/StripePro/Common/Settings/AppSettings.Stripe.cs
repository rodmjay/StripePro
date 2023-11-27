#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using StripePro.Config;

namespace StripePro.Common.Settings;

public partial class AppSettings
{
    public StripeSettings Stripe { get; set; }
}