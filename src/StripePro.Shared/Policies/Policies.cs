﻿using Microsoft.AspNetCore.Authorization;

namespace StripePro.Shared.Policies
{
    public static class Policies
    {
        public const string CanAccessApis = "CanAccessApi";

        public static AuthorizationPolicy CanAccessApi()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }
    }
}
