﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using IdentityModel;

namespace TranslationPro.Testing.Services;

public class SimpleResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        if (context.UserName != "admin@admin.com" || context.Password != "ASDFasdf!")
        {
            context.Result =
                new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Username or password is wrong!");
            return Task.CompletedTask;
        }

        context.Result = new GrantValidationResult("1", OidcConstants.AuthenticationMethods.Password,
            new List<Claim>
            {
                new(JwtClaimTypes.Subject, "1")
            });

        return Task.CompletedTask;
    }
}