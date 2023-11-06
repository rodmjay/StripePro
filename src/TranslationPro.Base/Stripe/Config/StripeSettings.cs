﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


namespace TranslationPro.Base.Stripe.Config;

public class StripeSettings
{
    public string SecretKeyEnvironmentVariableName { get; set; }
    public bool UseWebHooks { get; set; }
}