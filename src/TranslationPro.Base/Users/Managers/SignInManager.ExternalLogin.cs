﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TranslationPro.Base.Users.Managers;

public partial class SignInManager
{
    public override Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
        bool isPersistent, bool bypassTwoFactor)
    {
        return base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
    }

    public override Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
    {
        return base.GetExternalLoginInfoAsync(expectedXsrf);
    }

    public override Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
        bool isPersistent)
    {
        return base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
    }
}