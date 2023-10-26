﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.AspNetCore.Identity;

namespace TranslationPro.Base.Common;

public static class Constants
{
    public static class LocalIdentity
    {
        public static string DefaultApplicationScheme = IdentityConstants.ApplicationScheme;
        public static string DefaultExternalScheme = IdentityConstants.ExternalScheme;

        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        public static bool ShowLogoutPrompt = true;
        public static bool AutomaticRedirectAfterSignOut = false;

        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}