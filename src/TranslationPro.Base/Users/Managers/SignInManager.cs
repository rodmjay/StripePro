﻿#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TranslationPro.Base.Common;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Factories;

namespace TranslationPro.Base.Users.Managers;

public partial class SignInManager : SignInManager<User>, IResourceOwnerPasswordValidator
{
    private const string LoginProviderKey = "LoginProvider";
    private const string XsrfKey = "XsrfId";
    private readonly UserRoleClaimsPrincipalFactory _claimsFactory;
    private readonly IUserConfirmation<User> _confirmation;
    private readonly ILogger<SignInManager> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IAuthenticationSchemeProvider _schemes;

    public SignInManager(UserManager userManager,
        IHttpContextAccessor contextAccessor,
        UserRoleClaimsPrincipalFactory claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager> logger,
        IPasswordHasher<User> passwordHasher,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory,
        optionsAccessor, logger, schemes, confirmation)
    {
        _claimsFactory = claimsFactory;
        _logger = logger;
        _passwordHasher = passwordHasher;
        _confirmation = confirmation;
        _schemes = schemes;
    }


    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var account = await UserManager.FindByNameAsync(context.UserName);
        if (account == null)
        {
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                ErrorMessages.UserErrors.UserDoesNotExist);
        }
        else
        {
            var isValid =
                UserManager.PasswordHasher.VerifyHashedPassword(account, account.PasswordHash, context.Password);
            if (isValid == PasswordVerificationResult.Failed)
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    ErrorMessages.UserErrors.InvalidPassword);
            else if (isValid == PasswordVerificationResult.Success)
                context.Result = new GrantValidationResult(
                    account.Id.ToString(),
                    "local"
                );
        }
    }

    private string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(SignInManager)}.{callerName}] - {message}";
    }

    public override async Task<ClaimsPrincipal> CreateUserPrincipalAsync(User user)
    {
        return await _claimsFactory.CreateAsync(user);
    }

    public override bool IsSignedIn(ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.Identities.Any(i =>
            i.AuthenticationType == Constants.LocalIdentity.DefaultApplicationScheme);
    }

    public override async Task<bool> CanSignInAsync(User user)
    {
        if (Options.SignIn.RequireConfirmedEmail && !await UserManager.IsEmailConfirmedAsync(user))
        {
            Logger.LogWarning(0, "User cannot sign in without a confirmed email.");
            return false;
        }

        if (Options.SignIn.RequireConfirmedPhoneNumber && !await UserManager.IsPhoneNumberConfirmedAsync(user))
        {
            Logger.LogWarning(1, "User cannot sign in without a confirmed phone number.");
            return false;
        }

        if (Options.SignIn.RequireConfirmedAccount && !await _confirmation.IsConfirmedAsync(UserManager, user))
        {
            Logger.LogWarning(4, "User cannot sign in without a confirmed account.");
            return false;
        }

        return true;
    }

    public override Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null)
    {
        return SignInAsync(user, new AuthenticationProperties {IsPersistent = isPersistent}, authenticationMethod);
    }

    public override Task SignInAsync(User user, AuthenticationProperties authenticationProperties,
        string authenticationMethod = null)
    {
        IList<Claim> additionalClaims = Array.Empty<Claim>();
        if (authenticationMethod != null)
            additionalClaims = new List<Claim>
            {
                new(ClaimTypes.AuthenticationMethod, authenticationMethod)
            };

        return SignInWithClaimsAsync(user, authenticationProperties, additionalClaims);
    }

    protected override async Task<SignInResult> PreSignInCheck(User user)
    {
        if (!await CanSignInAsync(user)) return SignInResult.NotAllowed;
        if (await IsLockedOut(user)) return await LockedOut(user);
        return null;
    }
}