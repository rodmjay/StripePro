﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranslationPro.IdentityServer.Pages.Account;

[AllowAnonymous]
public class ForgotPasswordConfirmation : PageModel
{
    public void OnGet()
    {
    }
}