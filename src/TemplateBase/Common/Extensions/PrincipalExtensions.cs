﻿#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Diagnostics;
using System.Security.Principal;

namespace TemplateBase.Common.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="System.Security.Principal.IPrincipal" /> and
    ///     <see cref="System.Security.Principal.IIdentity" /> .
    /// </summary>
    public static class PrincipalExtensions
    {
        /// <summary>
        ///     Determines whether this instance is authenticated.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <returns>
        ///     <c>true</c> if the specified principal is authenticated; otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsAuthenticated(this IPrincipal principal)
        {
            return principal is {Identity: {IsAuthenticated: true}};
        }
    }
}